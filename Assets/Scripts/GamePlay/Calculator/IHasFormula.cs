using UnityEngine;
using System.Collections.Generic;
using Beings;

namespace Calculator {

	public interface IHasFormula {
		void Initialize();
		bool HasSelfBeing ();
		void SetSelfBeing (ABeing _self);
		void SetTargetBeing (ABeing _target);
	}
}