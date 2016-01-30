using UnityEngine;
using System.Collections;
using Beings;

namespace Effects
{
	public class OtherGroupGenerator : MonoBehaviour
	{

	
		public int MinGroupSize;
		public int MaxGroupSize;
		public Group OtherGroupPrefab;
		public CharacterGenerator CharacterGenerator;
		public Transform Parent;
		public Transform Ground;
	
		void OnEnable ()
		{
			Timer.OnDayPassed += CreateNewRandomOtherGroup;
		}
	
		void OnDisable ()
		{
			Timer.OnDayPassed -= CreateNewRandomOtherGroup;
		}

		void CreateNewRandomOtherGroup ()
		{
			Group newGroup = Instantiate<Group> (OtherGroupPrefab);

			// Generate position
			newGroup.transform.position = GenerateRandomPosition ();
			newGroup.transform.SetParent (Parent);

			// Group size
			int GroupSize = (int)System.Math.Floor ((double)Random.Range (MinGroupSize, MaxGroupSize) + 1);
			//Debug.Log ("New Group size : " + GroupSize.ToString ());
		
			// Create random characters
			for (int numMember = 1; numMember <= GroupSize; numMember ++) {
				Character newChar = CharacterGenerator.CreateRandomCharacter ();
				newGroup.AddCharacter (newChar);
			}

		}

		Vector3 GenerateRandomPosition ()
		{
			float maxX = Ground.transform.localScale.x;
			float maxZ = Ground.transform.localScale.z;
			float newX = Random.Range (-maxX, +maxX) * 5;
			float newZ = Random.Range (-maxX, +maxZ) * 5;
			Vector3 newPos = new Vector3 (newX, 0.5f, newZ);
			return newPos;
		}



	}
}
