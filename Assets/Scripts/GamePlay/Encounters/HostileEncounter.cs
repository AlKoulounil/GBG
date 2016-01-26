using UnityEngine;
using System.Collections;


namespace Encounters
{
	public class HostileEncounter : MonoBehaviour
	{

		public string TagToEncounter;
		private Party thisParty;

		void Awake ()
		{
			thisParty = this.GetComponent<Party> ();
		}


		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.tag == TagToEncounter) {
				Encounterable encounter = other.gameObject.GetComponent<Encounterable> ();
				Party otherParty = encounter.GetEncounteringParty ();

				if (otherParty == null) {
					Debug.LogError ("Encountered object does not have Party component.");
				}

				Debug.Log ("Encoutering other party of size " + otherParty.GetSize () + " with " + thisParty.GetSize () + " members.");

				if (IsHostile (otherParty)) {
					Fight (otherParty);
				}
			}

		}

		private bool IsHostile (Party otherParty)
		{
			return true;
		}

		private void Fight (Party otherParty)
		{
			int comparison = otherParty.GetTotalStrength ().CompareTo (thisParty.GetTotalStrength ());
				switch (comparison) {
				case -1:
					FightResult (thisParty, otherParty);
					break;
				case 1:
					FightResult (otherParty, thisParty);
					break;
				case 0:
					Debug.Log ("Deuce.");
					break;
				default:
					Debug.LogError ("Unknown comparison result : " + comparison);
					break;
			}
		}

		private static void FightResult(Party winningParty, Party losingParty) {
			foreach (Character perso in losingParty.GetAllCharacters()) {
				losingParty.GiveCharacter (perso.name, winningParty);
			}

			Destroy (losingParty.gameObject);
		}
	}
}
