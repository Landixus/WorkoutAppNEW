using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseEditPanel : CarouselScrollItem {

	public Exercise exercise;

	public TMP_InputField excerciseTitleInputField;

	public TextMeshProUGUI sets;
	public Button addSet;
	public Button subtractSet;

	public TextMeshProUGUI reps;
	public Button addRep;
	public Button subtractRep;

	public TextMeshProUGUI time;
	public Button addTime;
	public Button subtractTime;

	public Image[] images;
	public TextMeshProUGUI[] texts;

	public PieSlice pieSlice;

	public Hweel hweel;

	void Start () {
		excerciseTitleInputField.text = exercise.title;
		sets.text = exercise.totalSets.ToString();
		reps.text = exercise.repCount.ToString();
		time.text = exercise.timeToComplete.ToString();

		addSet.onClick.AddListener(HandleAddSetPressed);
		subtractSet.onClick.AddListener(HandleSubtractSetPressed);

		addRep.onClick.AddListener(HandleAddRepPressed);
		subtractRep.onClick.AddListener(HandleSubtractRepPressed);

		addTime.onClick.AddListener(HandleAddTimePressed);
		subtractTime.onClick.AddListener(HandleSubtractTimePressed);

		excerciseTitleInputField.onValueChanged.AddListener(delegate {HandleTitleChange();});

		images = GetComponentsInChildren<Image>();
		texts = GetComponentsInChildren<TextMeshProUGUI>();
	}

	void HandleAddSetPressed(){
		if(exercise.totalSets >= 99) return;
		exercise.totalSets ++;
		exercise.setsRemaining = exercise.totalSets;
		sets.text = exercise.totalSets.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleSubtractSetPressed(){
		if(exercise.totalSets <= 1) return;
		exercise.totalSets --;
		exercise.setsRemaining = exercise.totalSets;
		sets.text = exercise.totalSets.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleAddRepPressed(){
		if(exercise.repCount >= 99) return;
		exercise.repCount ++;
		reps.text = exercise.repCount.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleSubtractRepPressed(){
		if(exercise.repCount <= 1) return;
		exercise.repCount --;
		reps.text = exercise.repCount.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleAddTimePressed(){
		if(exercise.timeToComplete >= 990) return;
		exercise.timeToComplete = exercise.timeToComplete + 10;
		time.text = exercise.timeToComplete.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleSubtractTimePressed(){
		if(exercise.timeToComplete <= 10) return;
		exercise.timeToComplete = exercise.timeToComplete - 10;
		time.text = exercise.timeToComplete.ToString();
		hweel.dynamicWheel.EstablishNotches();
	}

	void HandleTitleChange(){
		exercise.title = excerciseTitleInputField.text;
	}

	//TODO use this
	public void UpdateColor(Color newColor){
//		foreach(Image image in images){
//			image.color = newColor;
//		}

		foreach(TextMeshProUGUI text in texts){
			text.color = newColor;
		}
	}
}
