using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interacts<T> : MonoBehaviour //T - what will react to
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T obj) && AdditionalVerification())
        {
            DoThisAction();
        }
    }

    protected virtual bool AdditionalVerification()
    {
        return true;
    }
    protected abstract void DoThisAction();
}