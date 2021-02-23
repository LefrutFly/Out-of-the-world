using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Button : Interacts<PlayerBehaviour>
{
    [SerializeReference] private IUse[] usable;
    [SerializeField, Tooltip("Задержка перед каждой активацией")] private float timeDelay;
    
    [Space]
    [SerializeField] private LineRenderer[] lines;
    [HideInInspector] public DrawLines drawLines = new DrawLines();

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
        plateHeightBot += transform.position.y;
        plate.transform.DOMoveY(plateHeightBot, duration, false);
        plate.GetComponent<SpriteRenderer>().DOColor(new Color32(35, 35, 35, 255), duration);
    }

    private void DrawLine()
    {
        DrawLines.OnDraw?.Invoke(gameObject, lines, usable);
    }
}
