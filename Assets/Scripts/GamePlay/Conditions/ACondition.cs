using UnityEngine;
using System.Collections;

namespace Conditions
{
	public abstract class ACondition : MonoBehaviour
	{
		public abstract bool AllowsEffect();
	}
}
