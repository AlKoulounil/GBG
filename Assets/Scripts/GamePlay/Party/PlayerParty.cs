using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : Party, Encounters.Encounterable
{

	public PartyMenu InitializingMenu;

	public override void AddCharacter (Character newChar)
	{
		base.AddCharacter (newChar);
		newChar.enabled = true;

		//Characters from player object should be displayed in the menu
		newChar.transform.SetParent (InitializingMenu.transform);
	}

   	// Use this for initialization
	void Start () {
		mCharacters = new Dictionary<string, Character>();
		List<Character> characters = new List<Character> ();
		InitializingMenu.GetComponentsInChildren<Character>(characters);

		foreach (Character c in characters) {
			this.AddCharacter (c);
		}

		//Debug.Log("number of characters in party : " + mCharacters.Count);
	}

	public Party GetEncounteringParty() {
		return this;
	}



}
