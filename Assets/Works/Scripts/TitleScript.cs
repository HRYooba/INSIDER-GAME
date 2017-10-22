using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleScript : MonoBehaviour
{
	public CanvasGroup playerSettingPanel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvas = gameObject.GetComponent<CanvasGroup>();
        canvas.DOFade(0.0f, 1.0f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            gameObject.SetActive(false);
			playerSettingPanel.DOFade(1.0f, 0.5f).SetEase(Ease.InQuad);
        });
        yield return null;
    }
}
