using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalCarouselScroller: MonoBehaviour {

	public static VerticalCarouselScroller Instance;

	public RectTransform scrollPanel;
	public List<CarouselScrollItem> scrollItems;
	public RectTransform centerToCompare;

	public float[] _distanceToCenter; //All Buttons distance to the center
	private float[] _distanceReposition;
	private float _lerpSpeed = 15f;
	private bool _isDragging = false;
	private bool _targetIsNearestButton = true;
	private int _distanceBetweenButtons;
	private int _minButtonNumber; 
	private int _buttonLength;

	public Transform blackCircleCustodyParent;
	public Hweel activeHweel;

	public int scrollCurve;

	public Canvas canvas;

	public ScrollRect scrollRect;

	public bool shouldCurve;

	public void Awake(){
		InitCarousel(scrollItems);

		if(Instance == null){
			Instance = this;
		}
	}

	void Start(){
		if(shouldCurve){
			InvokeRepeating("GetItemClosestToCenter", 0, 0.25f);
		}
	}

	void Update(){

//		if(Input.GetKeyDown(KeyCode.UpArrow)){
//			activeHweel.OpenToCircleWATCH();
//		}
//
//		if(Input.GetKeyDown(KeyCode.DownArrow)){
//			activeHweel.CloseToCircleWATCH();
//		}

		for(int i = 0; i < scrollItems.Count; i++) {

			_distanceToCenter[i] = Mathf.Abs(_distanceReposition[i]);
			_distanceReposition[i] = centerToCompare.position.y - scrollItems[i].rectTransform.position.y;

			//"Pop" button out as it approaches center
//			if (_distanceToCenter[i] < 100) {
//				float scale = 1 + (1f - ((_distanceToCenter[i]/4) + 75f) / 100f);
//				_hweels[i].transform.localScale = new Vector3(scale, scale, 1);
//			} else {
//				_hweels[i].transform.localScale = Vector3.one;
//			}

			//Button to move to the right as it gets farther away from center
			if(shouldCurve){
				scrollItems[i].transform.localPosition = new Vector2((_distanceToCenter[i] * _distanceToCenter[i])/scrollCurve, scrollItems[i].transform.localPosition.y);
			}
		}

		if (_targetIsNearestButton) {
			float minDistance = Mathf.Min(_distanceToCenter);

			for(int a = 0; a < scrollItems.Count; a++) {
				if (minDistance == _distanceToCenter[a]) {
					_minButtonNumber = a;
				}
			}
		}

		if (!_isDragging) 
		{
			LerpToButton(-scrollItems[_minButtonNumber].rectTransform.anchoredPosition.y);
		}
	}

	public void InitCarousel(List<CarouselScrollItem> items) {
		scrollItems = items;

		_buttonLength = scrollItems.Count;
		_distanceToCenter = new float[_buttonLength];
		_distanceReposition = new float[_buttonLength];
		_distanceBetweenButtons = 0;
		if (scrollItems.Count > 0)
		{
			_distanceBetweenButtons = (int)Mathf.Abs(scrollItems[1].GetComponent<RectTransform>().anchoredPosition.y - scrollItems[0].GetComponent<RectTransform>().anchoredPosition.y);
		}
	}

	public void LerpToButton(float position){
		float newY = Mathf.Lerp(scrollPanel.anchoredPosition.y, position, Time.deltaTime * _lerpSpeed);
		Vector2 newPosition = new Vector2(scrollPanel.anchoredPosition.x, newY);
		scrollPanel.anchoredPosition = newPosition;
	}

	public void StartDrag(){
		_isDragging = true;
		_targetIsNearestButton = true;
	}

	public void EndDrag(){
		_isDragging = false;
	}

	public void GoToButton(int buttonIndex){
		_targetIsNearestButton = false;
		_minButtonNumber = buttonIndex;
	}

	public void GetItemClosestToCenter(){
		Hweel centermostItem = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		foreach(Hweel potentialItem in scrollItems){
			Vector3 directionToTarget = potentialItem.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;

			if(dSqrToTarget < closestDistanceSqr){
				closestDistanceSqr = dSqrToTarget;
				centermostItem = potentialItem;
			}
		}

		activeHweel = centermostItem;
		//return centermostItem;
	}

//	public void HandleAddPressed(){
//		
//	}
}