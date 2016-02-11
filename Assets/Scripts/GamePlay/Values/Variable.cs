using UnityEngine;
using VarTypes;
using System;

namespace Values
{

	public class Variable : AValue
	{

		public VarType Type;
		public double Value;


		public bool HasMin = true;
		public float Minimum = 0;
		public bool HasMax = false;
		public float Maximum = 0;


		public void SetValue(double val) {
			if (Type.IsInteger) {
				this.Value = (int)Math.Floor(val);
			} else {
				this.Value = val;
			}
			TriggerOnChange();
		}

		public override double GetValue() {
			return this.Value;
		}

	}
}
