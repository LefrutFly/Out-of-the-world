using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Door : IUseSwith
{
    [SerializeField] private GameObject door;
    [SerializeField] private float openDoorHeight;
    [SerializeField] private float closeDoorHeight;
    [SerializeField] private float duration;

    private float yPosStart;

    private void Start()
    {
        yPosStart = transform.position.y;
    }

    public override void ActionOn()
    {
        door.transform.DOMoveY(yPosStart + openDoorHeight, duration, false);
    }
    
    public override void ActionOff()
    {
        door.transform.DOMoveY(yPosStart + closeDoorHeight, duration, false);
    }
}
