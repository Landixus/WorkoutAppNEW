using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasForHweels : MonoBehaviour {

	public static CanvasForHweels Instance;

	[HideInInspector]public Hweel currentHweel;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void Start(){
		DontDestroyOnLoad(gameObject);
	}
}
