using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : Interacts<PlayerBehaviour>
{
    [SerializeReference] private List<IUseSwith> usable = new List<IUseSwith>();
    [SerializeField] private LineRenderer[] lines;
    [SerializeField, Tooltip("Задержка перед каждой активацией")] private float timeDelay;

    [Space]
    [Header("Animation")]
    [SerializeField] private GameObject switchObj;
    [SerializeField] private Transform pointOn;
    [SerializeField] private Transform pointOff;

    [Space]
    [Header("System")]
    [SerializeField] private bool isActive = false;

    private void Start()
    {
        DrawLine();
    }

    protected override void DoThisAction()
    {
        if (!isActive)
        {
            isActive = true;
            AnimationOn();
            StartCoroutine(On());
        }
        else
        {
            isActive = false;
            AnimationOff();
            StartCoroutine(Off());
        }
    }

    private IEnumerator On()
    {
        foreach (var doThis in usable)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.ActionOn();
        }
    }
    private IEnumerator Off()
    {
        foreach (var doThis in usable)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.ActionOff();
        }
    }

    private void AnimationOn()
    {
        switchObj.transform.DOMove(pointOn.position, 0.5f, false);
        switchObj.GetComponent<SpriteRenderer>().DOColor(new Color32(33, 144, 0, 255), 0);
    }
    private void AnimationOff()
    {
        switchObj.transform.DOMove(pointOff.position, 0.5f, false);
        switchObj.GetComponent<SpriteRenderer>().DOColor(new Color(200, 33, 0, 255), 0);
    }

    private void DrawLine()
    {
        Vector2 positionButton = transform.position;

        int index = 0;
        if (lines.Length >= usable.Count)
        {
            foreach (var obj in usable)
            {
                lines[index].SetPosition(0, positionButton);
                lines[index].SetPosition(1, obj.transform.position);
                index++;
            }
        }
        else
        {
            Debug.LogError("Not enough lines, stoped in : " + index);
        }
    }
}
