using System;
using Network;
using Network.Receiver;
using UnityEngine;

namespace CustomInput.CustomInputReceiver
{
    public class CustomInputObserver : MonoBehaviour
    {
        public static event EventHandler<bool> MoveRight;
        public static event EventHandler<bool> MoveLeft;
        public static event EventHandler<bool> MoveForward;
        public static event EventHandler<bool> MoveBack;
        public static event EventHandler<bool> MoveAttack;

        private void OnEnable()
        {
            UdpClientReceiver.UserInputReceived += OnUserInputReceived;
        }

        private void OnUserInputReceived(object sender, UserInputField inputField)
        {
            Debug.Log(inputField.ToString());
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
        
        private void OnDisable()
        {
            UdpClientReceiver.UserInputReceived -= OnUserInputReceived;
        }
    }
}