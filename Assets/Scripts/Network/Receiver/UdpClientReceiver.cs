using Extensions;
using UnityEngine;

namespace Network.Receiver
{
    public class UdpClientReceiver : MonoBehaviour
    {
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
                Debug.Log(mes.Id);
            }
        }

        private void OnDestroy()
        {
            _udpClientModel.Dispose();
        }
    }
}