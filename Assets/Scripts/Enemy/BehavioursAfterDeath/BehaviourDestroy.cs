using UnityEngine;

namespace EnemyBehaviour
{
    public class BehaviourDestroy : IBehaviour
    {
        public override void Init(EnemyBaseBehaviour gm)
        {
            GameObject.Destroy(gm.gameObject);
        }
    }


    [CreateAssetMenu(fileName = "Destroy", menuName = "Enemy/Behaviour/Destroy")]
    public class BehaviourDestroySO : BehaviourSO
    {
        public override void Init(EnemyBaseBehaviour gm)
        {
            behaviour = new BehaviourDestroy();
            base.Init(gm);
        }
    }

}