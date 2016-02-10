using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Beings;

namespace Effects
{
	public class EffectLog : AEffect
	{
		public string Message = "Type message to Log Here";

		public override void Apply(Dictionary<STORAGE_KEYS, ABeing> targets) {
			Debug.Log (Message);
		}
	}
}

