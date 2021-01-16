using UnityEngine;

[CreateAssetMenu(fileName = "Destroy", menuName = "Enemy/Behaviour/Destroy")]
    public class BehaviourDestroySO : BehaviourSO
    {
        public BehaviourDestroySO()
        {
            behaviour = new BehaviourDestroy();
        }
    }

//}