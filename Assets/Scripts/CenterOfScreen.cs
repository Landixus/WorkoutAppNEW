using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfScreen : MonoBehaviour {

	public static CenterOfScreen Instance;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}
}
