using System;
using System.Collections.Concurrent;
using Extensions;
using UnityEngine;

namespace Network.Receiver
{
    public class UdpClientReceiver : MonoBehaviour
    {
        private readonly ConcurrentQueue<byte[]> _receivedQueue = new ConcurrentQueue<byte[]>();
        public static event EventHandler<UserInputField> UserInputReceived;

        private UdpClientModel _udpClientModel;

        private void Start()
        {
            _udpClientModel = new UdpClientModel();
            _udpClientModel.Initialize();
            _udpClientModel.ReceivedData += OnDataReceived;
        }

        private void Update()
        {
            while (_receivedQueue.TryDequeue(out var result))
            {
                if (result[0] == InputDataId.UserInputDataMessageID)
                {
                    var mes = result.UnpackMessage<UserInputMessage>(InputDataId.UserInputDataMessageID);
                    UserInputReceived?.Invoke(this, mes.UserInput.UserInputField);
                }
            }
        }

        private void OnDisable()
        {
            _udpClientModel.ReceivedData -= OnDataReceived;
        }

        private void OnDataReceived(object sender, byte[] data)
        {
            _receivedQueue.Enqueue(data);
        }

        private void OnDestroy()
        {
            _udpClientModel.Dispose();
        }
    }
}