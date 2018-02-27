using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	public Button button;

	public Image outerCircle;

	public Button restartButton;

	public static PauseButton Instance;

	[HideInInspector]public Text text;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
		text = GetComponentInChildren<Text>();
	}

	void Start () {
		button.onClick.AddListener(HandleClick);
		restartButton.onClick.AddListener(HandleRestart);
	}

	void HandleClick(){
		if (Time.timeScale != 1) {
			Time.timeScale = 1;
			text.text = "| |";
			restartButton.transform.localScale = Vector3.zero;
		} else {
			Time.timeScale = 0;
			text.text = ">";
			restartButton.transform.localScale = Vector3.one;
		}
	}

	void HandleRestart(){
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
