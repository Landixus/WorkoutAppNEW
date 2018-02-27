using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FourWorkoutMenu: MonoBehaviour {

	public Button chestButton;
	public Button backButton;
	public Button legsButton;
	public Button shouldersButton;

	void Start () {
		chestButton.onClick.AddListener(HandleChestButtonPressed);
		backButton.onClick.AddListener(HandleBackButtonPressed);
		legsButton.onClick.AddListener(HandleLegsButtonPressed);
		shouldersButton.onClick.AddListener(HandleShoulderButtonPressed);
	}

	void HandleChestButtonPressed(){
		PlayerPrefs.SetInt("workout", 3);
		SceneManager.LoadScene(4);
	}

	void HandleBackButtonPressed(){
		PlayerPrefs.SetInt("workout", 4);
		SceneManager.LoadScene(4);
	}

	void HandleLegsButtonPressed(){
		PlayerPrefs.SetInt("workout", 5);
		SceneManager.LoadScene(4);
	}

	void HandleShoulderButtonPressed(){
		PlayerPrefs.SetInt("workout", 6);
		SceneManager.LoadScene(4);
	}
}
