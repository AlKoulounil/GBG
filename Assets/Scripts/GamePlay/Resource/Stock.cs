using UnityEngine;
using System.Collections;


namespace Resource
{

	public class Stock : MonoBehaviour
	{

		public Resource Type;
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
		}
	}
}
