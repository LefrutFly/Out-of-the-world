using System.Collections;
using UnityEngine;

public class RotatableOnAngleObject : IUse
{
    [SerializeField] public float angelTo;
    [SerializeField] private float speed;

    public override void StartAction()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (!(Mathf.Approximately(transform.localEulerAngles.z, angelTo)))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angelTo), speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}