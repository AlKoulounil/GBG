using UnityEngine;

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
