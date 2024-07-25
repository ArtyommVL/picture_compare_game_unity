using System;
using System.Collections.Concurrent;
using Extensions;
using Zenject;

namespace Network.Receiver
{
    public class UdpClientReceiver : ITickable, IDisposable
    {
        private readonly ConcurrentQueue<byte[]> _receivedQueue = new ConcurrentQueue<byte[]>();
        public event EventHandler<UserInputField> UserInputReceived;

        private UdpClientModel _udpClientModel;

        [Inject]
        public void Init(UdpClientModel udpClientModel)
        {
            _udpClientModel = udpClientModel;
            _udpClientModel.Initialize();
            _udpClientModel.ReceivedData += OnDataReceived;
        }

        public void Tick()
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
        
        private void OnDataReceived(object sender, byte[] data)
        {
            _receivedQueue.Enqueue(data);
        }

        public void Dispose()
        {
            _udpClientModel.ReceivedData -= OnDataReceived;
            _udpClientModel?.Dispose();
        }
    }
}