using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using Containers;

public interface IEffect {

	void Apply(Dictionary<STORAGE_KEYS, Storage> targets);
}
