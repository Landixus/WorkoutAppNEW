using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class D10Menu : MonoBehaviour {

	public Button mon;
	public Button tue;
	public Button wed;
	public Button thu;
	public Button fri;
	public Button sat;
	public Button sun;

	void Start () {
		mon.onClick.AddListener(Mon);
		tue.onClick.AddListener(Tue);
		wed.onClick.AddListener(Wed);
		thu.onClick.AddListener(Thu);
		fri.onClick.AddListener(Fri);
		sat.onClick.AddListener(Sat);
		sun.onClick.AddListener(Sun);
	}

	void Mon(){
		print("HELLO??");
		PlayerPrefs.SetInt("workout", 10);
		SceneManager.LoadScene(1);
	}

	void Tue(){
		PlayerPrefs.SetInt("workout",11);
		SceneManager.LoadScene(1);
	}

	void Wed(){
		PlayerPrefs.SetInt("workout", 12);
		SceneManager.LoadScene(1);
	}

	void Thu(){
		PlayerPrefs.SetInt("workout", 13);
		SceneManager.LoadScene(1);
	}

	void Fri(){
		PlayerPrefs.SetInt("workout", 14);
		SceneManager.LoadScene(1);
	}

	void Sat(){
		PlayerPrefs.SetInt("workout", 15);
		SceneManager.LoadScene(1);
	}

	void Sun(){
		PlayerPrefs.SetInt("workout", 16);
		SceneManager.LoadScene(1);
	}
}
