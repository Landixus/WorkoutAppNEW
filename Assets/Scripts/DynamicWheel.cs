using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWheel : MonoBehaviour {

	public static DynamicWheel Instance;

	public Workout workout;
	public List<Exercise> exercises;

	public GameObject notchPrefab;
	public GameObject subNotchPrefab;
	public PieSlice pieSlicePrefab;

	public List<PieSlice> pieSlices;

	public List<GameObject> notches;
	public List<float> notchAngles;

	public List<GameObject> subNotches;
	public List<float> subNotchAngles;

	private int _noOfExersizes = 0;
	public int noOfExersizes
	{
		get {return _noOfExersizes;}
		set {
			if (_noOfExersizes == value) return;
			_noOfExersizes = value;
			if (OnVariableChange != null)
				OnVariableChange(_noOfExersizes);
		}
	}

	public delegate void OnVariableChangeDelegate(int newVal);
	public event OnVariableChangeDelegate OnVariableChange;

	public int totalTime;

	public PanelsGridLayout panelsGridLayout;

	void Awake(){
		
		//exercises = workout.exercises;
		exercises = GetComponentInParent<Hweel>().workout.exercises;

		if(Instance == null){
			Instance = this;
		}
	}

	void Start () {
		OnVariableChange += VariableChangeHandler;

		EstablishNotches();
	}

	void Update(){
		noOfExersizes = exercises.Count;

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.U)){
			EstablishNotches();
		}
		#endif
	}

	public void EstablishNotches(){

		ClearAllNotches();

		//CALCULATE TOTAL TIME
		totalTime = 0;
		foreach(Exercise exercise in exercises){
			totalTime = totalTime + (exercise.setsRemaining * exercise.timeToComplete);
		}
		//CALCULATE TOTAL TIME

		//CALCULATE TIME OF EACH EXERSIZE RELATIVE TO TOTAL TIME AND STORE THE ANGLE IN THE LIST
		notchAngles.Clear();

		float fractionOfPie;
		float prevNotchAngle;
		float newNotchAngle = 0;
		Vector3 newNotchVector3;

		int panelIncrementer = 0;

		foreach(Exercise exercise in exercises){

			fractionOfPie = ((float)exercise.setsRemaining * (float)exercise.timeToComplete) / (float)totalTime;
			prevNotchAngle = newNotchAngle;
			newNotchAngle = newNotchAngle + (360f * fractionOfPie);
			newNotchVector3 = new Vector3(0,0,newNotchAngle);
			notchAngles.Add(newNotchAngle);

//			GameObject newNotch = CreateNotch();
//			newNotch.transform.eulerAngles = -newNotchVector3;
//			notches.Add(newNotch);

			PieSlice newSlice = CreatePieSlice();
			newSlice.transform.eulerAngles = -newNotchVector3;
			newSlice.image.fillAmount = fractionOfPie;

			Color newColor = Color.HSVToRGB(((newNotchAngle + prevNotchAngle) / 2)/360f,1,1); //CHANGES COLOR!

			newSlice.image.color = newColor;
			//newSlice.image.color = Color.HSVToRGB(1,1,newNotchAngle/360f); //CHANGES SHADE!
			//newSlice.image.color = Color.HSVToRGB(1,newNotchAngle/360f,1); //CHANGES WHITE!
			pieSlices.Add(newSlice);
			newSlice.transform.SetAsFirstSibling();

			print("panelsGridLayout.panels.Count " + panelsGridLayout.panels.Count);
			print("exercises.Count " + exercises.Count);

			if(panelsGridLayout.panels.Count == exercises.Count){

				print("YOOYOYOYO");

				panelsGridLayout.panels[panelIncrementer].UpdateColor(newColor);
				panelIncrementer ++;
			}

			if(exercise.setsRemaining > 1){

				List<float> subNotchAngles;
				int amountOfNotchesToAdd = exercise.setsRemaining - 1;
				Vector3 newSubNotchVector3;

				for(int i = 1; i < exercise.setsRemaining; i++){

					float amountOfAngleToWorkWith = newNotchAngle - prevNotchAngle;
					float amountToAddToPrevAngle = amountOfAngleToWorkWith * ((float)i/(float)exercise.setsRemaining);
					float newSubNotchAngle = prevNotchAngle + amountToAddToPrevAngle;

					//print("newSubNotchAngle: " + newSubNotchAngle);

					newSubNotchVector3 = new Vector3(0,0,(newSubNotchAngle));
					GameObject newSubNotch = CreateSubNotch();
					newSubNotch.transform.eulerAngles = -newSubNotchVector3;

					subNotches.Add(newSubNotch);
				}	
			}
		}
//		//CALCULATE TIME OF EACH EXERSIZE RELATIVE TO TOTAL TIME AND STORE THE ANGLE IN THE LIST
//
//		Vector3 newAngle;
//
//		for(int i = 0; i < exercises.Count; i++){
//			newAngle = new Vector3(0,0,(notchAngles[i]));
//
////			print("new angle " + i + newAngle);
//
////			GameObject newNotch = CreateNotch();
////			newNotch.transform.eulerAngles = newAngle;
////			notches.Add(newNotch);
//
//		}
	}

	private void VariableChangeHandler(int newVal)
	{
		EstablishNotches();
	}

	public GameObject CreateNotch(){
		GameObject newNotch = Instantiate(notchPrefab);
		newNotch.transform.SetParent(this.transform);
		newNotch.transform.localScale = Vector3.one;
		newNotch.transform.localPosition = Vector3.zero;
		return newNotch;
	}

	public GameObject CreateSubNotch(){
		GameObject newNotch = Instantiate(subNotchPrefab);
		newNotch.transform.SetParent(this.transform);
		newNotch.transform.localScale = Vector3.one;
		newNotch.transform.localPosition = Vector3.zero;
		return newNotch;
	}

	public PieSlice CreatePieSlice(){
		PieSlice newSlice = Instantiate(pieSlicePrefab);
		newSlice.transform.SetParent(this.transform);
		newSlice.transform.localScale = Vector3.one;
		newSlice.transform.localPosition = Vector3.zero;
		return newSlice;
	}

	public void ClearAllNotches(){
		foreach(GameObject notch in notches){
			Destroy(notch);
		}
		notches.Clear();

		foreach(GameObject subNotch in subNotches){
			Destroy(subNotch);
		}
		subNotches.Clear();

		foreach(PieSlice pieSlice in pieSlices){
			Destroy(pieSlice.gameObject);
		}
		pieSlices.Clear();
	}
}
