using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsCarousel : VerticalCarouselScroller {

	public ExerciseEditPanel panelPrefab;

	public int currentYPos;

	void Start () {
		
	}
	
	public void PopulatePanels(List<Exercise> exercises){
		foreach(Exercise exercise in exercises){
			CreatePanel(exercise);
		}
	}

	public void CreatePanel(Exercise exercise){
		ExerciseEditPanel newPanel = Instantiate(panelPrefab);
		newPanel.transform.localScale = Vector3.one;
		currentYPos = currentYPos - 400;
		newPanel.transform.localPosition = new Vector3(0, currentYPos,0);

		newPanel.sets.text = exercise.totalSets.ToString();
		newPanel.reps.text = exercise.repCount.ToString();
		newPanel.time.text = exercise.timeToComplete.ToString();

		scrollItems.Add(newPanel);
	}
}
