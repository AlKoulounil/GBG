using UnityEngine;
using VarTypes;
using System;

namespace Values
{

	public class Variable : AValue
	{
		
		public double Value;


		public bool HasMin = true;
		public float Minimum = 0;
		public bool HasMax = false;
		public float Maximum = 0;
		public bool IsInteger = true;


		public void SetValue(double val) {
			if (this.IsInteger) {
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
