using UnityEngine;
using System.Collections;
using Values;
using Resources;

namespace Conditions
{
	public class ConditionStraightRoll : MonoBehaviour, ICondition
	{

		public Resource InputValue;

		[Tooltip("Max value for which probability should be 0%")]
		public float LowValue;

		[Tooltip("Min value for which probability should be 100%")]
		public float HighValue;

		[Tooltip("Read-only, only useful to see current probability.")]
		[SerializeField]
		private float Probability;

		public bool AllowsEffect() {
			return false;
		}
	}
}
