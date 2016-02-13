using UnityEngine;
using System.Collections.Generic;
using Calculator;
using Beings;

public abstract class AEffect : MonoBehaviour {

	public abstract void Apply(ABeing target);
}
