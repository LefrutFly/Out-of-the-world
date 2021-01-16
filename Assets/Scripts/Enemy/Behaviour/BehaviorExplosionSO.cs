using UnityEngine;

[CreateAssetMenu(fileName = "Explosion", menuName = "Enemy/Behaviour/Explosion")]
public class BehaviorExplosionSO : BehaviourSO
{
    BehaviorExplosion explosion = new BehaviorExplosion();

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;

    public override void Init(EnemyBaseBehaviour gm)
    {
        explosion.explosion.playerLayer = playerLayer;
        explosion.explosion.radius = radius;
        behaviour = explosion;

        base.Init(gm);
    }
}
