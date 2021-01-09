using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage;

    private Being being;
    private IEnumerator takeDamage;
    private void Start()
    {
        takeDamage = TakeDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Being>(out Being _being))
        {
            being = _being;
            StartCoroutine(takeDamage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Being>(out Being _being))
        {
            being = _being;
            StopCoroutine(takeDamage);
        }
    }

    private IEnumerator TakeDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            being.hp.TakeDamage(damage);
        }
    }
}
