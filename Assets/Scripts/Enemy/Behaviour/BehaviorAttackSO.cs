using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Enemy/Behaviour/Attack")]
public class BehaviorAttackSO : BehaviourSO
{
    private BehaviorAttack attack = new BehaviorAttack();

    [SerializeField] private float radius;// = 0.8f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float shiftXPos;// = 1f;

    public override void Init(EnemyBaseBehaviour gm)
    {
        attack.playerLayer = playerLayer;
        attack.radius = radius;
        attack.shiftXPos = shiftXPos;

        behaviour = attack;

        base.Init(gm);
    }
}