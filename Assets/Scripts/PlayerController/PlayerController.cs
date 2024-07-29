using CustomInput.CustomInputReceiver;
using PlayerController.Mover;
using UnityEngine;
using Zenject;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0.5f;

        private CustomInputReceiver _customInputReceiver;
        private IMover _moveRight;
        private IMover _moveLeft;
        private IMover _moveForward;
        private IMover _moveBack;
        
        private bool _isMoveRight;
        private bool _isMoveLeft;
        private bool _isMoveForward;
        private bool _isMoveBack;

        [Inject]
        public void Init(
            CustomInputReceiver customInputReceiver,
            MoveRight moveRight, 
            MoveLeft moveLeft, 
            MoveForward moveForward, 
            MoveBack moveBack)
        {
            _customInputReceiver = customInputReceiver;
            _moveRight = moveRight;
            _moveLeft = moveLeft;
            _moveForward = moveForward;
            _moveBack = moveBack;
        }

        private void OnEnable()
        {
            _customInputReceiver.MoveRight += OnMoveRight;
            _customInputReceiver.MoveLeft += OnMoveLeft;
            _customInputReceiver.MoveForward += OnMoveForward;
            _customInputReceiver.MoveBack += OnMoveBack;
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
            _customInputReceiver.MoveRight -= OnMoveRight;
            _customInputReceiver.MoveLeft -= OnMoveLeft;
            _customInputReceiver.MoveForward -= OnMoveForward;
            _customInputReceiver.MoveBack -= OnMoveBack;
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