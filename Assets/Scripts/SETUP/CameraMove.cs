using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed;

    private Vector3 cameraaPosition;
    private void FixedUpdate()
    {
        cameraaPosition = new Vector3(target.position.x, transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, cameraaPosition, speed * Time.deltaTime);
    }
}
