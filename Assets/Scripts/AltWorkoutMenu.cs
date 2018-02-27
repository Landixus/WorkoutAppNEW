using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AltWorkoutMenu : MonoBehaviour {

	public Button fullButton;
	public Button altButton;
	public Button runButton;

	void Start () {
		fullButton.onClick.AddListener(HandleFullButtonPressed);
		altButton.onClick.AddListener(HandleAltButtonPressed);
		runButton.onClick.AddListener(HandleRunButtonPressed);
	}

	void HandleFullButtonPressed(){
		PlayerPrefs.SetInt("workout", 7);
		SceneManager.LoadScene(4);
	}

	void HandleAltButtonPressed(){
		PlayerPrefs.SetInt("workout", 8);
		SceneManager.LoadScene(4);
	}

	void HandleRunButtonPressed(){
		PlayerPrefs.SetInt("workout", 9);
		SceneManager.LoadScene(4);
	}
}
