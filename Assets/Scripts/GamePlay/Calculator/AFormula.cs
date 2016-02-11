using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Beings;
using Values;

namespace Calculator
{
	

	[System.SerializableAttribute]
	public class Formula
	{

		[Tooltip("Type here a formula, with variables with this format : ([being_key]).[value_name]")]
		public string FormulaText;

		protected class Parameter
		{
			public string valueName;
			public BEING_KEY beingKey;
			public AValue bindedValue = null;

			public Parameter (Match m, MonoBehaviour _parent) {
				string key = m.Captures[0].Value;
				if (string.IsNullOrEmpty(key)) {
					beingKey = BEING_KEY.SELF;
				} else {
					try {
						beingKey = (BEING_KEY)Enum.Parse(typeof(BEING_KEY), key.ToUpper());
					} catch {
						Debug.LogError("the being key " + key + " is not recognized in formula of object " + _parent.name);
						beingKey = BEING_KEY.SELF;
					}
				}

				valueName = m.Captures [1].Value;
			}
		}


		private bool isInitialized;
		private List<Parameter> parameters;
		private MonoBehaviour parent = null;
		private ABeing self= null;
		private ABeing target = null;

		private static Regex mParser = null;
		private static Regex Parser {
			get {
				if (mParser == null) {
					mParser = new Regex("\\b(\\w+)?\\.(\\w+)\\b");
				}
				return mParser;
			}
		}

		private void Initialize (MonoBehaviour _parent)
		{
			parent = _parent;
			Debug.Assert(string.IsNullOrEmpty(FormulaText), "Formula is empty for component : " + parent.name);

			parameters = new List<Parameter> ();
			MatchCollection matches = Parser.Matches (FormulaText);

			foreach (Match m in matches) {
				Parameter p = new Parameter (m, _parent);
			}

			isInitialized = true;
		}


		private void SetSelfBeing (ABeing _self)
		{
			Debug.Assert(isInitialized, "Calling SetSelfBeing on a non-initialized formula on component " + parent.name);
			self = _self;

			foreach(Parameter p in parameters) {
				if(p.beingKey == BEING_KEY.SELF) {
					if (_self == null) {
						p.bindedValue = null;
					} else {
						p.bindedValue = _self.GetValue (p.valueName);
					}
				}
			}
		}

		
		private void SetTargetBeing (ABeing _target)
		{
			Debug.Assert(isInitialized, "Calling SetTargetBeing on a non-initialized formula on component " + parent.name);

			target = _target;

			foreach(Parameter p in parameters) {
				if(p.beingKey == BEING_KEY.SELF) {
					if (_target == null) {
						p.bindedValue = null;
					} else {
						p.bindedValue = _target.GetValue (p.valueName);
					}
				}
			}
		}


		public bool GetBooleanResult ()
		{
			Debug.Assert(isInitialized, "Calling GetBooleanResult on a non-initialized formula on component " + parent.name);

			return false;
		}

		public float GetFloatResult ()
		{
			Debug.Assert(isInitialized, "Calling GetFloatResult on a non-initialized formula on component " + parent.name);
	
			return 0f;
		}
	}
}