using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Beings;
using Values;


namespace Effects
{
	public class Transformation : AEffect
	{
		public const float MAX_QUANTITY = -1;

		public float QuantityPerRun = 1;

		[System.SerializableAttribute]
		public class InOutVariable
		{
			public string VariableName;
			public float Quantity;
			public STORAGE_KEYS Destination;

		}

		public InOutVariable[] Inputs;
		public InOutVariable[] Outputs;

		public override void Apply(Dictionary<STORAGE_KEYS, ABeing> targets) {
			//TODO
		}

	}
}
