using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosePlanMenu: MonoBehaviour {

	public Button ThreeAWeekWOs;
	public Button FourAWeekWOs;
	public Button AltWOs;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		ThreeAWeekWOs.onClick.AddListener(Handle3ButtonPressed);
		FourAWeekWOs.onClick.AddListener(Handle4ButtonPressed);
		AltWOs.onClick.AddListener(HandleAltButtonPressed);
	}

	void Handle3ButtonPressed(){
		SceneManager.LoadScene(1);
	}

	void Handle4ButtonPressed(){
		SceneManager.LoadScene(2);
	}

	void HandleAltButtonPressed(){
		SceneManager.LoadScene(3);
	}
}
