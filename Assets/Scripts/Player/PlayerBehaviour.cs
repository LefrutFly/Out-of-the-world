using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerSpace;

public class PlayerBehaviour : Being
{
    public static PlayerBehaviour player { get; private set; }
    [HideInInspector] public Rigidbody2D Rigidbody;

    [SerializeField] private GameObject SETUP;

    [Space]
    [SerializeField] public Animator animator;

    [Space]
    [SerializeField] public Transform groundCheck;
    [SerializeField] public float groundRadius;
    [SerializeField] public LayerMask whatIsGround;

    [Space]
    [SerializeField] public DataInventory inventory;

    public static Action<PlayerBehaviour> OnMoveLeft;
    public static Action<PlayerBehaviour> OnMoveRight;
    public static Action<PlayerBehaviour> OnJump;

    private Action OnMove;

    protected override void AwakeBehaviour()
    {
        player = this;
        Rigidbody = GetComponent<Rigidbody2D>();
        PlayerDoer playerDoer = new PlayerDoer();
        playerDoer.InitPlayer();
    }
    protected override void FixedUpdateBehaviour()
    {
        OnMove?.Invoke();
        ControlPC();
    }

    protected override void InitDeath()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        Debug.Log("PLAYER IS DEAD!");
        animator.enabled = false;
        OnJump = (player) => { };
        OnMoveLeft = (player) => { };
        OnMoveRight = (player) => { };

        yield return new WaitForSeconds(1);

        int level = SETUP.GetComponent<Level>().LevelInxdex;
        SceneManager.LoadScene("Level_" + level);
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
    private void MoveLeft()
    {
        OnMoveLeft?.Invoke(this);
    }
    private void MoveRight()
    {
        OnMoveRight?.Invoke(this);
    }
    private void Jump()
    {
        OnJump?.Invoke(this);
    }


    public void DownMoveLeft()
    {
        animator.SetInteger("stay", 1);
        OnMove = () =>
        {
            MoveLeft();
        };
    }
    public void DownMoveRight()
    {
        animator.SetInteger("stay", 1);
        OnMove = () =>
        {
            MoveRight();
        };
    }
    public void DownJump()
    {
        animator.SetInteger("stay", 2);
        Jump();
    }


    public void UpMoveLeft()
    {
        OnMove = () => { };
        animator.SetInteger("stay", 0);
    }
    public void UpMoveRight()
    {
        OnMove = () => { };
        animator.SetInteger("stay", 0);
    }
    public void UpJump()
    {
        animator.SetInteger("stay", 0);
    }
}
