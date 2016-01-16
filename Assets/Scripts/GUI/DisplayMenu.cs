using UnityEngine;
using System.Collections;

public class DisplayMenu : MonoBehaviour {

	public GameObject InGameMenu;
	public GameObject PartyMenu;

	// Use this for initialization
	void Awake () {
		if (InGameMenu == null) {
			Debug.LogError ("InGameMenu is not set in DisplayMenu script.");
		}
		
		if (PartyMenu == null) {
			Debug.LogError ("PartyMenu is not set in DisplayMenu script.");
		}

		PartyMenu.SetActive (false);
		InGameMenu.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("PartyMenu")) {
			Timer.instance.Pause = true;
			PartyMenu.SetActive (true);
			InGameMenu.SetActive (false);
			if (OnDisplayPartyMenu != null) {OnDisplayPartyMenu ();}
		} else if (Input.GetButtonUp  ("PartyMenu")) {
			PartyMenu.SetActive (false);
			InGameMenu.SetActive (true);
			Timer.instance.Pause = false;
		}
	}

		//public events
	public delegate void DisplayPartyMenu();
	public static event DisplayPartyMenu OnDisplayPartyMenu;
}
