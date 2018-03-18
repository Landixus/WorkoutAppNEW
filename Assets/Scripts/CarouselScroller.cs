using System.Collections.Generic;
using UnityEngine;

public class CarouselScroller: MonoBehaviour {

	public RectTransform scrollPanel;
	[SerializeField] private List<Hweel> _hweels;
	public RectTransform centerToCompare;

	private float[] _distanceToCenter; //All Buttons distance to the center
	private float[] _distanceReposition;
	private float _lerpSpeed = 10f;
	private bool _isDragging = false;
	private bool _targetIsNearestButton = true;
	private int _distanceBetweenButtons;
	private int _minButtonNumber; 
	private int _buttonLength;

	public Transform blackCircleCustodyParent;
	public Hweel activeHweel;

	public void Awake(){
		InitCarousel(_hweels);
	}

	void Start(){
		InvokeRepeating("GetItemClosestToCenter", 0, 0.25f);
	}

	void Update(){


		if(Input.GetKeyDown(KeyCode.UpArrow)){
			activeHweel.OpenToSquare();
		}

		if(Input.GetKeyDown(KeyCode.DownArrow)){
			activeHweel.CloseToCircle();
		}



		for(int i = 0; i < _hweels.Count; i++) {

			_distanceToCenter[i] = Mathf.Abs(_distanceReposition[i]);
			_distanceReposition[i] = centerToCompare.position.x - _hweels[i].rectTransform.position.x;

			//"Pop" button out as it approaches center
			if (_distanceToCenter[i] < 100) {
				float scale = 1 + (1f - ((_distanceToCenter[i]/4) + 75f) / 100f);
				_hweels[i].transform.localScale = new Vector3(scale, scale, 1);
			} else {
				_hweels[i].transform.localScale = Vector3.one;
			}
		}

		if (_targetIsNearestButton) {
			float minDistance = Mathf.Min(_distanceToCenter);

			for(int a = 0; a < _hweels.Count; a++) {
				if (minDistance == _distanceToCenter[a]) {
					_minButtonNumber = a;
				}
			}
		}

		if (!_isDragging) 
		{
			LerpToButton(-_hweels[_minButtonNumber].rectTransform.anchoredPosition.x);
		}
	}

	public void InitCarousel(List<Hweel> items) {
		_hweels = items;

		_buttonLength = _hweels.Count;
		_distanceToCenter = new float[_buttonLength];
		_distanceReposition = new float[_buttonLength];
		_distanceBetweenButtons = 0;
		if (_hweels.Count > 0)
		{
			_distanceBetweenButtons = (int)Mathf.Abs(_hweels[1].GetComponent<RectTransform>().anchoredPosition.x - _hweels[0].GetComponent<RectTransform>().anchoredPosition.x);
		}
	}

	public void LerpToButton(float position){
		float newX = Mathf.Lerp(scrollPanel.anchoredPosition.x, position, Time.deltaTime * _lerpSpeed);
		Vector2 newPosition = new Vector2(newX, scrollPanel.anchoredPosition.y);
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

		foreach(Hweel potentialItem in _hweels){
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
}
