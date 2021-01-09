using UnityEngine;
using EnemyBehaviour;

public class BehaviourSO : ScriptableObject
{
    protected IBehaviour behaviour;
    public virtual void Init(EnemyBaseBehaviour gm)
    {
        behaviour.Init(gm);
    }
}
