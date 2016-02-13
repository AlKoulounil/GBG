using UnityEngine;
using Values;

namespace Conditions
{
	public class ConditionCompare : ACondition
	{
		
		[Tooltip ("Free written formula to be computed at each call of GetValue")]
		public string Formula;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		private bool Value = true;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private AValue[] mUsedValues;


		void Awake ()
		{
			//TODO : Initialise mUsedValues from Formula
		}


		public override bool AllowsEffect() {
			return Value;
		}
	}
}