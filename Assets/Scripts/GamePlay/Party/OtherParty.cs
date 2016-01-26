using UnityEngine;
using System.Collections;

public class OtherParty : Party, Encounters.Encounterable {

	public override void AddCharacter (Character newChar)
	{
		base.AddCharacter (newChar);
	}

	public Party GetEncounteringParty() {
		return this;
	}
}
