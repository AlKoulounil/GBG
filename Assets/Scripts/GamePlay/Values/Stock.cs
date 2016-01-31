using UnityEngine;
using System.Collections;
using Resources;


namespace Values
{

	public class Stock : MonoBehaviour, IValue
	{

		public Resource Res;
		public float Value;


		public bool HasMin = true;
		public float Minimum = 0;
		public bool HasMax = false;
		public float Maximum = 0;

		public event OnChange HasChanged;

		public void SetValue(float val) {
			if (Res.IsInteger) {
				this.Value = (int)Mathf.Floor (val);
			} else {
				this.Value = val;
			}
			HasChanged ();
		}

		public float GetValue() {
			return this.Value;
		}

		public string GetName() {
			return Res.ResourceName;
		}
	}
}
