using UnityEngine;
using Conditions;
using VarTypes;
using Calculator;
using Beings;

namespace Values
{
	public class Statistic : AValue, IHasFormula, IFormulaParent
	{
		
		[Tooltip ("Type here a formula, with variables with this format : ([being_key]).[value_name]")]
		public string FormulaText;

		protected FloatFormula Formula;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private AValue[] mUsedValues;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		protected double Value = -1;

		public override double GetValue() {
			double oldValue = Value;

			Value = Formula.GetResult ();

			if (Value != oldValue) {
				TriggerOnChange();
			}
			return Value;
		}

		public void Initialize() {
			Formula = new FloatFormula ();
			Formula.Initialize (this);
		}

		public bool HasSelfBeing () {
			return Formula.HasSelfBeing ();
		}

		public void SetSelfBeing (ABeing _self) {
			Formula.SetSelfBeing (_self);
			foreach(AValue v in Formula.GetAllBindedValues()) {
				v.Change += Refresh;
			}
		}

		public void SetTargetBeing (ABeing _target) {
			Formula.SetTargetBeing (_target);
		}

		void Refresh() {
			GetValue ();
		}

		public Component GetComponent(){
			return this;
		}

		public string GetFormulaText() {
			return FormulaText;
		}
	}
}
