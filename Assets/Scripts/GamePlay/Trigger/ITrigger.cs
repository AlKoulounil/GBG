using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Trigger
{
	public enum STORAGE_KEYS {
		SELF,
		OTHER
	}

	public delegate void Trigger(Dictionary<STORAGE_KEYS, Resource.Storage> targets);

	public interface ITrigger
	{

		//public events
		event Trigger OnTrigger;
	}
}
