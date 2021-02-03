using System;
using UnityEngine;

public class Awaker : MonoBehaviour
{
    public static Action OnAwake;
    public static Action OnAwake2;

    private void Awake()
    {
        OnAwake?.Invoke();
        OnAwake2?.Invoke();
    }
}
