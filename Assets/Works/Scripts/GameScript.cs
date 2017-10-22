using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Insider;

public class GameScript : MonoBehaviour
{
    public Image redCircle;
    public Button button;
    public Text description;
    private int time = 3000;
    private bool isPlaying = false;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButton()
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

    private void StartGame()
    {
        isPlaying = true;
        StartCoroutine(AnswerTheme());
    }

    private void FinishGame()
    {
        isPlaying = false;
        button.gameObject.SetActive(false);
        description.text = "Find an insider!";
		StartCoroutine(FindeInsider());
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
				yield break;
            }
        }
    }
}
