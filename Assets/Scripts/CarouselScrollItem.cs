using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselScrollItem : MonoBehaviour {

	//public GameObject[] hideableItems;
	[HideInInspector]public RectTransform rectTransform;

	//public Image blackCircle;

	public virtual void Awake() {
		rectTransform = transform as RectTransform;
	}

//	public void scaleHideableItems(Vector3 dynamicScale){
//		if (hideableItems != null) {
//			for(int i = 0; i < hideableItems.Length; i++) {
//				hideableItems[i].transform.localScale = dynamicScale;
//				if (hideableItems[0].transform.localScale.x >= 0) {
//					hideableItems[i].SetActive(true);
//				} else {
//					hideableItems[i].SetActive(false);
//				}
//			}
//		}
//	}
}
