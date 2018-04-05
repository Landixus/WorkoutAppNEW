using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseList : MonoBehaviour {

	public List<ExerciseListItem> exerciseListItems;
	public ExerciseListItem exerciseListItemPrefab;

	public GridLayoutGroup grid;

	public Button addExerciseButton;

	void Start () {
		addExerciseButton.onClick.AddListener(HandleAddPressed);
	}

	public void PopulateList(List<Exercise> exercises){
		
	}
	
	void HandleAddPressed(){
		ExerciseListItem exerciseListItem = Instantiate(exerciseListItemPrefab);
		exerciseListItem.transform.SetParent(grid.transform);
		exerciseListItem.transform.localScale = Vector3.one;
		addExerciseButton.transform.SetAsLastSibling();
	}
}
