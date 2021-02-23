using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interacts<T> : MonoBehaviour //T - what will react to
{
    protected T collisionObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T obj) && AdditionalVerification())
        {
            collisionObj = obj;
            DoThisAction();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<T>(out T obj) && AdditionalVerification())
        {
            collisionObj = obj;
            DoIfExit();
        }
    }

    protected virtual bool AdditionalVerification()
    {
        return true;
    }
    protected abstract void DoThisAction();
    protected virtual void DoIfExit() { }
}