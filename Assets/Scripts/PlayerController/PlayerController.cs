using CustomInput.CustomInputReceiver;
using PlayerController.Mover;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0.5f;
        
        private IMover _moveRight;
        private IMover _moveLeft;
        private IMover _moveForward;
        private IMover _moveBack;
        
        private bool _isMoveRight;
        private bool _isMoveLeft;
        private bool _isMoveForward;
        private bool _isMoveBack;

        private void Awake()
        {
            _moveRight = new MoveRight();
            _moveLeft = new MoveLeft();
            _moveForward = new MoveForward();
            _moveBack = new MoveBack();
        }

        private void OnEnable()
        {
            CustomInputReceiver.MoveRight += OnMoveRight;
            CustomInputReceiver.MoveLeft += OnMoveLeft;
            CustomInputReceiver.MoveForward += OnMoveForward;
            CustomInputReceiver.MoveBack += OnMoveBack;
        }

        private void Update()
        {
            _moveRight.Move(gameObject,_isMoveRight, moveSpeed);
            _moveLeft.Move(gameObject,_isMoveLeft, moveSpeed);
            _moveForward.Move(gameObject,_isMoveForward, moveSpeed);
            _moveBack.Move(gameObject,_isMoveBack, moveSpeed);
        }
        
        private void OnDisable()
        {
            CustomInputReceiver.MoveRight -= OnMoveRight;
            CustomInputReceiver.MoveLeft -= OnMoveLeft;
            CustomInputReceiver.MoveForward -= OnMoveForward;
            CustomInputReceiver.MoveBack -= OnMoveBack;
        }

        private void OnMoveRight(object sender, bool moveRight)
        {
            _isMoveRight = moveRight;
        }

        private void OnMoveLeft(object sender, bool moveLeft)
        {
            _isMoveLeft = moveLeft;
        }

        private void OnMoveForward(object sender, bool moveForward)
        {
            _isMoveForward = moveForward;
        }

        private void OnMoveBack(object sender, bool moveBack)
        {
            _isMoveBack = moveBack;
        }
    }
}