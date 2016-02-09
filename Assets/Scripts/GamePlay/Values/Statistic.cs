using UnityEngine;
using System.Collections;
using Conditions;
using VarTypes;

namespace Values
{
	public class Statistic : AValue
	{

		public VarType Type;
		public string Name;

		[Tooltip ("Free written formula to be computed at each call of GetValue")]
		public string Formula;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private AValue[] mUsedValues;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		protected float Value = -1;

		void Update ()
		{
			//TODO : Update seulement en mode Debug
		}

		public override float GetValue() {
			float oldValue = Value;
			//TODO
			if (Value != oldValue) {
				TriggerOnChange();
			}
			return Value;
		}

		public override  string GetName() {
			return Name;
		}
	}
}
