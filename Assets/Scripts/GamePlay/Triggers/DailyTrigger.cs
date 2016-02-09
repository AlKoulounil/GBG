using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VarTypes;

namespace Triggers
{
	public class DailyTrigger : ATrigger
	{
	
		public int DayFrequency = 1;

		private int mDaysSinceLast = 0;

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
				this.Go ();
			}
		}
	}
}
