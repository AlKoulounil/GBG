using UnityEngine;
using System;
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
						Debug.LogError ("the being key " + key + " is not recognized in formula of object " + _parent.name);
						beingKey = BEING_KEY.SELF;
					}
				}

				valueName = m.Groups [2].Value;

				alias = Enum.GetName (typeof(BEING_KEY), beingKey) + "_" + valueName;
			}
		}


		protected bool isInitialized;
		protected List<Parameter> parameters;
		protected MonoBehaviour parent = null;
		protected ABeing self = null;
		protected ABeing target = null;

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
			parent = _parent;
			Debug.Assert (!string.IsNullOrEmpty (FormulaText), "Formula is empty for component : " + parent.name);

			parameters = new List<Parameter> ();
			MatchCollection matches = ParamRegex.Matches (FormulaText);


			foreach (Match m in matches) {
				parameters.Add (new Parameter (m, _parent));
			}


			isInitialized = true;

		}


		public void SetSelfBeing (ABeing _self)
		{
			Debug.Assert (!isInitialized, "Calling SetSelfBeing on a non-initialized formula on component " + parent.name);
			self = _self;

			foreach (Parameter p in parameters) {
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
			Debug.Assert (!isInitialized, "Calling SetTargetBeing on a non-initialized formula on component " + parent.name);

			target = _target;

			foreach (Parameter p in parameters) {
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
			Debug.Assert (!isInitialized, "Calling PrepareParameters on a non-initialized formula on component " + parent.name);
			List<double> parameterValueList = new List<double> ();

			foreach (Parameter p in parameters) {
				parameterValueList.Add (p.bindedValue.GetValue ());
			}


			return parameterValueList.ToArray ();
		}

	}
}