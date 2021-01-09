using UnityEngine;

namespace EnemyBehaviour
{
    class BehaviorPatrol : IBehaviour
    {
        private EnemyBaseBehaviour gm;

        private float shiftXPos = 1.2f;
        private Vector2 leftPointCheck = new Vector2(0, 0);
        private Vector2 rightPointCheck = new Vector2(0, 0);

        private float radius = 0.1f;
        public LayerMask groundLayer;

        private float speed = 0;
        private Vector3 direction = new Vector3(1, 0, 0);

        public BehaviorPatrol()
        {
            Awaker.OnAwake2 += () =>
            {
                groundLayer = LayerMask.GetMask("Ground");
            };
        }

        public override void Init(EnemyBaseBehaviour gm)
        {
            this.gm = gm;
            speed = gm.Speed.moveSpeed;
            groundLayer = LayerMask.GetMask("Ground");
            CreatePointsCheck();
            Move();
        }

        private void Move()
        {
            if (isGround(leftPointCheck))
            {
                direction.x = 1;
                gm.view.transform.rotation = Quaternion.Euler(0, 0, 0);
                gm.gameObject.MovePosition(speed, direction);
            }
            else if (isGround(rightPointCheck))
            {
                direction.x = -1;
                gm.view.transform.rotation = Quaternion.Euler(0, 180, 0);
                gm.gameObject.MovePosition(speed, direction);
            }
            else
            {
                gm.gameObject.MovePosition(speed, direction);
            }
        }

        private void CreatePointsCheck()
        {
            leftPointCheck = new Vector2(gm.transform.position.x - shiftXPos, gm.transform.position.y);
            rightPointCheck = new Vector2(gm.transform.position.x + shiftXPos, gm.transform.position.y);
        }

        private bool isGround(Vector2 checkPosition)
        {
            return Physics2D.OverlapCircle(checkPosition, radius, groundLayer);
        }
    }

    [CreateAssetMenu(fileName = "Patrol", menuName = "Enemy/Behaviour/Patrol")]
    public class BehaviorPatrolSO : BehaviourSO
    {
        public BehaviorPatrolSO()
        {
            behaviour = new BehaviorPatrol();
        }
        public override void Init(EnemyBaseBehaviour gm)
        {
            base.Init(gm);
        }
    }

}