//using EnemyBehaviour;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : Being
{
    [SerializeField] public EnemySO enemySO;

    [HideInInspector] public Vector2 startPoint;
    [SerializeField] public bool rotateIsRight = true;
    [HideInInspector] public PlayerBehaviour player;

    [HideInInspector] public List<IBehaviour> behaviours = new List<IBehaviour>();
    [HideInInspector] public List<IBehaviour> behavioursAfterDeath = new List<IBehaviour>();

    protected override void AwakeBehaviour()
    {
        startPoint = transform.position;
        hp.SetHPMax(enemySO.hpMax);
        Speed.moveSpeed = enemySO.moveSpeed;
    }

    protected override void FixedUpdateBehaviour()
    {
        foreach (var doThis in behaviours)
        {
            doThis?.Init(this);
        }
    }
    protected override void InitDeath()
    {
        player = PlayerBehaviour.player;
        Debug.Log("Dead");
        foreach (var doThis in behavioursAfterDeath)
        {
            doThis?.Init(this);
        }
    }
}
