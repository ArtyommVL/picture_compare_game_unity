using UnityEngine;

namespace PlayerController.Mover
{
    public class MoveBack : IMover
    {
        public void Move(GameObject gameObject, bool canMove, float speed)
        {
            if (canMove)
            {
                gameObject.transform.position += Vector3.back * (speed * Time.deltaTime);
            }
        }
    }
}