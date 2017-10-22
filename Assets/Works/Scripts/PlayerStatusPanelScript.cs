using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStatusPanelScript : MonoBehaviour
{
    public Text playerName;
    public CanvasGroup status;

    // Use this for initialization
    void Start()
    {
        status.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
        gameObject.GetComponent<CanvasGroup>().DOFade(1.0f, 1.0f).SetEase(Ease.InQuad);
    }

    public void ShowStatus()
    {
        StartCoroutine(FadeInStatus());
    }

    private IEnumerator FadeInStatus()
    {
        status.DOFade(1.0f, 1.0f).SetEase(Ease.InQuad);
        yield return null;
    }
}
