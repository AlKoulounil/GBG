using UnityEngine;
using System.Collections.Generic;
using Beings;
using Values;
using Triggers;

namespace Containers
{
	public class Container : MonoBehaviour
	{

		public ABeing ParentBeing = null;
		protected List<AValue> values = new List<AValue> ();
//		protected Dictionary<string,ATrigger> trigger = new Dictionary<string, ATrigger> ();

		void Start ()
		{
			if (ParentBeing == null) {
				Debug.LogError ("container " + this.name + " has no Parent Being.");
			}
			
			//Get all child values
			foreach (AValue v in GetComponentsInChildren<AValue>()) {
				values.Add (v);
			}

//			//Get all child triggers
//			foreach (ATrigger t in GetComponentsInChildren<ATrigger>()) {
//				values.Add (t.ValueName, v);
//			}

			ParentBeing.AddContainer (this);
		}

		public List<AValue> getAllValues ()
		{
			return values;
		}


	}
}
