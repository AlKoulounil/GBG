using UnityEngine;
using System.Collections;

public class Hunger : Desire {

	
	public override string GetName ()
	{
		return "Hunger";
	}

	public override float ComputeAccomplishment ()
	{
		return 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
