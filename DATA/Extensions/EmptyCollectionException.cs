using System;


namespace DATA.Extensions
{
    public class EmptyCollectionException : Exception
    {
        public EmptyCollectionException(string message) : base(message)
        {
        }
    }
}
