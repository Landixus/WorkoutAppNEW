using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workout : MonoBehaviour {

	public string name;

	public List<Exercise> exercises;

	[HideInInspector] public int totalSeconds;
	[HideInInspector] public int totalMinutes;

	void Awake(){
		CalculateTotalTime();
	}

	public void CalculateTotalTime(){

		totalSeconds = 0;

		foreach(Exercise exercise in exercises){
			totalSeconds = totalSeconds + (exercise.setsRemaining * exercise.timeToComplete);
		}

		totalMinutes = totalSeconds/60;
	}
}
