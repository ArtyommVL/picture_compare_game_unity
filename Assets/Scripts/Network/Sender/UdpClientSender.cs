using System;
using System.Linq;
using System.Net.Sockets;
using Crc;
using CustomInput.CustomInputSender;
using Extensions;
using UnityEngine;

namespace Network.Sender
{
    public class UdpClientSender : MonoBehaviour, ISender
    {
        private UdpClient _udpClient;
        private ICustomInput _customInput;
        private UserInputField _userInputField;
        private float _timer;

        private void Awake()
        {
            _customInput = new CustomInputHandler();
        }

        private void Update()
        {
            _userInputField = _customInput.SetInputValues();   
            Send();
        }

        public void Send()
        {
            if (_userInputField != 0)
            {
                try
                {
                    if (_udpClient == null)
                    {
                        _udpClient = new UdpClient();
                    }

                    _udpClient.Connect("127.0.0.1", 7878);
                    byte[] sendBytes = PackUserInputMsg().ToByteArray();
                    _udpClient.SendAsync(sendBytes, sendBytes.Length);
                }
                catch (Exception e)
                {
                    _udpClient = new UdpClient();
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
                UserInputField = _userInputField,
            };
        }
    }
}