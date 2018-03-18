using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Hweel : MonoBehaviour {

	public GameObject[] hideableItems;
	[HideInInspector]public RectTransform rectTransform;

	public Image blackCircle;

	public RectTransform outerCircleMask;
	public Vector2 outerCircleHiddenPos;
	public Vector2 outerCircleVisiblePos;

	public RectTransform innerBlackCircle;
	public Vector2 innerBlackCircleHiddenPos;
	public Vector2 innerBlackCircleVisiblePos;

	public float animationSpeed;

	public virtual void Awake() {
		rectTransform = transform as RectTransform;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			OpenToSquare();
		}

		if(Input.GetKeyDown(KeyCode.DownArrow)){
			CloseToCircle();
		}
	}

	public void OpenToSquare(){
		outerCircleMask.DOSizeDelta(outerCircleHiddenPos, animationSpeed);
		innerBlackCircle.DOSizeDelta(innerBlackCircleHiddenPos, animationSpeed);
	}

	public void CloseToCircle(){
		outerCircleMask.DOSizeDelta(outerCircleVisiblePos, animationSpeed);
		innerBlackCircle.DOSizeDelta(innerBlackCircleVisiblePos, animationSpeed);
	}

}
