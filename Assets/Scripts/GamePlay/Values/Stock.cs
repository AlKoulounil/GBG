using UnityEngine;
using System.Collections;
using Resources;


namespace Values
{

	public class Stock : MonoBehaviour, IValue
	{

		public Resource ResourceDefinition;
		public float Value;


		public bool HasMin = true;
		public float Minimum = 0;
		public bool HasMax = false;
		public float Maximum = 0;

		public event OnChange HasChanged;

		public void SetValue(float val) {
			if (ResourceDefinition.IsInteger) {
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
			return ResourceDefinition.ResourceName;
		}
	}
}
