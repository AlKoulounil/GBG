using UnityEngine;
using System.Collections;
using Values;

namespace Conditions
{
	public class ConditionCompare : MonoBehaviour, ICondition
	{
		
		[Tooltip ("Free written formula to be computed at each call of GetValue")]
		public string Formula;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		private bool Value = true;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private IValue[] mUsedValues;


		void Awake ()
		{
			//TODO : Initialise mUsedValues from Formula
		}


		public bool AllowsEffect() {
			return Value;
		}
	}
}