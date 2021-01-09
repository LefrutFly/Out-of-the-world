using System.Collections;
using UnityEngine;

namespace EnemyBehaviour
{
    class BehaviorAttack : IBehaviour
    {
        private EnemyBaseBehaviour gm;

        private float radius = 1.2f;
        public LayerMask playerLayer;

        private float shiftXPos = 2.2f;
        private Vector2 leftPointCheck = new Vector2(0, 0);
        private Vector2 rightPointCheck = new Vector2(0, 0);

        private bool isPlayer = false;
        private bool isCoroutineStart = false;

        public BehaviorAttack()
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
            CheckPoints();
            AttackInit();
        }

        private void AttackInit()
        {
            if (isPlayer && !isCoroutineStart)
            {
                gm.StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            isCoroutineStart = true;
            PlayerBehaviour.player.hp.TakeDamage(gm.enemySO.damage);
            yield return new WaitForSeconds(1f);
            isCoroutineStart = false;
        }

        private void CheckPoints()
        {
            if (gm.transform.rotation.y == 180)
            {
                isPlayer = isCollision(rightPointCheck);
            }
            else
            {
                isPlayer = isCollision(leftPointCheck);
            }
        }

        private void CreatePointsCheck()
        {
            leftPointCheck = new Vector2(gm.transform.position.x - shiftXPos, gm.transform.position.y);
            rightPointCheck = new Vector2(gm.transform.position.x + shiftXPos, gm.transform.position.y);
        }

        private bool isCollision(Vector2 checkPosition)
        {
            return Physics2D.OverlapCircle(checkPosition, radius, playerLayer);
        }
    }

    [CreateAssetMenu(fileName = "Attack", menuName = "Enemy/Behaviour/Attack")]
    public class BehaviorAttackSO : BehaviourSO
    {
        [SerializeField] private float shiftXPos;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask playerLayer;

        public BehaviorAttackSO()
        {
            behaviour = new BehaviorAttack();
        }
        public override void Init(EnemyBaseBehaviour gm)
        {
            base.Init(gm);
        }
    }

}