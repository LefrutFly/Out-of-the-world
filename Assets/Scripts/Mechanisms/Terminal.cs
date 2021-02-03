using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Terminal : Interacts<PlayerBehaviour>
{
    [SerializeField] private int keyIndex;

    [Space]
    [SerializeReference, Tooltip("IUse")] public List<IUse> usable = new List<IUse>();
    [SerializeReference, Tooltip("IUseSwith On")] public List<IUseSwith> usableSwitchOn = new List<IUseSwith>();
    [SerializeReference, Tooltip("IUseSwith Off")] public List<IUseSwith> usableSwitchOff = new List<IUseSwith>();
    [SerializeField] private LineRenderer[] lines;
    [SerializeField, Tooltip("«адержка перед каждой активацией")] public float timeDelay;

    public Action action;//чтобы можно было мен€ть цель использовани€ терминала

    protected override void DoThisAction()
    {
        action?.Invoke();
    }

    private void Start()
    {
        DrawLine();

        action = () =>
        {
            foreach (var key in collisionObj.inventory.keys)
            {
                if (key.keyIndex == keyIndex)
                {
                    StartCoroutine(DoIUse());
                    StartCoroutine(DoIUseSwithOn());
                    StartCoroutine(DoIUseSwithOff());
                    collisionObj.inventory.keys.Remove(key);
                    break;
                }
            }
        };
    }

    private IEnumerator DoIUse()
    {
        foreach (var doThis in usable)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.StartAction();
        }
    }
    private IEnumerator DoIUseSwithOn()
    {
        foreach (var doThis in usableSwitchOn)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.ActionOn();
        }
    }
    private IEnumerator DoIUseSwithOff()
    {
        foreach (var doThis in usableSwitchOff)
        {
            yield return new WaitForSeconds(timeDelay);
            doThis.ActionOff();
        }
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
            foreach (var obj in usableSwitchOn)
            {
                lines[index].SetPosition(0, positionButton);
                lines[index].SetPosition(1, obj.transform.position);
                index++;
            }
            foreach (var obj in usableSwitchOff)
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
