using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;
    public int hpMax;
    public int damage;
}
