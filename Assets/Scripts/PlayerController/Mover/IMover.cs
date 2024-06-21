using UnityEngine;

namespace PlayerController.Mover
{
    public interface IMover
    {
        public void Move(GameObject gameObject,bool canMove, float speed);
    }
}