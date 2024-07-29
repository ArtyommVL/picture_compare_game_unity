using System;
using Network;
using Network.Receiver;
using UnityEngine;
using Zenject;

namespace CustomInput.CustomInputReceiver
{
    public class CustomInputReceiver : ITickable, IDisposable
    {
        public event EventHandler<bool> MoveRight;
        public event EventHandler<bool> MoveLeft;
        public event EventHandler<bool> MoveForward;
        public event EventHandler<bool> MoveBack;
        public event EventHandler<bool> MoveAttack;

        private UdpClientReceiver _udpClientReceiver;
        private float _timer = 0;

        [Inject]
        public void Init(UdpClientReceiver udpClientReceiver)
        {
            _udpClientReceiver = udpClientReceiver;
            _udpClientReceiver.UserInputReceived += OnUserInputReceived;   
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.033f)
            {
                _timer = 0;
                OnUserInputReceived(this,0);
            }
        }

        private void OnUserInputReceived(object sender, UserInputField inputField)
        {
            MoveRight?.Invoke(
                this, 
                (inputField & UserInputField.Right) != 0);
            MoveLeft?.Invoke(
                this, 
                (inputField & UserInputField.Left) != 0);
            MoveForward?.Invoke(
                this, 
                (inputField & UserInputField.Forward) != 0);
            MoveBack?.Invoke(
                this, 
                (inputField & UserInputField.Back) != 0);
            MoveAttack?.Invoke(
                this, 
                (inputField & UserInputField.Attack) != 0);
        }
        
        public void Dispose()
        {
            _udpClientReceiver.UserInputReceived -= OnUserInputReceived;   
        }
    }
}