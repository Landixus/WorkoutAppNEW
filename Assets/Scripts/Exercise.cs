using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour {

	public string title;
	[HideInInspector]public Workout parentWorkout;
	public int totalSets;
	public int setsRemaining;
	public int repCount;

	public int timeToComplete;
	public float timeLeftInSet;
	public int totalTime;

	public EdgeButton set1EdgeButton;
	public EdgeButton set2EdgeButton;
	public EdgeButton set3EdgeButton;

	[HideInInspector] public EdgeButton currentSetEdgeButton;

	void Awake(){
	}

	void Start(){
//		if (parentWorkout == WorkoutManager.Instance.currentWorkout) {
////			set1EdgeButton.exercise = this;
////			set2EdgeButton.exercise = this;
////			set3EdgeButton.exercise = this;
//		}
		parentWorkout = GetComponentInParent<Workout>();

		timeLeftInSet = timeToComplete;
		totalTime = totalSets * timeToComplete;
	}

	public void setUpForNextEdgeButton(){
		if (currentSetEdgeButton == null) {
			currentSetEdgeButton = set1EdgeButton;
		}else if (currentSetEdgeButton == set1EdgeButton) {
			currentSetEdgeButton = set2EdgeButton;
		}else if (currentSetEdgeButton == set2EdgeButton) {
			currentSetEdgeButton = set3EdgeButton;
		}else if (currentSetEdgeButton == set3EdgeButton) {
			
		}

		currentSetEdgeButton.blink();
	}
}
