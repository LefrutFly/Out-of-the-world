using UnityEngine;

public class Nipper : EnemyBaseBehaviour
{
    [Space]
    [SerializeField] public float shiftXPosPotrol;// = 1.2f;
    [SerializeField] public float radiusPotrol;// = 0.1f;

    [Space]
    [SerializeField] private float radiusAttack;// = 0.8f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float shiftXPosAttack;// = 1f;

    protected override void AwakeBehaviour()
    {
        AddBehaviourAlive();
        AddBehaviourAfterDeath();
        base.AwakeBehaviour();
    }

    private void AddBehaviourAlive()
    {
        BehaviorPatrol patrol = new BehaviorPatrol();
        patrol.shiftXPos = shiftXPosPotrol;
        patrol.radius = radiusPotrol;

        behaviours.Add(patrol);


        BehaviorAttack attack = new BehaviorAttack();
        attack.playerLayer = playerLayer;
        attack.radius = radiusAttack;
        attack.shiftXPos = shiftXPosAttack;

        behaviours.Add(attack);
    }

    private void AddBehaviourAfterDeath()
    {
        behavioursAfterDeath.Add(new BehaviourDestroy());
    }

}

