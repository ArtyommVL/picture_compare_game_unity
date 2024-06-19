using System;
using System.Runtime.InteropServices;
using Crc;

namespace Extensions
{
    public static class StructExtensions
    {
        public static byte[] ToByteArray<T>(this T str) where T: struct
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return arr;
        }
        
        public static T ToStruct<T>(this byte[] arr) where T : struct
        {
            T str = new T();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(arr, 0, ptr, size);

                str = (T)Marshal.PtrToStructure(ptr, str.GetType());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return str;
        }
        
        public static T UnpackMessage<T>(this byte[] receivedData, ushort messageId) where T : struct
        {
            var dataForCalculateCrc = receivedData;
            var crcBuffer = new byte[]
            {
                receivedData[^2], 
                receivedData[^1]
            };
            var crc = crcBuffer.ToStruct<ushort>();
            Array.Resize(ref dataForCalculateCrc,receivedData.Length-2);
            var crcFromMsg = dataForCalculateCrc.Crc16CCITT();
            
            if (receivedData[0] == messageId && crc == crcFromMsg)
            {
                return receivedData.ToStruct<T>();
            }

            return default;
        }
    }
}