using System;

namespace Well.Interpretation.Exceptions
{
    public class InterpretationException : Exception
    {
        public InterpretationException(string message) : base(message)
        {
        }
    }
}