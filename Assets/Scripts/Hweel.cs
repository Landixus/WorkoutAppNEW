using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class Hweel : CarouselScrollItem {

	public GameObject[] hideableItems;
	//[HideInInspector]public RectTransform rectTransform;

	public Image blackCircle;

	public RectTransform outerCircleMask;
	public Vector2 outerCircleOpenPos;
	private Vector2 _outerCircleClosedPos;

	public RectTransform innerBlackCircle;
	public Vector2 innerBlackCircleOpenPos;
	private Vector2 _innerBlackCircleClosedPos;

	public float animationSpeed;

	private Hweel _cloneHweel;
	[HideInInspector]public Hweel parentHweel;

	//private VerticalCarouselScroller _carousel;

	public Button buttonOnHomeMenu;

	public Button goToHomeButton;
	public Button editButton;
	public Button playButton;
	public Button doneButton;

//	public PanelsCarousel innerCarousel;
	public PanelsGridLayout panelsGridLayout;

	public DynamicWheel dynamicWheel;

	public Workout workout;

	public GameObject pauseMenu;

	public TextMeshProUGUI title;
	public TextMeshProUGUI minuteAmount;

	override public void Awake() {
		base.Awake();

		//rectTransform = transform as RectTransform;

		_innerBlackCircleClosedPos = innerBlackCircle.sizeDelta;
		_outerCircleClosedPos = outerCircleMask.sizeDelta;

		//_carousel = GetComponentInParent<VerticalCarouselScroller>();

		if(panelsGridLayout != null){
			panelsGridLayout.hweel = this;
		}else{
			Debug.LogError("Need to assign panelsGridLayout to " + gameObject.name);
		}

		title.text = workout.name;
	}

	void Start(){
		buttonOnHomeMenu.onClick.AddListener(OpenToCircleWATCH);
		goToHomeButton.onClick.AddListener(CloseToCircleWATCH);

		editButton.onClick.AddListener(HandleEdit);
		doneButton.onClick.AddListener(HandleDone);

		playButton.onClick.AddListener(HandlePlay);

		animationSpeed = .25f;

		minuteAmount.text = workout.totalMinutes.ToString();
	}
	
//	void Update () {
//		if(Input.GetKeyDown(KeyCode.UpArrow)){
//			OpenToSquare();
//		}
//
//		if(Input.GetKeyDown(KeyCode.DownArrow)){
//			CloseToCircleWATCH();
//		}
//	}

	public void OpenToSquare(){
		outerCircleMask.DOSizeDelta(outerCircleOpenPos, animationSpeed);
		innerBlackCircle.DOSizeDelta(innerBlackCircleOpenPos, animationSpeed);
	}

	public void CloseToCircle(){
		outerCircleMask.DOSizeDelta(_outerCircleClosedPos, animationSpeed);
		innerBlackCircle.DOSizeDelta(_innerBlackCircleClosedPos, animationSpeed);
	}

	public void OpenToCircleWATCH(){
		StartCoroutine(openCo());
	}

	private IEnumerator openCo(){

		buttonOnHomeMenu.transform.localScale = Vector3.zero;

		VerticalCarouselScroller.Instance.GoToButton(transform.GetSiblingIndex());

		print("_distanceToCenter[transform.GetSiblingIndex()] " + VerticalCarouselScroller.Instance._distanceToCenter[transform.GetSiblingIndex()]);
		yield return new WaitForSeconds(VerticalCarouselScroller.Instance._distanceToCenter[transform.GetSiblingIndex()]/800f);

		VerticalCarouselScroller.Instance.scrollRect.enabled = false;

		_cloneHweel = Instantiate(this);

		_cloneHweel.parentHweel = this;

		_cloneHweel.transform.SetParent(CanvasForHweels.Instance.transform);
		CanvasForHweels.Instance.currentHweel = _cloneHweel;

		_cloneHweel.transform.position = this.transform.position;
		_cloneHweel.transform.localScale = this.transform.localScale;
		//cloneHweel.transform.localScale = Vector3.one;
		_cloneHweel.transform.DOScale(Vector3.one,animationSpeed);
		_cloneHweel.outerCircleMask.transform.DOMove(CenterOfScreen.Instance.transform.position,animationSpeed);
		_cloneHweel.outerCircleMask.DOSizeDelta(outerCircleOpenPos, animationSpeed);

	}

	public void CloseToCircleWATCH(){
		//transform.SetParent(parent);

		parentHweel.buttonOnHomeMenu.transform.localScale = Vector3.one;

		outerCircleMask.transform.DOLocalMove(parentHweel.outerCircleMask.transform.localPosition,animationSpeed);
		outerCircleMask.DOSizeDelta(_outerCircleClosedPos, animationSpeed).OnComplete(() => {
			VerticalCarouselScroller.Instance.scrollRect.enabled = true;
			Destroy(this.gameObject);
		});
	}

	public void HandleEdit(){

		foreach(GameObject hideableItem in hideableItems){
			hideableItem.transform.localScale = Vector3.zero;
		}

		playButton.transform.localScale = Vector3.zero;
		goToHomeButton.transform.localScale = Vector3.zero;
		doneButton.transform.localScale = Vector3.one;

//		innerCarousel.transform.localScale = Vector3.one;
//		innerCarousel.PopulatePanels(workout.exercises);

 		panelsGridLayout.transform.localScale = Vector3.one;
		panelsGridLayout.PopulatePanels(workout.exercises);

	}

	public void HandleDone(){

		foreach(GameObject hideableItem in hideableItems){
			hideableItem.transform.localScale = Vector3.one;
		}

		playButton.transform.localScale = Vector3.one;
		goToHomeButton.transform.localScale = Vector3.one;
		doneButton.transform.localScale = Vector3.zero;
//
//		innerCarousel.transform.localScale = Vector3.zero;
//		innerCarousel.gameObject.SetActive(false);

		panelsGridLayout.transform.localScale = Vector3.zero;

		workout.CalculateTotalTime();
	}

	void HandlePlay(){

		foreach(GameObject hideableItem in hideableItems){
			hideableItem.transform.localScale = Vector3.zero;
		}

		SceneManager.LoadScene(1);
	}
}
