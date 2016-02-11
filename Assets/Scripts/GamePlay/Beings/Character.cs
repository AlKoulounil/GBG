using UnityEngine;

namespace Beings
{
	public class Character : ABeing
	{
	    
		public string CharName {
			get {
				return name;
			}
			set {
				//Name in the game
				this.name = value;

				if (OnNameChanged != null)
					OnNameChanged (name);
			}

		}

		//public events
		public delegate void NameChanged (string newName);

		public event NameChanged OnNameChanged;
	

		// Use this for initialization
		void Awake ()
		{
			if (this.name == string.Empty) {
				this.name = "No Name";
			}
		}
	

		public void Die ()
		{
			Debug.Log (name + " has died.");
			DestroyObject (this);
		}
	}
}
