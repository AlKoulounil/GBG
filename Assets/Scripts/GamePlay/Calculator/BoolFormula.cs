using UnityEngine;
using System.Collections.Generic;
using Tools;

namespace Calculator {


	[System.SerializableAttribute]
	public class BoolFormula : AFormula {

		public bool GetResult ()
		{
			Debug.Assert(mIsInitialized, "Calling GetBooleanResult on a non-initialized formula on component " + Error.Hierarchy(mParent));

			//TODO
			return false;

		}
	}
}