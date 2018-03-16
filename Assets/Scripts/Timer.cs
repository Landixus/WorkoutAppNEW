using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer Instance;

	public Text timerText;

	private float timeRemaining;

	public GameObject outerCircle;
	public float rotationSpeed;
	public Vector3 direction;
	public float currentAngle;
	public float amountToIncrementAngle;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
	}

	void Start(){
		timeRemaining = WorkoutManager.Instance.currentExercise.timeToComplete;

		rotationSpeed = 360 / WorkoutManager.Instance.totalWorkoutTime;
	}
	
	void Update () {
		timerText.text = (timeRemaining - Time.timeSinceLevelLoad).ToString("F0");

		if ((timeRemaining - Time.timeSinceLevelLoad) <= 0) {

			WorkoutManager.Instance.HandleTimerHittingZero();

//			currentAngle = currentAngle + amountToIncrementAngle;
//			Vector3 newAngle = new Vector3(0,0,currentAngle);
//			outerCircle.GetComponent<RectTransform>().rotation.eulerAngles = newAngle;

			timeRemaining = timeRemaining + WorkoutManager.Instance.currentExercise.timeToComplete;
		}

		outerCircle.transform.Rotate(direction * (Time.deltaTime * -rotationSpeed));

		//outerCircle.transform.Rotate(0,0, rotationSpeed * Time.deltaTime, Space.Self);
	}
}
