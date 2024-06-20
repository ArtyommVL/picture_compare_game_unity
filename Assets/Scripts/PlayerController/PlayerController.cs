using CustomInput.CustomInputReceiver;
using Grid;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float maxDistance = 1f;
        [SerializeField] private float moveSpeed = 0.5f;
        
        private Ray _ray;
        private readonly RaycastHit[] _raycastHit = new RaycastHit[5];
        private bool _moveRight;
        private bool _moveLeft;
        private bool _moveForward;
        private bool _moveBack;
        private bool _moveAttack;

        private void OnEnable()
        {
            CustomInputObserver.MoveRight += OnMoveRight;
            CustomInputObserver.MoveLeft += OnMoveLeft;
            CustomInputObserver.MoveForward += OnMoveForward;
            CustomInputObserver.MoveBack += OnMoveBack;
            CustomInputObserver.MoveAttack += OnMoveAttack;
        }

        private void Update()
        {
            if (_moveForward)
            {
                transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
            }
            if (_moveBack)
            {
                transform.position += Vector3.back * (moveSpeed * Time.deltaTime);
            }
            if (_moveRight)
            {
                transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
            }
            if (_moveLeft)
            {
                transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            }
        }


        private void FixedUpdate()
        {
            _ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            int hits = Physics.RaycastNonAlloc(playerCamera.transform.position, playerCamera.transform.forward, _raycastHit,
                maxDistance);
            for (int i = 0; i < hits; i++)
            {
                if (_raycastHit[i].collider.TryGetComponent<CubeUnit>(out var cubeUnit))
                {
                    cubeUnit.SetSelectedColor(true);
                }
            }
        }
        
        private void OnDisable()
        {
            CustomInputObserver.MoveRight -= OnMoveRight;
            CustomInputObserver.MoveLeft -= OnMoveLeft;
            CustomInputObserver.MoveForward -= OnMoveForward;
            CustomInputObserver.MoveBack -= OnMoveBack;
            CustomInputObserver.MoveAttack -= OnMoveAttack;
        }

        private void OnMoveRight(object sender, bool moveRight)
        {
            _moveRight = moveRight;
        }

        private void OnMoveLeft(object sender, bool moveLeft)
        {
            _moveLeft = moveLeft;
        }

        private void OnMoveForward(object sender, bool moveForward)
        {
            _moveForward = moveForward;
        }

        private void OnMoveBack(object sender, bool moveBack)
        {
            _moveBack = moveBack;
        }

        private void OnMoveAttack(object sender, bool moveAttack)
        {
            _moveAttack = moveAttack;
        }
    }
}