using UnityEngine;

[CreateAssetMenu(fileName = "Patrol", menuName = "Enemy/Behaviour/Patrol")]
public class BehaviorPatrolSO : BehaviourSO
{
    BehaviorPatrol patrol = new BehaviorPatrol();

    public float shiftXPos;// = 1.2f;
    public float radius;// = 0.1f;

    public override void Init(EnemyBaseBehaviour gm)
    {
        patrol.shiftXPos = shiftXPos;
        patrol.radius = radius;

        behaviour = patrol;

        base.Init(gm);
    }
}