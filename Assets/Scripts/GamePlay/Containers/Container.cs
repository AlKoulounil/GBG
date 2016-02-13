using UnityEngine;
using System.Collections.Generic;
using Tools;
using Beings;
using Values;
using Triggers;
using Calculator;

namespace Containers
{
	public class Container : MonoBehaviour
	{
		
		protected ABeing mParent = null;
		protected List<AValue> mValues = null;
		protected bool mInitialized = false;
//		protected Dictionary<string,ATrigger> trigger = new Dictionary<string, ATrigger> ();

		public void SetParentBeing(ABeing parent) {
			mParent = parent;
		}

		public bool HasParent() {
			return (mParent != null);
		}

		public void Initialize() {
			if (mInitialized) {
				return;
			}
			mValues = new List<AValue>();

			//Retrieve all child values
			foreach (AValue v in GetComponentsInChildren<AValue>()) {
				mValues.Add (v);
				v.SetParentContainer (this);
			}

			//Set self being to all formulas
			foreach (IHasFormula f in GetComponentsInChildren<IHasFormula>()) {
				f.Initialize();
			}

			mInitialized = true;
		}

		public List<AValue> GetAllValues ()
		{
			Debug.Assert(mInitialized , "Container " + Error.Hierarchy(this) + " has not been initialized when calling GetAllValues");
			return mValues;
		}

		public void SetSelfToAllFormula() {
			Debug.Assert(mInitialized , "Container " + Error.Hierarchy(this) + " has not been initialized when calling SetSelfToAllFormula");

			//Set self being to all formulas
			foreach (IHasFormula f in GetComponentsInChildren<IHasFormula>()) {
				f.SetSelfBeing (mParent);
			}
		}


	}
}
