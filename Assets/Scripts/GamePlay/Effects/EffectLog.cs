using UnityEngine;
using System.Collections.Generic;
using Calculator;
using Beings;

namespace Effects
{
	public class EffectLog : AEffect
	{
		public string Message = "Type message to Log Here";

		public override void Apply(Context targets) {
			Debug.Log (Message);
		}
	}
}

