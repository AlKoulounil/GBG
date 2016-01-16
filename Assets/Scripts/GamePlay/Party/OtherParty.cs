using UnityEngine;
using System.Collections;

public class OtherParty : Party, Encounters.Encounterable {

	public override void AddCharacter (Character newChar)
	{
		base.AddCharacter (newChar);

		//This is just to sort well Characters objects from the hierarchy
		newChar.transform.SetParent (this.transform);
	}

	public Party GetEncounteringParty() {
		return this;
	}
}
