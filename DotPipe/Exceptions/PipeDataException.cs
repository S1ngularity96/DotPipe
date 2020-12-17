using System;

namespace DotPipe.Exceptions
{
    public class PipeDataException : Exception
    {
        public PipeDataException() : base("Data in context does not exist") { }
        public PipeDataException(string msg) : base(msg) { }

    }
}