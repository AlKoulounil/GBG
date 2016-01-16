using UnityEngine;
using System.Collections;

public class PlayerPartyEvents : MonoBehaviour {

	public PlayerParty Party;
	public CharacterGenerator CharacterGenerator;

	
	void OnEnable() {
		Timer.OnDayPassed += AddRandomCharacterToPlayerParty;
	}
	
	void OnDisable() {
		Timer.OnDayPassed -= AddRandomCharacterToPlayerParty;
	}

	
	// for test only
	void AddRandomCharacterToPlayerParty() {
		Character newChar = CharacterGenerator.CreateRandomCharacter();
		Party.AddCharacter (newChar);
	}
}
