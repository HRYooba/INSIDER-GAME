using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Insider;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{

    public Text theme;
    public Text insider;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText()
    {
        theme.text = Answer.theme;
        insider.text = "PLAYER" + (Answer.insider + 1);
    }

    public void Reset()
    {
        Settings.DestroyPlayerList();
        SceneManager.LoadScene("GameScene");
    }
}
