using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer Instance;

	public Text timerText;

	private float timeRemaining;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
	}

	void Start(){
		timeRemaining = WorkoutManager.Instance.currentExercise.timeToComplete;
	}
	
	void Update () {
		timerText.text = (timeRemaining - Time.timeSinceLevelLoad).ToString("F0");

		if ((timeRemaining - Time.timeSinceLevelLoad) <= 0) {

			WorkoutManager.Instance.HandleTimerHittingZero();

			timeRemaining = timeRemaining + WorkoutManager.Instance.currentExercise.timeToComplete;
		}
	}
}
