using UnityEngine;
using System;
using Tools;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Beings;
using Values;

namespace Calculator
{
	

	public abstract class AFormula
	{
		
		protected string mFormulaText;

		protected class Parameter
		{
			public string valueName;
			public BEING_KEY beingKey;
			public AValue bindedValue = null;
			public string alias;
			public string initialName;

			public Parameter (Match m, IFormulaParent _parent)
			{
				string key = m.Groups [1].Value;
				if (string.IsNullOrEmpty (key)) {
					beingKey = BEING_KEY.SELF;
				} else {
					try {
						beingKey = (BEING_KEY)Enum.Parse (typeof(BEING_KEY), key.TrimEnd('.').ToUpper ());
					} catch {
						Debug.LogError ("the being key " + key + " is not recognized in formula of object " 
							+ Error.Hierarchy(_parent.GetComponent()));
						beingKey = BEING_KEY.SELF;
					}
				}

				valueName = m.Groups [2].Value;

				alias = Enum.GetName (typeof(BEING_KEY), beingKey).ToLower() + "_" + valueName;
				initialName = m.Groups [0].Value;
			}
		}


		protected bool mIsInitialized;
		protected Dictionary<string, Parameter> mParameters;
		protected IFormulaParent mParent = null;
		protected ABeing mSelf = null;
		protected ABeing mTarget = null;

		private static Regex mParamRegex = null;

		private static Regex ParamRegex {
			get {
				if (mParamRegex == null) {
					mParamRegex = new Regex ("\\b([a-zA-Z]\\w*\\.)?([a-zA-Z]\\w*)\\b");
				}
				return mParamRegex;
			}
		}

		public virtual void Initialize (IFormulaParent _parent)
		{
			mParent = _parent;
			mFormulaText = mParent.GetFormulaText ();

			Debug.Assert (!string.IsNullOrEmpty (mFormulaText), 
				"Formula is empty for component : " + Error.Hierarchy(mParent.GetComponent()));

			mParameters = new Dictionary<string, Parameter> ();
			MatchCollection matches = ParamRegex.Matches (mFormulaText);


			foreach (Match m in matches) {
				Parameter p = new Parameter (m, _parent);
				mFormulaText = mFormulaText.Replace (p.initialName, p.alias);
				if (!mParameters.ContainsKey(p.alias)) {
					mParameters.Add (p.alias, p);
				}
			}


			mIsInitialized = true;

		}

		public bool HasSelfBeing () {
			return (mSelf != null);
		}

		public void SetSelfBeing (ABeing _self)
		{
			Debug.Assert (mIsInitialized, 
				"Calling SetSelfBeing on a non-initialized formula on component " + Error.Hierarchy(mParent.GetComponent()));
			mSelf = _self;

			foreach (Parameter p in mParameters.Values) {
				if (p.beingKey == BEING_KEY.SELF) {
					if (_self == null) {
						p.bindedValue = null;
					} else {
						p.bindedValue = _self.GetValue (p.valueName);
					}
				}
			}
		}

		
		public void SetTargetBeing (ABeing _target)
		{
			Debug.Assert (mIsInitialized, 
				"Calling SetTargetBeing on a non-initialized formula on component " + Error.Hierarchy(mParent.GetComponent()));

			mTarget = _target;

			foreach (Parameter p in mParameters.Values) {
				if (p.beingKey == BEING_KEY.SELF) {
					if (_target == null) {
						p.bindedValue = null;
					} else {
						p.bindedValue = _target.GetValue (p.valueName);
					}
				}
			}
		}

		protected double[] PrepareParameterValueList ()
		{
			Debug.Assert (mIsInitialized, 
				"Calling PrepareParameters on a non-initialized formula on component " 
				+ Error.Hierarchy(mParent.GetComponent()));
			List<double> parameterValueList = new List<double> ();

			foreach (Parameter p in mParameters.Values) {
				parameterValueList.Add (p.bindedValue.GetValue ());
			}


			return parameterValueList.ToArray ();
		}

		public List<AValue> GetAllBindedValues() {
			Debug.Assert (mIsInitialized, 
				"Calling GetAllBindedValues on a non-initialized formula on component " 
				+ Error.Hierarchy(mParent.GetComponent()));
			
			List<AValue> bindedValues = new List<AValue> ();


			foreach (Parameter p in mParameters.Values) {
				if (p.bindedValue != null) {
					bindedValues.Add (p.bindedValue);
				}
			}

			return bindedValues;
		}

	}
}