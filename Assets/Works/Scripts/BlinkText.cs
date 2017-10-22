using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlinkText : MonoBehaviour {

	private CanvasGroup canvas;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<CanvasGroup>();
		canvas = gameObject.GetComponent<CanvasGroup>();
		canvas.DOFade(0.0f, 1.0f).SetEase(Ease.InSine).SetLoops(-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
