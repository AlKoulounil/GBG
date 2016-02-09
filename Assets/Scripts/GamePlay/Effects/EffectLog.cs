using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;

namespace Effects
{
	public class EffectLog : AEffect
	{
		public string Message = "Type message to Log Here";

		public override void Apply(Dictionary<STORAGE_KEYS, Container> targets) {
			Debug.Log (Message);
		}
	}
}

