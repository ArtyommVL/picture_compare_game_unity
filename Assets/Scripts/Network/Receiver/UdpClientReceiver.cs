using System;
using Extensions;
using UnityEngine;

namespace Network.Receiver
{
    public class UdpClientReceiver : MonoBehaviour
    {
        public static event EventHandler<UserInputField> UserInputReceived;
        
        private UdpClientModel _udpClientModel;

        private void Start()
        {
            _udpClientModel = new UdpClientModel();
            _udpClientModel.Initialize();
            _udpClientModel.ReceivedData += OnDataReceived;
        }

        private void OnDisable()
        {
            _udpClientModel.ReceivedData -= OnDataReceived;
        }

        private void OnDataReceived(object sender, byte[] data)
        {
            if (data[0] == InputDataId.UserInputDataMessageID)
            {
                var mes = data.UnpackMessage<UserInputMessage>(InputDataId.UserInputDataMessageID);
                UserInputReceived?.Invoke(this, mes.UserInput.UserInputField);
            }
        }

        private void OnDestroy()
        {
            _udpClientModel.Dispose();
        }
    }
}