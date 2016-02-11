using UnityEngine;
using System.Collections.Generic;

namespace Calculator {


	[System.SerializableAttribute]
	public class BoolFormula : AFormula {

		public bool GetResult ()
		{
			Debug.Assert(!isInitialized, "Calling GetBooleanResult on a non-initialized formula on component " + parent.name);

			//TODO
			return false;

		}
	}
}