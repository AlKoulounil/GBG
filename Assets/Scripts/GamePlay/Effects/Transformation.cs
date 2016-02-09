﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;
using VarTypes;


namespace Effects
{
	public class Transformation : AEffect
	{
		public const float MAX_QUANTITY = -1;

		public STORAGE_KEYS Input;
		public STORAGE_KEYS Output;
		public float QuantityPerRun = 1;

		[System.SerializableAttribute]
		public class InOutResource
		{
			public VarType Type;
			public float Quantity;

		}

		public InOutResource[] ResourceInputs;
		public InOutResource[] ResourceOutputs;

		public override void Apply(Dictionary<STORAGE_KEYS, Container> targets) {
			//TODO
		}

	}
}
