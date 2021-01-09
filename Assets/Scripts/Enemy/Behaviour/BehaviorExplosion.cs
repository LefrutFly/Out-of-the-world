using UnityEngine;

namespace EnemyBehaviour
{
    public class BehaviorExplosion : IBehaviour
    {
        public override void Init(EnemyBaseBehaviour gm)
        {
            Explosion explosion = new Explosion();
            explosion.Boom();
        }
    }

    [CreateAssetMenu(fileName = "Explosion", menuName = "Enemy/Behaviour/Explosion")]
    public class BehaviorExplosionSO : BehaviourSO
    {
        public BehaviorExplosionSO()
        {
            behaviour = new BehaviorExplosion();
        }
        public override void Init(EnemyBaseBehaviour gm)
        {
            base.Init(gm);
        }
    }
}

public class Explosion
{
    public void Boom()
    {
        ///TODO:  1)создать взрыв
        ///       2)нанести урон если player в радиусе взрыва
    }
}