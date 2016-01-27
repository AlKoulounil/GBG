using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Beings;

namespace GUI
{
	public class GroupMenu : MonoBehaviour
	{

		public Group GroupToDisplay;
		public Text TotalStrengthDisplay;

		// Use this for initialization
		void OnEnable ()
		{
			DisplayMenu.OnDisplayGroupMenu += RefreshGroupDisplay;
			this.GroupToDisplay.OnGroupChanged += RefreshGroupDisplay;
		}

		void OnDisable ()
		{
			DisplayMenu.OnDisplayGroupMenu -= RefreshGroupDisplay;
			this.GroupToDisplay.OnGroupChanged -= RefreshGroupDisplay;
		}
		
		public void RefreshGroupDisplay ()
		{
//		foreach(Character c in GroupToDisplay.GetAllCharacters ()) {
			//TODO: UI GroupMenuItems
//		}

			this.TotalStrengthDisplay.text = "Total strength : " + this.GroupToDisplay.GetTotalStrength ();
		}
	}
}
