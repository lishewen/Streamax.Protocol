using System;
using System.Buffers;

namespace Streamax.Protocol
{
    internal static class StreamaxArrayPool
    {
        private readonly static ArrayPool<byte> ArrayPool;

        static StreamaxArrayPool()
        {
            ArrayPool = ArrayPool<byte>.Create();
        }

        public static byte[] Rent(int minimumLength)
        {
            return ArrayPool.Rent(minimumLength);
        }

        public static void Return(byte[] array, bool clearArray = false)
        {
            ArrayPool.Return(array, clearArray);
        }
    }
}
