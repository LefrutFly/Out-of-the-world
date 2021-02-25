using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GeneralSetup generalSetup;
    [Space]
    [SerializeField] private Text textClock;
    [Space]
    [SerializeField] private Text textMessageForPlayer;
    [Space]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private GameObject[] pages;

    [Space]
    [SerializeField] private Toggle toggleEnableLevelHints;

    [Space]
    [SerializeField] public float delayPage;

    [Space]
    [SerializeField] private int pageNow = 0;

    [Space]
    [SerializeField] private bool reset = false;
    private void Awake()
    {
#if UNITY_EDITOR
        if (reset)
        {
            Saving.ResetSaves();
        }
#endif
        Saving.Load(generalSetup);
        toggleEnableLevelHints.isOn = generalSetup.drawLines;
        textMessageForPlayer.text = "";
    }

    private void Update()
    {
        UpdateClock();
    }

    private void UpdateClock()
    {
        DateTime time = DateTime.Now;
        string hour;
        string minute;
        if (time.Hour < 10)
        {
            hour = "0" + time.Hour;
        }
        else
        {
            hour = "" + time.Hour;
        }
        if (time.Minute < 10)
        {
            minute = "0" + time.Minute;
        }
        else
        {
            minute = "" + time.Minute;
        }
        textClock.text = hour + " : " + minute;
    }

    public void TurnPage(int to)
    {
        pages[pageNow].transform.DOMoveX(leftPoint.position.x, delayPage, false);
        pages[to].transform.DOMoveX(cameraPoint.position.x, delayPage, false);
        pageNow = to;
    }

    public void CancelPage(int pagePrevious)
    {
        pages[pageNow].transform.DOMoveX(rightPoint.position.x, delayPage, false);
        pages[pagePrevious].transform.DOMoveX(cameraPoint.position.x, delayPage, false);
        pageNow = pagePrevious;
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level_" + generalSetup.LastOpenLevel);
    }

    public void StartLevel(int level)
    {
        if (generalSetup.LastUnlockedLevel >= level)
        {
            SceneManager.LoadScene("Level_" + level);
        }
        else
        {
            if (!isClickOnShowMessage)
            {
                StartCoroutine(ShowMessage("Level not unlocked"));
            }
        }
    }

    public void EnableLevelHints(bool value)
    {
        if (value)
        {
            generalSetup.drawLines = true;
        }
        else
        {
            generalSetup.drawLines = false;
        }

        Saving.Save(generalSetup);
    }

    bool isClickOnShowMessage = false;
    public IEnumerator ShowMessage(string message)
    {
        isClickOnShowMessage = true;
        textMessageForPlayer.text = message;

        yield return new WaitForSeconds(0.5f);

        textMessageForPlayer.DOFade(0, 1.5f).OnComplete(() =>
        {
            textMessageForPlayer.text = "";
            textMessageForPlayer.DOFade(255, 0);
            isClickOnShowMessage = false;
        });
    }
}
