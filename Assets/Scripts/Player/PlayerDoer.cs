using UnityEngine;

namespace PlayerSpace
{
    public class PlayerDoer
    {
        public void InitPlayer()
        {
            PlayerBehaviour.OnJump = (player) =>
            {
                if (player.isGround())
                {
                    player.Rigidbody.AddForce(player.Speed.jumpForce);
                }
            };

            PlayerBehaviour.OnMoveLeft = (player) =>
            {
                player.view.transform.rotation = Quaternion.Euler(0, 180, 0);
                if (player.isGround())
                {
                    player.gameObject.MovePosition(player.Speed.moveSpeed, new Vector3(-1, 0, 0));
                }
                else
                {
                    player.gameObject.MovePosition(player.Speed.moveSpeedInAir, new Vector3(-1, 0, 0));
                }
            };

            PlayerBehaviour.OnMoveRight = (player) =>
            {
                player.view.transform.rotation = Quaternion.Euler(0, 0, 0);
                if (player.isGround())
                {
                    player.gameObject.MovePosition(player.Speed.moveSpeed, new Vector3(1, 0, 0));
                }
                else
                {
                    player.gameObject.MovePosition(player.Speed.moveSpeedInAir, new Vector3(1, 0, 0));
                }
            };
        }
    }
}