using UnityEngine;

namespace PlayerController.Mover
{
    public class MoveRight : IMover
    {
        public void Move(GameObject gameObject, bool canMove, float speed)
        {
            if (canMove)
            {
                gameObject.transform.position += Vector3.right * (speed * Time.deltaTime);
            }
        }
    }
}