using UnityEngine;
using System.Collections.Generic;

namespace Tools {

	public static class Error {

		/// <summary>
		/// Gets a string describing the hierarchy position of the game object
		/// </summary>
		/// <param name="o">GameObject to analyse </param>
		public static string Hierarchy(GameObject o) {
			if (o.transform.parent == null) {
				return o.name;
			} else {
				return Hierarchy(o.transform.parent.gameObject) + "->" + o.name;
			}
		}

		/// <summary>
		/// Gets a string describing the hierarchy position of the component
		/// </summary>
		/// <param name="c">Component to analyse </param>
		public static string Hierarchy(Component c) {
			return Hierarchy(c.gameObject);
		}
	}
}