using UnityEngine;
using Conditions;
using VarTypes;
using Calculator;
using Beings;

namespace Values
{
	public class Statistic : AValue, IHasFormula
	{

		public VarType Type;

		[Tooltip ("Free written formula to be computed at each call of GetValue")]
		public FloatFormula Formula;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private AValue[] mUsedValues;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		protected double Value = -1;

		void Update ()
		{
			//TODO : Update seulement en mode Debug
		}

		public override double GetValue() {
			double oldValue = Value;
			//TODO
			if (Value != oldValue) {
				TriggerOnChange();
			}
			return Value;
		}

		void Start() {
			Formula.Initialize (this);
		}


		public void SetSelfBeing (ABeing _self) {
			Formula.SetSelfBeing (_self);
		}

		public void SetTargetBeing (ABeing _target) {
			Formula.SetTargetBeing (_target);
		}

	}
}
