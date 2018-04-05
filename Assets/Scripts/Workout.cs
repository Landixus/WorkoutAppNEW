using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workout : MonoBehaviour {

	public string name;

	public List<Exercise> exercises;

	[HideInInspector] public int totalTime;

	void Awake(){
		CalculateTotalTime();
	}

	public void CalculateTotalTime(){

		totalTime = 0;

		foreach(Exercise exercise in exercises){
			totalTime = totalTime + (exercise.setsRemaining * exercise.timeToComplete);
		}
	}
}
