using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionStart", menuName = "Enemy/Behaviour/ExplosionStart")]
public class BehaviorExplosionStartSO : BehaviourSO
{
    BehaviorExplosionStart explosionStart = new BehaviorExplosionStart();

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;
    [SerializeField] private float timeToBoom;

    public override void Init(EnemyBaseBehaviour gm)
    {
        explosionStart.playerLayer = playerLayer;
        explosionStart.radius = radius;
        explosionStart.timeToBoom = timeToBoom;

        behaviour = explosionStart;

        base.Init(gm);
    }
}