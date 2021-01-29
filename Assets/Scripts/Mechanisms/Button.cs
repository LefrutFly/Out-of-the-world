using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interacts<PlayerBehaviour>
{
    [SerializeReference] private List<IUse> usable = new List<IUse>();
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
        animator.enabled = true;
    }
}
