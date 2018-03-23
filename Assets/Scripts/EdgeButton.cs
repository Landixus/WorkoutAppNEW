using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EdgeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

	[HideInInspector]public Color initialColor;
	[HideInInspector]public float r;
	[HideInInspector]public float g;
	[HideInInspector]public float b;

	public Image edge;
	[HideInInspector]public Button button;

	[HideInInspector]public Exercise exercise;

	public bool shouldLightUp = false;

	void Awake(){
		//edge = GetComponentInChildren<Image>();
		button = GetComponent<Button>();
	}

	void Start () {
		initialColor = edge.color;
		r = initialColor.r;
		g = initialColor.g;
		b = initialColor.b;

		edge.color = new Color(r, g, b, .25f); 
	}

	public void OnPointerDown(PointerEventData eventData){
		WorkoutManager.Instance.infoText.text = exercise.title;
		WorkoutManager.Instance.infoText.color = initialColor;
		WorkoutManager.Instance.blackOverlay.transform.localScale = Vector3.one;
	}

	public void OnPointerUp(PointerEventData eventData)	{
		WorkoutManager.Instance.infoText.text = "";
		WorkoutManager.Instance.blackOverlay.transform.localScale = Vector3.zero;	
	}
		
	public void blink(){
		StartCoroutine(blinkCo());
	}

	private IEnumerator blinkCo(){

		edge.color = new Color(r, g, b, .5f); 
		yield return new WaitForSeconds(.5f);

		edge.color = new Color(r, g, b, 1f); 
		yield return new WaitForSeconds(.5f);

		if (!shouldLightUp) {
			StartCoroutine(blinkCo());
		}
	}

	public void lightUp(){
		shouldLightUp = true;
	}
}
