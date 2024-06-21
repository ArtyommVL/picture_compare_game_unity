using System;
using CustomInput.CustomInputReceiver;
using Grid;
using UnityEngine;

namespace PlayerController.Abilities
{
    public class AttackAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float maxDistance = 1f;
        
        private readonly RaycastHit[] _raycastHit = new RaycastHit[5];
        private CubeUnit _currentCubeUnit;
        
        private void OnEnable()
        {
            CustomInputReceiver.MoveAttack += OnMoveAttack;
        }

        private void Update()
        {
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

        private void OnDisable()
        {
            CustomInputReceiver.MoveAttack += OnMoveAttack;
        }

        private void OnMoveAttack(object sender, bool moveAttack)
        {
            ChangeStateCube(_currentCubeUnit, moveAttack);
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
    }
}