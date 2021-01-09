using System.Collections;
using UnityEngine;


namespace EnemyBehaviour
{
    public class BehaviorExplosionStart : IBehaviour
    {
        private EnemyBaseBehaviour gm;

        private float radius = 3f;
        public LayerMask playerLayer;

        private Vector2 pointCheck = new Vector2(0, 0);

        bool isExplosion = false;

        public BehaviorExplosionStart()
        {
            Awaker.OnAwake2 += () =>
            {
                playerLayer = LayerMask.GetMask("Player");
            };
        }

        public override void Init(EnemyBaseBehaviour gm)
        {
            this.gm = gm;
            CreatePointsCheck();
            StartExplosion();
        }



        private void StartExplosion()
        {
            if (isCollision() && !isExplosion)
            {
                gm.StartCoroutine(Explosion());
            }
        }
        private IEnumerator Explosion()
        {
            isExplosion = true;
            yield return new WaitForSeconds(0.8f);
            Explosion explosion = new Explosion();
            explosion.Boom();
        }
        private void CreatePointsCheck()
        {
            pointCheck = gm.transform.position;
        }

        private bool isCollision()
        {
            return Physics2D.OverlapCircle(pointCheck, radius, playerLayer);
        }
    }


    [CreateAssetMenu(fileName = "ExplosionStart", menuName = "Enemy/Behaviour/ExplosionStart")]
    public class BehaviorExplosionStartSO : BehaviourSO
    {
        public BehaviorExplosionStartSO()
        {
            behaviour = new BehaviorExplosion();
        }
        public override void Init(EnemyBaseBehaviour gm)
        {
            base.Init(gm);
        }
    }

}