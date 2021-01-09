using UnityEngine;

namespace PlayerSpace
{
    public class PlayerDoer
    {
        private bool isGround(PlayerBehaviour player)
        {
            return Physics2D.OverlapCircle(player.groundCheck.position, player.groundRadius, player.whatIsGround);
        }

        public void InitPlayer()
        {
            PlayerBehaviour.OnJump = (player) =>
            {
                if (isGround(player))
                {
                    player.Rigidbody.AddForce(player.Speed.jumpForce);
                }
            };

            PlayerBehaviour.OnMoveLeft = (player) =>
            {
                player.view.transform.rotation = Quaternion.Euler(0, 180, 0);
                if (isGround(player))
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
                if (isGround(player))
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