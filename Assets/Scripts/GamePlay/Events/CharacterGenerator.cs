using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour {

	
	public NonPlayerCharacter CharacterPrefab;
	
	public int MinCharStrength;
	public int MaxCharStrength;
	public string[] Names;
		
	public Character CreateRandomCharacter() {
		NonPlayerCharacter c = Instantiate<NonPlayerCharacter>(CharacterPrefab);
		c.enabled = false;
		
		int strength = (int)System.Math.Floor ((double)Random.Range (MinCharStrength, MaxCharStrength)+1);
		c.Skilled.Skills[(int)Skill.ALL_SKILLS.STR].Value = strength;
		
		int nameIdx = (int)System.Math.Floor ((double)Random.Range (0, Names.Length));
		c.CharName = Names [nameIdx];
		
		return c;
	}
}
