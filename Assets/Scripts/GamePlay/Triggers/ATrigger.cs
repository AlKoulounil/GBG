using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Effects;
using VarTypes;
using Containers;


namespace Triggers
{
	public enum STORAGE_KEYS {
		SELF,
		OTHER
	}


	public abstract class ATrigger : MonoBehaviour
	{
		protected List<AEffect> mEffects;
		private Dictionary<STORAGE_KEYS, Container> mStorageKeys;

		void onAwake() {
			mStorageKeys = new Dictionary<STORAGE_KEYS, Container> ();
			Container self = this.GetComponentInParent<Container> ();
			mStorageKeys.Add(STORAGE_KEYS.SELF, self);

			mEffects = new List<AEffect>( this.GetComponents<AEffect>());
		}

		public virtual void Go() {
			foreach (AEffect effect in mEffects) {
				effect.Apply (mStorageKeys);
			}
		}

	}
}
