using UnityEngine;
using System.Collections;

namespace Movement
{
	public interface IObjectToMove
	{
		
		Vector3 Target {
			get;
			set;
		}
	}
}
