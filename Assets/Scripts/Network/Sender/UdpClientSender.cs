using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Crc;
using CustomInput;
using Extensions;
using UnityEngine;

namespace Network.Sender
{
    public class UdpClientSender : MonoBehaviour, ISender
    {
        private UdpClient _udpClient;
        private ICustomInput _customInput;
        private float _timer;

        private void Awake()
        {
            _customInput = new CustomInputHandler();
        }

        private async void Update()
        {
           await Send();
        }

        public async Task Send()
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.0333f )
            {
                _timer = 0;
                try
                {
                    if (_udpClient == null)
                    {
                        _udpClient = new UdpClient();
                    }

                    _udpClient.Connect("127.0.0.1", 7878);
                    byte[] sendBytes = PackUserInputMsg().ToByteArray();
                    await _udpClient.SendAsync(sendBytes, sendBytes.Length);
                }
                catch (Exception e)
                {
                    _udpClient = new UdpClient();
                    Console.WriteLine(e.ToString());
                }
            }
        }
        
        private UserInputMessage PackUserInputMsg()
        {
            var buffer = new byte[]
            {
                InputDataId.UserInputDataMessageID,
            };

            var msgToArray = UserInputMsg().ToByteArray();
            var combinedBuffer = buffer.Concat(msgToArray).ToArray();
            var crc = combinedBuffer.Crc16CCITT();

            return new UserInputMessage()
            {
                Id = InputDataId.UserInputDataMessageID,
                UserInput = UserInputMsg(),
                Crc = crc,
            };
        }

        private UserInput UserInputMsg()
        {
            return new UserInput()
            {
                UserInputField = _customInput.SetInputValues(),
            };
        }
    }
}