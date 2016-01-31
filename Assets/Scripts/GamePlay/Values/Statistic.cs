using UnityEngine;
using System.Collections;
using Conditions;
using Resources;

namespace Values
{
	public class Statistic : MonoBehaviour, IValue
	{

		public Resource ResourceDefinition;
		public string Name;

		[Tooltip ("Free written formula to be computed at each call of GetValue")]
		public string Formula;

		/// <summary>
		/// values used in formula : Stock or Statistic 
		/// </summary>
		private IValue[] mUsedValues;

		[SerializeField]
		[Tooltip ("Do not change it from Unity, for Read-Only use only")]
		protected float Value = -1;

		public event OnChange HasChanged;


		void Update ()
		{
			//TODO : Update seulement en mode Debug
		}

		public float GetValue() {
			float oldValue = Value;
			//TODO
			if (Value != oldValue) {
				HasChanged();
			}
			return Value;
		}

		public string GetName() {
			return Name;
		}
	}
}
