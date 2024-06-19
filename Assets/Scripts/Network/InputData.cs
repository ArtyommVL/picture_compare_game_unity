using System;
using System.Runtime.InteropServices;

namespace Network
{
    [Flags]
    public enum UserInputField : byte
    {
        Right = 1 << 0,
        Left = 1 <<1,
        Forward = 1 << 2,
        Back = 1 << 3,
        Attack = 1 <<4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UserInput
    {
        public UserInputField UserInputField;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UserInputMessage
    {
        public byte Id;
        public UserInput UserInput;
        public ushort Crc;
    }
}