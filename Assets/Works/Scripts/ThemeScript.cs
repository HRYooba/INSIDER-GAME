using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Insider;

public class ThemeScript : MonoBehaviour
{

    public Text text;
    public Button button;
    public Button nextButton;
	public CanvasGroup gamePanel;
    private string theme;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
        nextButton.gameObject.SetActive(false);
        text.GetComponent<CanvasGroup>().alpha = 0.0f;
		Settings.CreateTheme();
		theme = Answer.theme;
        text.text = theme;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartFadeOutButton()
    {
        button.enabled = false;
        StartCoroutine(FadeOutButton());
    }

    private IEnumerator FadeOutButton()
    {
        button.GetComponent<CanvasGroup>().DOFade(0.0f, 0.8f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            text.GetComponent<CanvasGroup>().DOFade(1.0f, 1.2f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                nextButton.gameObject.SetActive(true);
            });
        });
        yield return null;
    }

	public void StartFadeOut() {
		StartCoroutine(FadeOut());
	}

    private IEnumerator FadeOut()
    {
        CanvasGroup canvas = gameObject.GetComponent<CanvasGroup>();
        canvas.DOFade(0.0f, 1.0f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            gameObject.SetActive(false);
            gamePanel.DOFade(1.0f, 0.5f).SetEase(Ease.InQuad);
        });
        yield return null;
    }
}
