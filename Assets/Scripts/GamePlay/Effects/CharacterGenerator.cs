using UnityEngine;
using System.Collections;
using Beings;

namespace Effects
{
	public class CharacterGenerator : MonoBehaviour
	{

	
		public Character CharacterPrefab;
		public int MinCharStrength;
		public int MaxCharStrength;
		public string[] Names;
		
		public  Character CreateRandomCharacter ()
		{
			Character c = Instantiate<Character> (CharacterPrefab);
						
			int nameIdx = (int)System.Math.Floor ((double)Random.Range (0, Names.Length));
			c.CharName = Names [nameIdx];
		
			return c;
		}
	}
}
