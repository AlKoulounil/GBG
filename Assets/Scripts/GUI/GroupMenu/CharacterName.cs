using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Beings;


namespace GUI {
	public class CharacterName : MonoBehaviour {

		private Character mAttachedCharacter;
		private Text mTextComponent;

		void Awake() {
			mTextComponent = GetComponent<Text> ();
			mAttachedCharacter = GetComponentInParent<Character> ();

		}

		void OnEnable() {
			RefreshName (mAttachedCharacter.CharName);
			mAttachedCharacter.OnNameChanged += RefreshName;
		}
		
		void OnDisable() {
			mAttachedCharacter.OnNameChanged -= RefreshName;
		}

		void RefreshName(string newName) {
			mTextComponent.text = newName;
		}

	}
}
