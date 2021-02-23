using DG.Tweening;
using System;
using UnityEngine;

public class Teleport : IUseSwith
{
    public Action OnTeleport;

    [HideInInspector] public Vector2 positionTelepor;

    [SerializeField] public Teleport teleportTo;
    [SerializeField] public SpriteRenderer activityLamp;

    [SerializeField] private LineRenderer lines;
    [HideInInspector] public DrawLines drawLines = new DrawLines();

    private void Start()
    {
        Createposition();
        DrawLine();
    }

    public override void ActionOn()
    {
        activityLamp.DOColor(new Color(0, 255, 0), 0);
        OnTeleport = () =>
        {
            PlayerBehaviour.player.transform.position = teleportTo.positionTelepor;
            ActionOff();
        };
    }
    public override void ActionOff()
    {
        activityLamp.DOColor(new Color(255, 0, 0), 0);
        OnTeleport = () => { };
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            OnTeleport?.Invoke();
        }
    }

    private void Createposition()
    {
        positionTelepor = transform.position;
        positionTelepor.y -= 1.6f;
    }

    private void DrawLine()
    {
        LineRenderer[] lineRenderers = { lines };
        Teleport[] teleports = { teleportTo };
        DrawLines.OnDraw?.Invoke(gameObject, lineRenderers, teleports);
    }
}
