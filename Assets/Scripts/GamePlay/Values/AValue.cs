﻿using UnityEngine;
using System.Collections;

namespace Values
{


	public abstract class AValue : MonoBehaviour 
	{

		public abstract float GetValue ();

		public abstract string GetName ();


		public delegate void OnChange();
		public event OnChange Change;
		
		protected void TriggerOnChange() {
			Change ();
		}
	}
}