using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GeneralSetup generalSetup;
    [Space]
    [SerializeField] private Text textClock;
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


    private void Awake()
    {
        toggleEnableLevelHints.isOn = generalSetup.drawLines;
    }

    private void Update()
    {
        DateTime time = DateTime.Now;
        string hour;
        if (time.Hour == 0)
        {
            hour = "00";
        }
        else
        {
            hour = "" + time.Hour;
        }
        textClock.text = hour + " : " + time.Minute;
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

    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene("Level_" + level);
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
    }
}
