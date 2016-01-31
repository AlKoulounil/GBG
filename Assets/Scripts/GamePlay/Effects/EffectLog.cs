using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;

namespace Effects
{
	public class EffectLog : MonoBehaviour, IEffect
	{
		public string Message = "Type message to Log Here";

		public void Apply(Dictionary<STORAGE_KEYS, Storage> targets) {
			Debug.Log (Message);
		}
	}
}

