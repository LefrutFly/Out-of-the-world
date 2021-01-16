using UnityEngine;

public class Explosion
{
    private EnemyBaseBehaviour gm;

    public float radius = 3f;
    public LayerMask playerLayer;
    private Vector2 pointCheck;

    public void Boom(EnemyBaseBehaviour gm)
    {
        this.gm = gm;
        CreatePointsCheck();
        MakeDamage();
    }

    private void MakeDamage()
    {
        if (isCollision())
        {
            Debug.Log("DAMAGE!");
            PlayerBehaviour.player.hp.TakeDamage(gm.enemySO.damage);
        }
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