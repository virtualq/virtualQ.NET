using System;

namespace VirtualQNet
{
    public class VirtualQException: Exception
    {
        public VirtualQException(string message): base(message) { }
    }
}
