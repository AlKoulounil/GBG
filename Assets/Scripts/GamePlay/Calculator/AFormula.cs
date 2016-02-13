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
		[Tooltip ("Type here a formula, with variables with this format : ([being_key]).[value_name]")]
		public string FormulaText;

		protected class Parameter
		{
			public string valueName;
			public BEING_KEY beingKey;
			public AValue bindedValue = null;
			public string alias;

			public Parameter (Match m, MonoBehaviour _parent)
			{
				string key = m.Groups [1].Value;
				if (string.IsNullOrEmpty (key)) {
					beingKey = BEING_KEY.SELF;
				} else {
					try {
						beingKey = (BEING_KEY)Enum.Parse (typeof(BEING_KEY), key.TrimEnd('.').ToUpper ());
					} catch {
						Debug.LogError ("the being key " + key + " is not recognized in formula of object " + Error.Hierarchy(_parent));
						beingKey = BEING_KEY.SELF;
					}
				}

				valueName = m.Groups [2].Value;

				alias = Enum.GetName (typeof(BEING_KEY), beingKey) + "_" + valueName;
			}
		}


		protected bool mIsInitialized;
		protected List<Parameter> mParameters;
		protected MonoBehaviour mParent = null;
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

		public virtual void Initialize (MonoBehaviour _parent)
		{
			mParent = _parent;
			Debug.Assert (!string.IsNullOrEmpty (FormulaText), "Formula is empty for component : " + Error.Hierarchy(mParent));

			mParameters = new List<Parameter> ();
			MatchCollection matches = ParamRegex.Matches (FormulaText);


			foreach (Match m in matches) {
				mParameters.Add (new Parameter (m, _parent));
			}


			mIsInitialized = true;

		}

		public bool HasSelfBeing () {
			return (mSelf != null);
		}

		public void SetSelfBeing (ABeing _self)
		{
			Debug.Assert (mIsInitialized, "Calling SetSelfBeing on a non-initialized formula on component " + Error.Hierarchy(mParent));
			mSelf = _self;

			foreach (Parameter p in mParameters) {
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
			Debug.Assert (mIsInitialized, "Calling SetTargetBeing on a non-initialized formula on component " + Error.Hierarchy(mParent));

			mTarget = _target;

			foreach (Parameter p in mParameters) {
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
			Debug.Assert (mIsInitialized, "Calling PrepareParameters on a non-initialized formula on component " + Error.Hierarchy(mParent));
			List<double> parameterValueList = new List<double> ();

			foreach (Parameter p in mParameters) {
				parameterValueList.Add (p.bindedValue.GetValue ());
			}


			return parameterValueList.ToArray ();
		}

	}
}