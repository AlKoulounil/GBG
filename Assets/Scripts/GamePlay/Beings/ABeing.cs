using UnityEngine;
using System.Collections.Generic;
using Calculator;
using Containers;
using Tools;
using Triggers;
using Values;

namespace Beings
{

	public enum BEING_KEY
	{
		SELF,
		TARGET,
		GROUP,
		SUM_CHARS,
		AVG_CHARS
	}

	public class ABeing : MonoBehaviour
	{
		protected ABeing mParent = null;
		protected Dictionary<string,ABeing> mDirectChildren = new Dictionary<string, ABeing> ();
		protected Dictionary<string,Container> mContainers = new Dictionary<string, Container> ();
		protected Dictionary<string,AValue> mValues = new Dictionary<string, AValue> ();
		protected Dictionary<string,Variable> mVariables = new Dictionary<string, Variable> ();
		protected bool mIsInitialized = false;
		//		protected Dictionary<string,ATrigger> trigger = new Dictionary<string, ATrigger> ();

		protected virtual void Start ()
		{
			InitializeGameplayHierarchy ();	
		}

		protected void InitializeGameplayHierarchy ()
		{
			if (mIsInitialized) {
				return;
			}

			//Initialize all child beings
			foreach (ABeing b in GetComponentsInChildren<ABeing>()) {
				if (b != this) {
					b.InitializeGameplayHierarchy ();
				}
			}

			//As all child beings has been initialized, the ones that still do not have father are direct children;
			foreach (ABeing b in GetComponentsInChildren<ABeing>()) {
				if (b != this && b.mParent == null) {
					Debug.Assert (!mDirectChildren.ContainsKey (b.name.ToLower()), 
						"Being " + Error.Hierarchy(this) + " has two direct sons having same name : " + b.name);
					mDirectChildren.Add (b.name.ToLower(), b);
					b.mParent = this;
				}
			}

			// Now that all child being have been initialized, we can initialize only containers that are direct children.
			// Containers that are children to a child being, have already been initialized by it.
			foreach (Container c in GetComponentsInChildren<Container>()) {
				if (!c.HasParent ()) {
					c.SetParentBeing (this);
					mContainers.Add (c.name.ToLower(), c);
					c.Initialize ();

					foreach (AValue v in c.GetAllValues()) {
						if (!mValues.ContainsKey (v.name.ToLower())) {
							mValues.Add (v.name.ToLower(), v);
						} else {
							Debug.LogError ("Conflicting value names in " + Error.Hierarchy(this) + " : " + v.name);
						}

					}

					foreach (Variable v in c.GetAllVariables()) {
						if (!mVariables.ContainsKey (v.name.ToLower())) {
							mVariables.Add (v.name.ToLower(), v);
						} else {
							Debug.LogError ("Conflicting variable names in " + Error.Hierarchy(this) + " : " + v.name);
						}

					}
				}
			}

			foreach (IHasFormula f in GetComponentsInChildren<IHasFormula>()) {
				if (!f.HasSelfBeing ()) {
					f.SetSelfBeing (this);
				}
			}

			mIsInitialized = true;
		}



		public AValue GetValue (string valueName)
		{
			if (mValues.ContainsKey (valueName.ToLower())) {
				return mValues [valueName.ToLower()];
			} else {
				Debug.LogError ("value " + valueName.ToLower() + " does not exist in Being " + Error.Hierarchy(this));
				return null;
			}
		}


		public Variable GetVariable (string varName)
		{
			if (mVariables.ContainsKey (varName.ToLower())) {
				return mVariables [varName.ToLower()];
			} else {
				Debug.LogError ("value " + varName.ToLower() + " does not exist in Being " + Error.Hierarchy(this));
				return null;
			}
		}

	}
}