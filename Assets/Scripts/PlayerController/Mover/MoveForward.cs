using UnityEngine;

namespace PlayerController.Mover
{
    public class MoveForward : IMover
    {
        public void Move(GameObject gameObject, bool canMove, float speed)
        {
            if (canMove)
            {
                gameObject.transform.position += Vector3.forward * (speed * Time.deltaTime);
            }
        }
    }
}