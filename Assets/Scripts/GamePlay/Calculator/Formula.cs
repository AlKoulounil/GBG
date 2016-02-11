using UnityEngine;
using System.Collections.Generic;
using Beings;

namespace Calculator
{
	
	public enum STORAGE_KEYS {
		self,
		other,
		group,
		sum_chars,
		avg_chars
	}

	[System.SerializableAttribute]
	public class Formula
	{
		public string FormulaText;

		private bool isInitialized;
		private List<string> values;

		private void Initialize () {
			//TODO : fill values list (use regex)
			isInitialized = true;
		}

		private void SetSelfBeing (ABeing self) {
			//TODO : match values list with actual value and prepare the calculation with them
		}
		
		
		private void SetOtherBeing (ABeing other) {
			//TODO : match values list with actual value and prepare the calculation with them
		}


		public bool GetBooleanResult () {
			if (! isInitialized) {
				Initialize ();
			}

			return false;
		}

		public float GetFloatResult () {
			if (! isInitialized) {
				Initialize ();
			}

			return 0f;
		}
	}
}