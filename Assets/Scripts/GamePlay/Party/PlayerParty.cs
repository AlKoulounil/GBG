using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerParty : Party, Encounters.Encounterable
{


   	// Use this for initialization
	void Start () {

	}

	public Party GetEncounteringParty() {
		return this;
	}



}
