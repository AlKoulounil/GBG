using UnityEngine;
using Containers;

namespace Values
{


	public abstract class AValue : MonoBehaviour 
	{


		public abstract double GetValue ();
		protected Container parentContainer;

		public delegate void OnChange();
		public event OnChange Change;
		
		protected void TriggerOnChange() {
			Change ();
		}

		public void SetParentContainer(Container c) {
			parentContainer = c;
		}
	}
}
