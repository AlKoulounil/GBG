using UnityEngine;
using System.Collections;

public abstract class Desire : MonoBehaviour {

	// Character stats for the desire
	public float expectance;
	public float interest;
	public float habituation;

	// Character scores
	public float accomplishment;
	public float satisfaction;
	
	public abstract string GetName ();
	public abstract float ComputeAccomplishment ();

	public float ComputeSatisfaction() {

		return (accomplishment - expectance) * interest;
	}

	public void Habituate() {
		expectance += (accomplishment - expectance) * habituation;
	}

	// This function should be called each constant amount of time.
	public void Iterate() {
		
		accomplishment = ComputeAccomplishment ();
		satisfaction = ComputeSatisfaction ();

		Habituate ();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
