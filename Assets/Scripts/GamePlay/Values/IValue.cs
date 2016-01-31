using UnityEngine;
using System.Collections;

namespace Values
{

	public delegate void OnChange();

	public interface IValue
	{

		float GetValue ();

		string GetName ();

		event OnChange HasChanged;

	}
}
