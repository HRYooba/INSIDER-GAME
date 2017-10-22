using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Insider;

public class PlayerSettingScript : MonoBehaviour
{

    public Text playerNumText;
    public Slider playerNumSlider;
    public CanvasGroup confirmPlayerPanel;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerNumText.text = playerNumSlider.value.ToString();
    }

    public void StartFadeOut()
    {
		Settings.SetPlayerCount((int)playerNumSlider.value);
		Settings.CreatePlayerList();
        confirmPlayerPanel.gameObject.GetComponent<ConfirmPlayerScript>().CreatePlayerPanels();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvas = gameObject.GetComponent<CanvasGroup>();
		canvas.DOFade(0.0f, 1.0f).SetEase(Ease.InQuad).OnComplete(() => {
			gameObject.SetActive(false);
            confirmPlayerPanel.DOFade(1.0f, 0.5f).SetEase(Ease.InQuad);
		});
        yield return null;
    }
}
