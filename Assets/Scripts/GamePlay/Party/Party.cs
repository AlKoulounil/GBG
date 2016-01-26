using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Party : MonoBehaviour {

	//public events
	public delegate void PartyChanged();
	public event PartyChanged OnPartyChanged;

	protected Dictionary<string, Character> mCharacters = null;
	protected Transform mGroupComposition;

	// Use this for initialization
	void Awake () {
		mGroupComposition = transform.FindChild ("GroupComposition");
		mCharacters = new Dictionary<string, Character>();

		List<Character> characters = new List<Character> ();
		mGroupComposition.GetComponentsInChildren<Character>(characters);
		
		foreach (Character c in characters) {
			this.AddCharacter (c);
		}

		//Debug.Log("number of characters in party : " + mCharacters.Count);
	}

	public virtual void AddCharacter(Character newChar) {
		while (mCharacters.ContainsKey (newChar.name)) {
			newChar.name += "I";
		}
		mCharacters.Add(newChar.name, newChar);
		newChar.transform.SetParent (mGroupComposition);

		if (OnPartyChanged != null) {OnPartyChanged ();}
	}

	public void GiveCharacter(string name, Party otherParty) {
		otherParty.AddCharacter (mCharacters[name]);
		mCharacters.Remove (name);

		if (OnPartyChanged != null) {OnPartyChanged ();}
	}

	public List<Character> GetAllCharacters() {
		List<Character> list = new List<Character> ();
		foreach (Character c in mCharacters.Values) {
			list.Add (c);
		}
		return list;
	}

	public int GetSize() {
		return mCharacters.Count;
	}

    void OnEnable() {
        Timer.OnDayPassed += RefreshPartyStats;
    }

	void OnDisable() {
		Timer.OnDayPassed -= RefreshPartyStats;
	}



    public float GetTotalStrength()
    {
//        float total = 0.0f;
//        foreach (Character ch in mCharacters.Values)
//        {
//			total += ;
//        }
		return mCharacters.Count;
	}
	
	public virtual void RefreshPartyStats() {

	}
}
