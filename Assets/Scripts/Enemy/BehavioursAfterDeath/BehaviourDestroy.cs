using UnityEngine;

//namespace EnemyBehaviour
//{
public class BehaviourDestroy : IBehaviour
    {
        public override void Init(EnemyBaseBehaviour gm)
        {
            GameObject.Destroy(gm.gameObject);
        }
    }

//}