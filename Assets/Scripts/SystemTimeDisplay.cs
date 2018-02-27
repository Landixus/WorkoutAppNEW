using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTimeDisplay : MonoBehaviour {

	public Text timeText;

	private string minutes;

	void Start(){
		InvokeRepeating("DisplayTime", 1, .5f);
	}

	void DisplayTime(){

		if (System.DateTime.Now.Minute < 10) {
			minutes = "0" + System.DateTime.Now.Minute.ToString();
		} else {
			minutes = System.DateTime.Now.Minute.ToString();
		}

		if (System.DateTime.Now.Hour > 12) {
			timeText.text = System.DateTime.Now.Hour - 12 + ":" + minutes + " PM";
		} else {
			timeText.text = System.DateTime.Now.Hour + ":" + minutes + " AM";
		}
	}
}
