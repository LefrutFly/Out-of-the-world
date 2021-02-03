using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private GameObject[] pages;

    [Space]
    [SerializeField] public int pagePrevious = 0;
    [SerializeField] public int pageNow = 0;

    [Space]
    [SerializeField] public float delayPage;

    public void Test()
    {
        Debug.Log("WORK!");
    }

    public void PlayButton()
    {
        pages[0].transform.DOMoveX(leftPoint.position.x, delayPage, false);
        pages[1].transform.DOMoveX(cameraPoint.position.x, delayPage, false);
        pagePrevious = 0;
        pageNow = 1;
    }

    public void CancelPage()
    {
        pages[pageNow].transform.DOMoveX(rightPoint.position.x, delayPage, false);
        pages[pagePrevious].transform.DOMoveX(cameraPoint.position.x, delayPage, false);
        int remember = pagePrevious;
        pagePrevious = pageNow;
        pageNow = remember;
    }

    public void NewGame()
    {

    }

    public void Contiinue()
    {

    }
}
