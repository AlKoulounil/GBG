using UnityEngine;
using System.Collections.Generic;

namespace Calculator {

	/// <summary>
	/// This formula is for parents of an individual formula.
	/// </summary>
	public interface IFormulaParent {

		/// <summary>
		/// It is called by the formula to get the text to compute as a formula
		/// </summary>
		/// <returns>The formula text.</returns>
		string GetFormulaText();

		/// <summary>
		/// It is meant to return the parent of the formula, or the Component containing it (and initializing it).
		/// </summary>
		/// <returns>The component.</returns>
		Component GetComponent();
	}
}