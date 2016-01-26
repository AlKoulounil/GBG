using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
	    
	public string mName;
	public string CharName {
		get{
			return mName;
		}
		set {
			//Name in the game
			this.mName = value;

			//Name in Unity
			this.name = mName;

			if (OnNameChanged != null)
				OnNameChanged (mName);
		}

	}

	//public events
	public delegate void NameChanged(string newName);
	public event NameChanged OnNameChanged;
	

	// Use this for initialization
	void Awake () {
		if (mName == string.Empty) {
			mName = "No Name";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die() {
		Debug.Log (name + " has died.");
		DestroyObject (this);
	}
}
