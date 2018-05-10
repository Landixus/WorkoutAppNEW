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

	public Image spriteHolder;
	public Sprite pauseSprite;
	public Sprite playSprite;

	void Awake(){
		if (Instance == null) {
			Instance = this;
		}
	}

	void Start () {
		button.onClick.AddListener(HandleClick);
		restartButton.onClick.AddListener(HandleRestart);
	}

	void HandleClick(){
		if (Time.timeScale != 1) {
			Time.timeScale = 1;
			spriteHolder.sprite = pauseSprite;
			restartButton.transform.localScale = Vector3.zero;
		} else {
			Time.timeScale = 0;
			spriteHolder.sprite = playSprite;
			restartButton.transform.localScale = Vector3.one;
		}
	}

	void HandleRestart(){
		Time.timeScale = 1;
		Destroy(HweelTimer.Instance.hweel.gameObject);
		SceneManager.LoadScene(0);
	}
}
