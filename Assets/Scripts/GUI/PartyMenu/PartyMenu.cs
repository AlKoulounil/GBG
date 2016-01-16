using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour {

	private float RectX =0;
	private float RectY = 0;
	private float RectWidth = -10;
	private float RectHeight = 90;
	private float GapPerChar = -100;

	public Party PartyToDisplay;
	public Text TotalStrengthDisplay;

	// Use this for initialization
	void OnEnable () {
		DisplayMenu.OnDisplayPartyMenu += RefreshPartyDisplay;
		this.PartyToDisplay.OnPartyChanged += RefreshPartyDisplay;
	}

	void OnDisable () {
		DisplayMenu.OnDisplayPartyMenu -= RefreshPartyDisplay;
		this.PartyToDisplay.OnPartyChanged -= RefreshPartyDisplay;
	}
		
	public void RefreshPartyDisplay() {
		float gap = 0;
		foreach(Character c in PartyToDisplay.GetAllCharacters ()) {
			//c.transform.SetParent (this.transform);
			gap += GapPerChar;
			RectTransform guiPosition = (RectTransform) c.transform;

			guiPosition.localRotation = Quaternion.identity;
			guiPosition.localScale = Vector3.one;
			guiPosition.localPosition = Vector3.zero;
			guiPosition.anchorMin = new Vector2(0, 1);
			guiPosition.anchorMax = new Vector2(1, 1);
			guiPosition.sizeDelta = new Vector2(RectWidth, RectHeight);
			guiPosition.anchoredPosition  = new Vector2 (RectX, RectY + gap);


		}

		this.TotalStrengthDisplay.text = "Total strength : " + this.PartyToDisplay.GetTotalStrength();
	}
}
