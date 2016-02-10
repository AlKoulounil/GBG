using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Effects;
using VarTypes;
using Beings;


namespace Triggers
{
	public enum STORAGE_KEYS {
		SELF,
		OTHER
	}


	public abstract class ATrigger : MonoBehaviour
	{
		protected List<AEffect> mEffects;
		protected Dictionary<STORAGE_KEYS, ABeing> mStorageKeys = new Dictionary<STORAGE_KEYS, ABeing> ();

		protected ABeing parentBeing;

		void onStart() {

			mEffects = new List<AEffect>( this.GetComponents<AEffect>());
		}

		public void setParentBeing(ABeing parent) {
			parentBeing = parent;
			mStorageKeys.Add(STORAGE_KEYS.SELF, parent);
		}

		public virtual void Go() {
			foreach (AEffect effect in mEffects) {
				effect.Apply (mStorageKeys);
			}
		}

	}
}
