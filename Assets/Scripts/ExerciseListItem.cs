using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseListItem : MonoBehaviour {

	public DynamicWheel wheel;

	public Exercise exercise;

	public TMP_InputField title;
	public TextMeshProUGUI sets;
	public TextMeshProUGUI reps;
	public TextMeshProUGUI time;

	public Button lessSetsButton;
	public Button moreSetsButton;

	public Button lessRepsButton;
	public Button moreRepsButton;

	public Button lessTimeButton;
	public Button moreTimeButton;

	void Start () {
		title.text = exercise.name;
		sets.text = exercise.setsRemaining.ToString();
		reps.text = exercise.repCount.ToString();
		time.text = exercise.timeToComplete.ToString();

		title.onValueChanged.AddListener(delegate{HandleTitleChanged();});
	
		lessSetsButton.onClick.AddListener(HandleLessSetsButtonPressed);
		moreSetsButton.onClick.AddListener(HandleMoreSetsButtonPressed);

		lessRepsButton.onClick.AddListener(HandleLessRepsButtonPressed);
		moreRepsButton.onClick.AddListener(HandleMoreRepsButtonPressed);

		lessTimeButton.onClick.AddListener(HandleLessTimeButtonPressed);
		moreTimeButton.onClick.AddListener(HandleMoreTimeButtonPressed);

		DynamicWheel.Instance.exercises.Add(exercise);
	}

	void HandleTitleChanged(){
		exercise.name = title.text;
	}

	void HandleLessSetsButtonPressed(){
		exercise.setsRemaining --;
		sets.text = exercise.setsRemaining.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}

	void HandleMoreSetsButtonPressed(){
		exercise.setsRemaining ++;
		sets.text = exercise.setsRemaining.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}

	void HandleLessRepsButtonPressed(){
		exercise.repCount --;
		reps.text = exercise.repCount.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}

	void HandleMoreRepsButtonPressed(){
		exercise.repCount ++;
		reps.text = exercise.repCount.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}

	void HandleLessTimeButtonPressed(){
		exercise.timeToComplete = exercise.timeToComplete - 10;
		time.text = exercise.timeToComplete.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}

	void HandleMoreTimeButtonPressed(){
		exercise.timeToComplete = exercise.timeToComplete + 10;
		time.text = exercise.timeToComplete.ToString();
		DynamicWheel.Instance.EstablishNotches();
	}
}
