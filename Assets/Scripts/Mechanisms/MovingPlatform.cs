using UnityEngine;
using DG.Tweening;

public class MovingPlatform : Interacts<PlayerBehaviour>
{
    [SerializeField] private GameObject leftPoint;
    [SerializeField] private GameObject rightPoint;
    [Space]
    [SerializeField] private float duration;
    [Space]
    [SerializeField] private bool isRight = true;

    private void Start()
    {
        if (isRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        transform.DOMove(rightPoint.transform.position, duration, false).OnComplete(MoveLeft);
    }
    private void MoveLeft()
    {
        transform.DOMove(leftPoint.transform.position, duration, false).OnComplete(MoveRight);
    }

    protected override void DoThisAction()
    {
        collisionObj.transform.SetParent(transform);
    }
    protected override void DoIfExit()
    {
        collisionObj.transform.SetParent(null);
    }
}
