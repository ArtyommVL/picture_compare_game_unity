using System;
using CustomInput.CustomInputReceiver;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class MainGameState : IGameStateMachine, IDisposable
    {
        private CustomInputReceiver _customInputReceiver;
        private GameStateMachine _gameStateMachine;
        
        private bool _isForward;
        private bool _isBack;
        private bool _isRight;
        
        [Inject]
        public void Init(CustomInputReceiver customInputReceiver,
            GameStateMachine gameStateMachine)
        {
            _customInputReceiver = customInputReceiver;
            _gameStateMachine = gameStateMachine;
            _customInputReceiver.MoveForward += OnMoveForward;
            _customInputReceiver.MoveBack += OnMoveBack;
            _customInputReceiver.MoveRight += OnMoveRight;
        }

        private void OnMoveRight(object sender, bool isPressed)
        {
            _isRight = isPressed;
        }

        private void OnMoveBack(object sender, bool isPressed)
        {
            _isBack = isPressed;
        }

        private void OnMoveForward(object sender, bool isPressed)
        {
            _isForward = isPressed;
        }

        public void Enter()
        {
            Debug.Log("MainGameState");
        }

        public void Exit()
        {
        }

        public void Dispose()
        {
            _customInputReceiver.MoveForward -= OnMoveForward;   
            _customInputReceiver?.Dispose();
        }
    }
}