using UnityEngine;
using System.Collections;

public class OtherPartyGenerator : MonoBehaviour {

	
	public int MinPartySize;
	public int MaxPartySize;
	
	
	public OtherParty OtherPartyPrefab;
	public CharacterGenerator CharacterGenerator;
	public Transform Parent;
	public Transform Ground; 

	
	void OnEnable() {
		Timer.OnDayPassed += CreateNewRandomOtherParty;
	}
	
	void OnDisable() {
		Timer.OnDayPassed -= CreateNewRandomOtherParty;
	}

	void CreateNewRandomOtherParty () {
		OtherParty newParty = Instantiate<OtherParty> (OtherPartyPrefab);

		// Generate position
		newParty.transform.position = GenerateRandomPosition ();
		newParty.transform.SetParent (Parent);

		// Party size
		int partySize = (int)System.Math.Floor ((double)Random.Range (MinPartySize, MaxPartySize)+1);
		//Debug.Log ("New party size : " + partySize.ToString ());
		
		// Create random characters
		for(int numMember = 1; numMember <= partySize; numMember ++) {
			Character newChar = CharacterGenerator.CreateRandomCharacter();
			newParty.AddCharacter (newChar);
		}

	}

	Vector3 GenerateRandomPosition() {
		float maxX = Ground.transform.localScale.x;
		float maxZ = Ground.transform.localScale.z;
		float newX = Random.Range (-maxX, +maxX) * 5;
		float newZ = Random.Range (-maxX, +maxZ) * 5;
		Vector3 newPos = new Vector3(newX, 0.5f, newZ);
		return newPos;
	}





}
