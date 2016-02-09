﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;

public abstract class AEffect : MonoBehaviour {

	public abstract void Apply(Dictionary<STORAGE_KEYS, Container> targets);
}