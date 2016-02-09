using UnityEngine;
using System.Collections;
using VarTypes;


namespace Values
{

	public class Variable : AValue
	{

		public VarType Type;
		public float Value;


		public bool HasMin = true;
		public float Minimum = 0;
		public bool HasMax = false;
		public float Maximum = 0;


		public void SetValue(float val) {
			if (Type.IsInteger) {
				this.Value = (int)Mathf.Floor (val);
			} else {
				this.Value = val;
			}
			TriggerOnChange();
		}

		public override float GetValue() {
			return this.Value;
		}

		public override string GetName() {
			return Type.ResourceName;
		}
	}
}
