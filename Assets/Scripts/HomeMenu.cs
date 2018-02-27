using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour {

	public Button pushButton;
	public Button pullButton;
	public Button legsButton;

	void Start () {
		pushButton.onClick.AddListener(HandlePushButtonPressed);
		pullButton.onClick.AddListener(HandlePullButtonPressed);
		legsButton.onClick.AddListener(HandleLegsButtonPressed);
	}
	
	void HandlePushButtonPressed(){
		PlayerPrefs.SetInt("workout", 0);
		SceneManager.LoadScene(1);
	}

	void HandlePullButtonPressed(){
		PlayerPrefs.SetInt("workout", 1);
		SceneManager.LoadScene(1);
	}

	void HandleLegsButtonPressed(){
		PlayerPrefs.SetInt("workout", 2);
		SceneManager.LoadScene(1);
	}
}
