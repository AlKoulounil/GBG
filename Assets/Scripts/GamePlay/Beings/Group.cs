using UnityEngine;
using System.Collections.Generic;

namespace Beings
{
	public class Group : ABeing
	{

		//public events
		public delegate void GroupChanged ();

		public event GroupChanged OnGroupChanged;

		protected Dictionary<string, Character> mCharacters = null;
		protected Transform mGroupComposition;

		// Use this for initialization
		void Awake ()
		{
			mGroupComposition = transform.FindChild ("GroupComposition");
			mCharacters = new Dictionary<string, Character> ();

			List<Character> characters = new List<Character> ();
			mGroupComposition.GetComponentsInChildren<Character> (characters);
		
			foreach (Character c in characters) {
				this.AddCharacter (c);
			}

			//Debug.Log("number of characters in Group : " + mCharacters.Count);
		}

		public virtual void AddCharacter (Character newChar)
		{
			while (mCharacters.ContainsKey (newChar.name.ToLower())) {
				newChar.name += "I";
			}
			mCharacters.Add (newChar.name.ToLower(), newChar);
			newChar.transform.SetParent (mGroupComposition);

			if (OnGroupChanged != null) {
				OnGroupChanged ();
			}
		}

		public void GiveCharacter (string name, Group otherGroup)
		{
			otherGroup.AddCharacter (mCharacters [name.ToLower()]);
			mCharacters.Remove (name.ToLower());

			if (OnGroupChanged != null) {
				OnGroupChanged ();
			}
		}

		public List<Character> GetAllCharacters ()
		{
			List<Character> list = new List<Character> ();
			foreach (Character c in mCharacters.Values) {
				list.Add (c);
			}
			return list;
		}

		public int GetSize ()
		{
			return mCharacters.Count;
		}

		void OnEnable ()
		{
			Timer.OnDayPassed += RefreshGroupStats;
		}

		void OnDisable ()
		{
			Timer.OnDayPassed -= RefreshGroupStats;
		}

		public float GetTotalStrength ()
		{
//        float total = 0.0f;
//        foreach (Character ch in mCharacters.Values)
//        {
//			total += ;
//        }
			return mCharacters.Count;
		}
	
		public virtual void RefreshGroupStats ()
		{

		}
	}
}
