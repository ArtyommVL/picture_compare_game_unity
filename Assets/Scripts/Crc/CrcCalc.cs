namespace Crc
{
    public static class CrcCalc
    {
        public static ushort Crc16CCITT(this byte[] buffer)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < buffer.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ CrcTable.Table[(crc >> 8) ^ buffer[i]]);
            }

            return crc;
        }
    }
}