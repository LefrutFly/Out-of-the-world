using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interacts<Rigidbody2D>
{
    [SerializeReference] private List<IUse> usable = new List<IUse>();
    [SerializeField] private LineRenderer[] lines;
    [SerializeField, Tooltip("Задержка перед каждой активацией")] private float timeDelay;

    [Space]
    [SerializeField] private GameObject plate;
    [SerializeField] private float plateHeightBot;
    [SerializeField] private float duration;

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
            AnimationStart();
            StartCoroutine(DoThisActionWhithDelay());
        }
    }

    private IEnumerator DoThisActionWhithDelay()
    {
        foreach (var doThis in usable)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.StartAction();
        }
    }

    private void AnimationStart()
    {
        plate.transform.DOMoveY(plateHeightBot, duration, false);
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
