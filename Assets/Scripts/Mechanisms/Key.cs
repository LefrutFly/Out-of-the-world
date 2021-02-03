using UnityEngine;

public class Key : Interacts<PlayerBehaviour>
{
    [SerializeField] private DataKey key;
    protected override void DoThisAction()
    {
        collisionObj.inventory.keys.Add(key);
        Destroy(gameObject);
    }
}
