using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// private attributes
	private float mInverseSecondsPerDays;

	//public attributes
	public float PreciseTime = 0;
	public float Days = 0;
	public bool Pause = false;
	public Text DayDisplay;
	public static Timer instance = null;

	// public constants
	public float SECONDS_PER_DAY = 10;

	//public static functions
	public static bool HasPaused() {
		return instance.Pause;
	}


	//public events
	public delegate void DayPassed();
	public static event DayPassed OnDayPassed;

	// class life cycle
	void Awake () {
		this.PreciseTime = 0;
		mInverseSecondsPerDays = 1 / SECONDS_PER_DAY;

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Debug.LogWarning ("Error : two Timers declared");
			Destroy (instance.gameObject);
			instance = this;
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			this.Pause = ! this.Pause;
		}

		if (! this.Pause) {
			this.PreciseTime += Time.deltaTime * mInverseSecondsPerDays;
			if (this.PreciseTime > Days + 1) {
				this.Days = this.Days + 1;
				if (OnDayPassed != null) {OnDayPassed ();}
				if(this.DayDisplay != null) {
					this.DayDisplay.text = "Day " + this.Days;
				}
			}
		}
	}

}
