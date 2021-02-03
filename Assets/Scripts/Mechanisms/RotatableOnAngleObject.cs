using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RotatableOnAngleObject : IUse
{
    [SerializeField] public float angelTo;
    [SerializeField] private float duration;

    public override void StartAction()
    {
        transform.DORotate(new Vector3(0, 0, angelTo), duration);
    }
}