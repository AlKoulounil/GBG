using UnityEngine;
using System.Collections;

namespace Conditions
{
	public interface ICondition
	{
		bool AllowsEffect();
	}
}
