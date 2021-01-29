using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Door : IUseSwith
{
    [SerializeField] private GameObject door;
    [SerializeField] private float openDoorHeight;
    [SerializeField] private float closeDoorHeight;
    [SerializeField] private float duration;
    
    public override void ActionOn()
    {
        door.transform.DOMoveY(openDoorHeight, duration, false);
    }
    
    public override void ActionOff()
    {
        door.transform.DOMoveY(closeDoorHeight, duration, false);
    }
}
