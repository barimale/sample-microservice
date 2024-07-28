namespace Ordering.Application.Exceptions
{
    [Serializable]
    internal class AddOrderException : Exception
    {
        public AddOrderException()
        {
            // intentionally left blank
        }

        public AddOrderException(string? message) : base(message)
        {
            // intentionally left blank
        }

        public AddOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
            // intentionally left blank
        }
    }
}