using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;


namespace Resources
{
	public class Transformation : MonoBehaviour
	{
		public const float MAX_QUANTITY = -1;

		public STORAGE_KEYS Input;
		public STORAGE_KEYS Output;
		public float QuantityPerRun = 1;
		public float Probability = 1f;

		public void Run(Dictionary<STORAGE_KEYS, Resources.Storage> targets) {
			//TODO
		}

	}
}
