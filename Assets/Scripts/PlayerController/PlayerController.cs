using System;
using CustomInput.CustomInputReceiver;
using Grid;
using PlayerController.Mover;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float maxDistance = 1f;
        [SerializeField] private float moveSpeed = 0.5f;
        
        private readonly RaycastHit[] _raycastHit = new RaycastHit[5];
        private CubeUnit _currentCubeUnit;
        
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
            CustomInputReceiver.MoveAttack += OnMoveAttack;
        }

        private void Update()
        {
            _moveRight.Move(gameObject,_isMoveRight, moveSpeed);
            _moveLeft.Move(gameObject,_isMoveLeft, moveSpeed);
            _moveForward.Move(gameObject,_isMoveForward, moveSpeed);
            _moveBack.Move(gameObject,_isMoveBack, moveSpeed);
            
            _currentCubeUnit?.MoveWith(gameObject.transform);
        }
        
        private void FixedUpdate()
        {
            int hits = Physics.RaycastNonAlloc(playerCamera.transform.position, playerCamera.transform.forward, _raycastHit,
                maxDistance);
            for (int i = 0; i < hits; i++)
            {
                if (_raycastHit[i].collider.TryGetComponent<CubeUnit>(out var cubeUnit))
                {
                    _currentCubeUnit = cubeUnit;
                }
            }
            Array.Clear(_raycastHit,0,_raycastHit.Length);
        }

        private void ChangeStateCube(CubeUnit cubeUnit, bool isAttack)
        {
            if (cubeUnit is null)
            {
                return;
            }

            if (isAttack)
            {
                if (!cubeUnit.IsSelected)
                {
                    cubeUnit.IsSelected = true;
                    cubeUnit.SetSelectedColor(true);
                }
                else
                {
                    cubeUnit.IsSelected = false;
                    cubeUnit.SetSelectedColor(false);
                }
                
            }
        }
        
        private void OnDisable()
        {
            CustomInputReceiver.MoveRight -= OnMoveRight;
            CustomInputReceiver.MoveLeft -= OnMoveLeft;
            CustomInputReceiver.MoveForward -= OnMoveForward;
            CustomInputReceiver.MoveBack -= OnMoveBack;
            CustomInputReceiver.MoveAttack -= OnMoveAttack;
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

        private void OnMoveAttack(object sender, bool moveAttack)
        {
            ChangeStateCube(_currentCubeUnit, moveAttack);
        }
    }
}