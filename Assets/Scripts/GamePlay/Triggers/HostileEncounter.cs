using UnityEngine;
using System.Collections;
using Beings;


namespace Encounters
{
	public class HostileEncounter : MonoBehaviour
	{

		public string TagToEncounter;
		private Group thisGroup;

		void Awake ()
		{
			thisGroup = this.GetComponent<Group> ();
		}


		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.tag == TagToEncounter) {
				Encounterable encounter = other.gameObject.GetComponent<Encounterable> ();
				Group otherGroup = encounter.GetEncounteringGroup ();

				if (otherGroup == null) {
					Debug.LogError ("Encountered object does not have Group component.");
				}

				Debug.Log ("Encoutering other Group of size " + otherGroup.GetSize () + " with " + thisGroup.GetSize () + " members.");

				if (IsHostile (otherGroup)) {
					Fight (otherGroup);
				}
			}

		}

		private bool IsHostile (Group otherGroup)
		{
			return true;
		}

		private void Fight (Group otherGroup)
		{
			int comparison = otherGroup.GetTotalStrength ().CompareTo (thisGroup.GetTotalStrength ());
				switch (comparison) {
				case -1:
					FightResult (thisGroup, otherGroup);
					break;
				case 1:
					FightResult (otherGroup, thisGroup);
					break;
				case 0:
					Debug.Log ("Deuce.");
					break;
				default:
					Debug.LogError ("Unknown comparison result : " + comparison);
					break;
			}
		}

		private static void FightResult(Group winningGroup, Group losingGroup) {
			foreach (Character perso in losingGroup.GetAllCharacters()) {
				losingGroup.GiveCharacter (perso.name, winningGroup);
			}

			Destroy (losingGroup.gameObject);
		}
	}
}
