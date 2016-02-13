using UnityEngine;
using System.Collections.Generic;
using Beings;

namespace Calculator {

	/// <summary>
	/// This interface is for all Components that have at least one formula.
	/// </summary>
	public interface IHasFormula {
		void Initialize();
		bool HasSelfBeing ();
		void SetSelfBeing (ABeing _self);
		void SetTargetBeing (ABeing _target);
	}
}