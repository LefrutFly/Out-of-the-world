using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : Interacts<PlayerBehaviour>
{
    [SerializeReference] private List<IUseSwith> usable = new List<IUseSwith>();
    [SerializeField, Tooltip("Задержка перед каждой активацией")] private float timeDelay;

    [Space]
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Space]
    [Header("System")]
    [SerializeField] private bool isActive = false;

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
        
    }
    private void AnimationOff()
    {

    }
}
