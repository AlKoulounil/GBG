using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Trigger
{
	public class DailyTrigger : MonoBehaviour, ITrigger
	{
		public event Trigger OnTrigger;
		public int DayFrequency = 1;

		private int mDaysSinceLast = 0;
		private Dictionary<STORAGE_KEYS, Resource.Storage> mStorageKeys;

		void onAwake() {
			mStorageKeys = new Dictionary<STORAGE_KEYS, Resource.Storage> ();
			Resource.Storage self = this.GetComponentInParent<Resource.Storage> ();
			mStorageKeys.Add(STORAGE_KEYS.SELF, self);
		}

		void onEnable() {
			mDaysSinceLast = 0;
			Timer.OnDayPassed += DayPassed;
		}
		void onDisable() {
			Timer.OnDayPassed -= DayPassed;
		}

		public void DayPassed() {
			mDaysSinceLast += 1;

			if (mDaysSinceLast >= DayFrequency) {
				mDaysSinceLast = 0;
				OnTrigger (mStorageKeys);
			}
		}
	}
}
