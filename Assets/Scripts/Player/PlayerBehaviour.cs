using System;
using UnityEngine;
using PlayerSpace;

public class PlayerBehaviour : Being
{
    public static PlayerBehaviour player { get; private set; }

    [HideInInspector] public Rigidbody2D Rigidbody;

    [Space]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask whatIsGround;


    public static Action<PlayerBehaviour> OnMoveLeft;
    public static Action<PlayerBehaviour> OnMoveRight;
    public static Action<PlayerBehaviour> OnJump;


    protected override void AwakeBehaviour()
    {
        player = this;
        Rigidbody = GetComponent<Rigidbody2D>();
        PlayerDoer playerDoer = new PlayerDoer();
        playerDoer.InitPlayer();
    }
    protected override void FixedUpdateBehaviour()
    {
        ControlPC();
    }

    private void ControlPC()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    public bool isGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    public void MoveLeft()
    {
        OnMoveLeft?.Invoke(this);
    }
    public void MoveRight()
    {
        OnMoveRight?.Invoke(this);
    }
    public void Jump()
    {
        OnJump?.Invoke(this);
    }

    protected override void InitDeath()
    {
        Debug.LogError("PLAYER IS DEAD!");
        OnJump = (player) => { };
        OnMoveLeft = (player) => { };
        OnMoveRight = (player) => { };
    }
}