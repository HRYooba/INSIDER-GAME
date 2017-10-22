using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Insider;
using DG.Tweening;

public class ConfirmPlayerScript : MonoBehaviour
{

    public GameObject commonPrefab;
    public GameObject insiderPrefab;
    public GameObject masterPrefab;
    public Button nextButton;
	public CanvasGroup themePanel;
    private int playerNum = 0;
    private List<GameObject> playerPanels = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreatePlayerPanels()
    {
        var parent = gameObject.transform;
        for (int i = 0; i < Settings.GetplayerCount(); i++)
        {

            switch (Settings.GetPlayerStatus(i))
            {
                case Status.Common:
                    GameObject common = Instantiate(commonPrefab, Vector3.zero, Quaternion.identity, parent);
                    playerPanels.Add(common);
                    break;

                case Status.Insider:
                    GameObject insider = Instantiate(insiderPrefab, Vector3.zero, Quaternion.identity, parent);
                    playerPanels.Add(insider);
                    break;

                case Status.Master:
                    GameObject master = Instantiate(masterPrefab, Vector3.zero, Quaternion.identity, parent);
                    playerPanels.Add(master);
                    break;
            }

            playerPanels[i].GetComponent<PlayerStatusPanelScript>().playerName.text = "PLAYER " + (i + 1);
            playerPanels[i].SetActive(false);
        }

        playerPanels[0].SetActive(true);
    }

    public void Next()
    {
        playerPanels[playerNum].SetActive(false);
        playerNum++;
        if (playerNum < Settings.GetplayerCount())
        {
            playerPanels[playerNum].SetActive(true);
        }
        else
        {
			nextButton.enabled = false;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvas = gameObject.GetComponent<CanvasGroup>();
        canvas.DOFade(0.0f, 1.0f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            gameObject.SetActive(false);
            themePanel.DOFade(1.0f, 0.5f).SetEase(Ease.InQuad);
        });
        yield return null;
    }
}
