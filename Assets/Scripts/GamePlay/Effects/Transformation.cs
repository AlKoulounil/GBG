using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;
using Resources;


namespace Effects
{
	public class Transformation : MonoBehaviour
	{
		public const float MAX_QUANTITY = -1;

		public STORAGE_KEYS Input;
		public STORAGE_KEYS Output;
		public float QuantityPerRun = 1;

		[System.SerializableAttribute]
		public class InOutResource
		{
			public Resource ResourceType;
			public float Quantity;

		}

		public InOutResource[] ResourceInputs;
		public InOutResource[] ResourceOutputs;

		public void Run(Dictionary<STORAGE_KEYS, Storage> targets) {
			//TODO
		}

	}
}
