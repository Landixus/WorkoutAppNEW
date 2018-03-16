using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutManager : MonoBehaviour {
	
	public static WorkoutManager Instance;

	public Workout pushWorkout;
	public Workout pullWorkout;
	public Workout legsWorkout;

	public Workout chestWorkout;
	public Workout backWorkout;
	public Workout legs2Workout;
	public Workout shoulderWorkout;

	public Workout fullWorkout;
	public Workout altWorkout;
	public Workout runWorkout;

	//D10
	public Workout mon;
	public Workout tue;
	public Workout wed;
	public Workout thu;
	public Workout fri;
	public Workout sat;
	public Workout sun;

	public Workout currentWorkout;
	[HideInInspector]public Exercise currentExercise;

	[HideInInspector]public int excerciseIndex = 0;

	public Text currentExerciseDisplay;
	public Text setsAndRepsDisplay;

	public Image[] imagesToChangeColor;
	public Text[] allText;

	public Image blackOverlay;
	public Text infoText;

	public float totalWorkoutTime;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}

		if(PlayerPrefs.GetInt("workout") == 0){
			currentWorkout = pushWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 1){
			currentWorkout = pullWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 2){
			currentWorkout = legsWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 3){
			currentWorkout = chestWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 4){
			currentWorkout = backWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 5){
			currentWorkout = legs2Workout;
		}else if(PlayerPrefs.GetInt("workout") == 6){
			currentWorkout = shoulderWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 7){
			currentWorkout = fullWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 8){
			currentWorkout = altWorkout;
		}else if(PlayerPrefs.GetInt("workout") == 9){
			currentWorkout = runWorkout;
		}

		//D10
		else if(PlayerPrefs.GetInt("workout") == 10){
			currentWorkout = mon;
		}else if(PlayerPrefs.GetInt("workout") == 11){
			currentWorkout = tue;
		}else if(PlayerPrefs.GetInt("workout") == 12){
			currentWorkout = wed;
		}else if(PlayerPrefs.GetInt("workout") == 13){
			currentWorkout = thu;
		}else if(PlayerPrefs.GetInt("workout") == 14){
			currentWorkout = fri;
		}else if(PlayerPrefs.GetInt("workout") == 15){
			currentWorkout = sat;
		}else if(PlayerPrefs.GetInt("workout") == 16){
			currentWorkout = sun;
		}
	}

	void Start(){

 		//FOR TESTING  
		Time.timeScale = 1;
		

		//allImages = FindObjectsOfType<Image>();
		allText = FindObjectsOfType<Text>();

		currentExercise = currentWorkout.exercises[excerciseIndex];

		currentExercise.currentSetEdgeButton.blink();

		UpdateText();
		UpdateColor();

		//totalWorkoutTime =

		foreach(Exercise exercise in currentWorkout.exercises){
			float timeToCompleteExercise = exercise.setsRemaining * exercise.timeToComplete;
			totalWorkoutTime = totalWorkoutTime + timeToCompleteExercise;
			print("totalWorkoutTime in seconds " + totalWorkoutTime);
			print("totalWorkoutTime in minutes " + totalWorkoutTime/60f);
		}
	}

	public void SetupForNextExcersize(){
		excerciseIndex++;
		currentExercise = currentWorkout.exercises[excerciseIndex];
		currentExercise.currentSetEdgeButton.blink();
		UpdateText();
		UpdateColor();
	}

	public void UpdateText(){
		currentExerciseDisplay.text = currentExercise.name;	
		setsAndRepsDisplay.text = "SET: " + (4 - currentExercise.setsRemaining) + " of 3 | REPS: " + currentExercise.repCount;
	}

	public void UpdateColor(){
		foreach (Text text in allText) {
			text.color = currentExercise.set1EdgeButton.initialColor;
		}

		foreach (Image image in imagesToChangeColor){
			image.color = currentExercise.set1EdgeButton.initialColor;
		}

		PauseButton.Instance.outerCircle.color = currentExercise.set1EdgeButton.initialColor;
	}

//	public void UpdateColor(){
//		if (currentExercise.category == Exercise.Catergory.HIIT) {
//			foreach (Image image in allImages) {
//				if (image.color != Color.black) {
//					image.color = Color.red;
//				}
//			}
//		}
//
//		else if (currentExercise.category == Exercise.Catergory.MultiJoint) {
//			foreach (Image image in allImages) {
//				if (image.color != Color.black) {
//					image.color = Color.blue;
//				}
//			}
//			foreach (Text text in allText) {
//				text.color = Color.blue;
//			}
//		}
//
//		else if (currentExercise.category == Exercise.Catergory.SingleJoint) {
//			foreach (Image image in allImages) {
//				if (image.color != Color.black) {
//					image.color = Color.green;
//				}
//			}
//			foreach (Text text in allText) {
//				text.color = Color.green;
//			}
//		}
//	}

	public void HandleTimerHittingZero(){

		currentExercise.currentSetEdgeButton.lightUp();
		currentExercise.setUpForNextEdgeButton();

		currentExercise.setsRemaining--;

		if (currentExercise.setsRemaining > 0) {
			setsAndRepsDisplay.text = "SET: " + (4 -currentExercise.setsRemaining) + " of 3 | REPS: " + currentExercise.repCount;
		} else {
			SetupForNextExcersize();
		}
	}
}
