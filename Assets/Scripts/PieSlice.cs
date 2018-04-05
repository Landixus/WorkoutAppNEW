using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieSlice : MonoBehaviour {

	public Image image;

	public ExerciseEditPanel panel;

	public Exercise exercise;

	void Awake(){
		image = GetComponent<Image>();
	}
}
