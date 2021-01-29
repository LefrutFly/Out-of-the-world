using System.Collections;
using UnityEngine;


//namespace EnemyBehaviour
//{
public class BehaviorExplosionStart : IBehaviour
{
    private EnemyBaseBehaviour gm;

    public float radius;
    public LayerMask playerLayer;
    public float timeToBoom;

    private Vector2 pointCheck = new Vector2(0, 0);

    bool isExplosion = false;

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
        yield return new WaitForSeconds(timeToBoom);
        Explosion explosion = new Explosion();
        explosion.playerLayer = playerLayer;
        explosion.radius = radius;
        explosion.Boom(gm);
        BehaviourDestroy destroy = new BehaviourDestroy();
        destroy.Init(gm);
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

//}