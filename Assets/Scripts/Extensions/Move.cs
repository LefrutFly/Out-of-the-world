using UnityEngine;

public static class Move
{
    public static void MoveVelocity(this Rigidbody2D rigidbody, float speedHorizontally, float speedVertical)
    {
        rigidbody.velocity = new Vector2(speedHorizontally, speedVertical) * Time.deltaTime;
    }
    public static void MovePosition(this GameObject gm, float speed, Vector3 direction)
    {
        gm.transform.position = Vector2.MoveTowards(gm.transform.position, gm.transform.position + direction, speed * Time.deltaTime);
    }
}