using UnityEngine;
using System.Collections;

namespace GUI
{
	public class DisplayMenu : MonoBehaviour
	{

		public GameObject InGameMenu;
		public GameObject GroupMenu;

		// Use this for initialization
		void Awake ()
		{
			if (InGameMenu == null) {
				Debug.LogError ("InGameMenu is not set in DisplayMenu script.");
			}
		
			if (GroupMenu == null) {
				Debug.LogError ("GroupMenu is not set in DisplayMenu script.");
			}

			GroupMenu.SetActive (false);
			InGameMenu.SetActive (true);
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetButtonDown ("GroupMenu")) {
				Timer.instance.Pause = true;
				GroupMenu.SetActive (true);
				InGameMenu.SetActive (false);
				if (OnDisplayGroupMenu != null) {
					OnDisplayGroupMenu ();
				}
			} else if (Input.GetButtonUp ("GroupMenu")) {
				GroupMenu.SetActive (false);
				InGameMenu.SetActive (true);
				Timer.instance.Pause = false;
			}
		}

		//public events
		public delegate void DisplayGroupMenu ();

		public static event DisplayGroupMenu OnDisplayGroupMenu;
	}
}