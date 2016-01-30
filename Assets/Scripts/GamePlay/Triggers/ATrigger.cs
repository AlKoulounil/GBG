using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Effects;
using Resources;
using Containers;


namespace Triggers
{
	public enum STORAGE_KEYS {
		SELF,
		OTHER
	}


	public abstract class ATrigger : MonoBehaviour
	{
		protected List<Transformation> mTranformations;
		private Dictionary<STORAGE_KEYS, Storage> mStorageKeys;

		void onAwake() {
			mStorageKeys = new Dictionary<STORAGE_KEYS, Storage> ();
			Storage self = this.GetComponentInParent<Storage> ();
			mStorageKeys.Add(STORAGE_KEYS.SELF, self);

			mTranformations = new List<Transformation>( this.GetComponents<Transformation>());
		}

		public virtual void Go() {
			foreach (Transformation transform in mTranformations) {
				transform.Run (mStorageKeys);
			}
		}

	}
}
