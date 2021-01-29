public class BehaviorExplosion : IBehaviour
{
    public Explosion explosion = new Explosion();
    public override void Init(EnemyBaseBehaviour gm)
    {
        explosion.Boom(gm);
    }
}