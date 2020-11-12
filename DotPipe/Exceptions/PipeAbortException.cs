using System;

namespace DotPipe.Exceptions
{
    public class PipeAbortException : Exception
    {
        public PipeAbortException() {}
        public PipeAbortException(string message) : base(message){}
    }
}