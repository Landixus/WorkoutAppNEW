using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelsGridLayout : MonoBehaviour {

	public Hweel hweel;

	public GridLayoutGroup grid;

	public ExerciseEditPanel panelPrefab;

	public List<ExerciseEditPanel> panels;

	public Button addPanelButton;

	void Start(){
		addPanelButton.onClick.AddListener(HandleAdd);
	}

	public void PopulatePanels(List<Exercise> exercises){
		foreach(Exercise exercise in exercises){
			CreatePanel(exercise, null);
		}

		addPanelButton.transform.SetAsLastSibling();

		hweel.dynamicWheel.EstablishNotches();
	}

	public ExerciseEditPanel CreatePanel(Exercise exercise, PieSlice pieSlice){
		ExerciseEditPanel newPanel = Instantiate(panelPrefab);

		newPanel.exercise = exercise;
		newPanel.hweel = hweel;
		newPanel.transform.SetParent(grid.transform);

		newPanel.pieSlice = pieSlice;

		panels.Add(newPanel);

		return newPanel;
	}

	void HandleAdd(){
		Exercise newExercise = new Exercise();
		newExercise.setsRemaining = 3;
		newExercise.totalSets = 3;
		newExercise.repCount = 10;
		newExercise.timeToComplete = 90;

		hweel.workout.exercises.Add(newExercise);
		//hweel.dynamicWheel.exercises.Add(newExercise);

//		newExercise.timeLeftInSet = newExercise.timeToComplete;
//		newExercise.totalTime = newExercise.totalSets * newExercise.timeToComplete;

		ExerciseEditPanel newPanel = CreatePanel(newExercise,null);

		newPanel.transform.SetAsLastSibling();
		addPanelButton.transform.SetAsLastSibling();

		hweel.dynamicWheel.EstablishNotches();

	}
}
