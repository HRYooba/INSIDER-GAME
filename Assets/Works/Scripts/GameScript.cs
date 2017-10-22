using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Insider;

public class GameScript : MonoBehaviour
{
    public Image redCircle;
    public Button themeButton;
    public Button insiderButton;
    public Text description;
    public CanvasGroup resultPanel;
    private int time = 3000;
    private bool isPlaying = false;
    private bool isDiscussion = false;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushThemeButton()
    {
        if (isPlaying)
        {
            FinishGame();
        }
        else
        {
            StartGame();
        }
    }

    public void PushInsiderButton()
    {
        if (isDiscussion)
        {
			StopAllCoroutines();
            StartFadeOut();
        }
        else
        {
            isDiscussion = true;
            StartCoroutine(FindeInsider());
        }
    }

    private void StartGame()
    {
        isPlaying = true;
        StartCoroutine(AnswerTheme());
    }

    private void FinishGame()
    {
        isPlaying = false;
        themeButton.gameObject.SetActive(false);
        insiderButton.gameObject.SetActive(true);
        description.text = "Find an insider!";
    }

    private IEnumerator AnswerTheme()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(0.1f);
            time--;
            redCircle.fillAmount = time / 3000.0f;

            if (time == 0)
            {
                yield return new WaitForSeconds(0.5f);
                yield break;
            }
        }
    }

    private IEnumerator FindeInsider()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time++;
            redCircle.fillAmount = time / 3000.0f;

            if (time == 3000)
            {
                yield return new WaitForSeconds(0.5f);
                StartFadeOut();
                yield break;
            }
        }
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
            resultPanel.DOFade(1.0f, 0.5f).SetEase(Ease.InQuad);
        });
        yield return null;
    }
}
