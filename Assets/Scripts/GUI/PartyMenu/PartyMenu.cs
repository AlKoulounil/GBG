using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour {

	public Party PartyToDisplay;
	public Text TotalStrengthDisplay;

	// Use this for initialization
	void OnEnable () {
		DisplayMenu.OnDisplayPartyMenu += RefreshPartyDisplay;
		this.PartyToDisplay.OnPartyChanged += RefreshPartyDisplay;
	}

	void OnDisable () {
		DisplayMenu.OnDisplayPartyMenu -= RefreshPartyDisplay;
		this.PartyToDisplay.OnPartyChanged -= RefreshPartyDisplay;
	}
		
	public void RefreshPartyDisplay() {
//		foreach(Character c in PartyToDisplay.GetAllCharacters ()) {
			//TODO: UI PartyMenuItems
//		}

		this.TotalStrengthDisplay.text = "Total strength : " + this.PartyToDisplay.GetTotalStrength();
	}
}
