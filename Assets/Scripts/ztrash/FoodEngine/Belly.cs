using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public float belly = 100f;
	public float rations = 10f;

	public float ATTRITION = 0.9f;
	public float STRENGTH_PER_FOOD = 0.01f;

	public Character character = null;

	// Use this for initialization
	void Start () {
		Timer.OnDayPassed += FoodConsumption;
		character = GetComponent<Character> ();
	}

	public void FoodConsumption() {
		belly = belly * ATTRITION + rations;
	}

	public float StrengthBonus() {
		return belly * STRENGTH_PER_FOOD;
	}
}
