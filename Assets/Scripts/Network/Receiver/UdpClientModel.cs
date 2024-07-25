using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Network.Receiver
{
    public class UdpClientModel : IDisposable
    {
        public event EventHandler<byte[]> ReceivedData;

        private UdpClient _udpClient;
        private Thread _thread;
        private readonly IPEndPoint _ipEndPoint = new(IPAddress.Any, 7878);

        public void Initialize()
        {
            _udpClient = new UdpClient(_ipEndPoint.Port, AddressFamily.InterNetwork);
            _thread = new Thread(new ThreadStart(DataReceiver));
            _thread.Start();
        }
        
        private void DataReceiver()
        {
            while (true)
            {
                var rcvEp = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = _udpClient.Receive(ref rcvEp);
                ReceivedData?.Invoke(this, receiveBytes);
            }
        }
        
        public void Dispose()
        {
            _thread?.Abort();
            _udpClient.Client?.Close();
            _udpClient?.Dispose();
        }
    }
}