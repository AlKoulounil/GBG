using UnityEngine;
using System.Collections.Generic;
using Containers;
using Values;
using Triggers;

namespace Beings
{

	public enum BEING_KEY {
		SELF,
		TARGET,
		GROUP,
		SUM_CHARS,
		AVG_CHARS
	}

	public class ABeing : MonoBehaviour
	{

		protected Dictionary<string,ABeing> childrenBeings  = new Dictionary<string, ABeing> ();
		protected Dictionary<string,Container> containers = new Dictionary<string, Container> ();
		protected Dictionary<string,AValue> values = new Dictionary<string, AValue> ();
//		protected Dictionary<string,ATrigger> trigger = new Dictionary<string, ATrigger> ();

		protected virtual void Start () {
						
			//Get all child beings
			foreach (ABeing b in GetComponentsInChildren<ABeing>()) {
				childrenBeings.Add (b.name, b);
			}
		}

		public void AddContainer (Container c) {
			containers.Add (c.name, c);

			foreach (AValue v in c.getAllValues()) {
				if (! values.ContainsKey (v.name)) {
					values.Add (v.name, v);
				} else {
					Debug.LogError ("Conflicting value names in " + this.name + " : " + v.name);
				}

			}
			
//			Debug.Log ("Being " + this.name + " added container " + c.name + " with " + c.getAllValues().Count + " values. ");
//			Debug.Log ("Being " + this.name + " now has " + values.Count + " values. ");
		}

		public AValue GetValue (string valueName) {
			if (values.ContainsKey (valueName)) {
				return values [valueName];
			} else {
				Debug.LogError ("value " + valueName + " does not exist in Being " + this.name);
				return null;
			}
		}

	}
}