using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HweelTimer : MonoBehaviour {

	public static HweelTimer Instance;

	[HideInInspector]public Hweel hweel;

	public GameObject notch;
	public Image overlayPie;
	public Vector3 direction;

	public float timeRemaining;
	public float rotationSpeed;

	[HideInInspector]public Exercise currentExercise;
	public TextMeshProUGUI currentExerciseName;
	public TextMeshProUGUI currentExerciseSets;
	public TextMeshProUGUI currentExerciseReps;
	public TextMeshProUGUI currentExerciseTime;

	[HideInInspector]public int excerciseIndex = 0;

	public List<TextMeshProUGUI> texts;
	private int _colorIndex;

	public List<Image> images;

	//[HideInInspector]public PieSlice activePieSlice;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
	}

	void Start(){

		hweel = CanvasForHweels.Instance.currentHweel;

		Time.timeScale = 10;

		direction = new Vector3(0,0,1);

		rotationSpeed = 360f / hweel.workout.totalSeconds;

		currentExercise = hweel.workout.exercises[0];

		timeRemaining = currentExercise.timeToComplete;

		_colorIndex = 0;

		UpdateColor();
	}

	void Update () {
		notch.transform.Rotate(direction * (Time.deltaTime * -rotationSpeed));
		overlayPie.fillAmount = (notch.transform.rotation.eulerAngles.z) / 360f;

		DisplayExerciseDetails();

		if ((timeRemaining - Time.timeSinceLevelLoad) <= 0) {
			HandleTimerHittingZero();
			timeRemaining = timeRemaining + currentExercise.timeToComplete;
		}
	}

	void DisplayExerciseDetails(){
		currentExerciseName.text = currentExercise.title;
		currentExerciseSets.text = currentExercise.setsRemaining + "/" + currentExercise.totalSets;
		currentExerciseReps.text = currentExercise.repCount.ToString();
		currentExerciseTime.text = (timeRemaining - Time.timeSinceLevelLoad).ToString("F0");
	}

	void HandleTimerHittingZero(){

		print("HEY ITS MEE");

		currentExercise.setsRemaining--;

		if (currentExercise.setsRemaining > 0) {
//			setsAndRepsDisplay.text = "SET: " + (4 -currentExercise.setsRemaining) + " of 3 | REPS: " + currentExercise.repCount;
		} else {
			SetupForNextExcersize();
		}
	}

	public void SetupForNextExcersize(){

		if(excerciseIndex < hweel.workout.exercises.Count){
			excerciseIndex++;
			currentExercise = hweel.workout.exercises[excerciseIndex];
			UpdateColor();			
		}
	}

	void UpdateColor(){

		Color newColor = new Color();

		foreach (TextMeshProUGUI text in texts) {
			newColor = hweel.dynamicWheel.pieSlices[_colorIndex].image.color; //TODO only do this once
			text.color = newColor;
		}

		foreach (Image image in images){
			image.color = newColor;
		}

		_colorIndex++;
	}
}
