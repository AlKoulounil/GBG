using UnityEngine;
using System.Collections.Generic;
using Effects;
using VarTypes;
using Beings;
using Calculator;


namespace Triggers
{

	public abstract class ATrigger : MonoBehaviour
	{
		protected List<AEffect> mEffects;

		protected ABeing parentBeing;

		protected virtual void Start() {
			mEffects = new List<AEffect>( this.GetComponents<AEffect>());
		}

		public void setParentBeing(ABeing parent) {
			parentBeing = parent;
		}

		public void Go(ABeing target) {
			foreach (AEffect effect in mEffects) {
				effect.Apply (target);
			}
		}

	}
}
