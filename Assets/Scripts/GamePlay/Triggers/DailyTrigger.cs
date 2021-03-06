﻿using UnityEngine;
using System.Collections.Generic;
using VarTypes;

namespace Triggers
{
	public class DailyTrigger : ATrigger
	{
	
		public int DayFrequency = 1;

		private int mDaysSinceLast = 0;

		protected override void Start() {
			base.Start ();
			if (this.enabled) {
				mDaysSinceLast = 0;
				Timer.OnDayPassed += DayPassed;
			}
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
				this.Go (null);
			}
		}
	}
}
