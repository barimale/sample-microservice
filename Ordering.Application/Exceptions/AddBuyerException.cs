namespace Ordering.Application.Exceptions
{
    [Serializable]
    internal class AddBuyerException : Exception
    {
        public AddBuyerException()
        {
            // intentionally left blank
        }

        public AddBuyerException(string? message) : base(message)
        {
            // intentionally left blank
        }

        public AddBuyerException(string? message, Exception? innerException) : base(message, innerException)
        {
            // intentionally left blank
        }
    }
}