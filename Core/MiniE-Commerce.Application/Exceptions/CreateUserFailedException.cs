namespace MiniE_Commerce.Application.Exceptions
{
    public class CreateUserFailedException : Exception
    {
        public CreateUserFailedException() : base("Error occurred while creating user!")
        {

        }

        public CreateUserFailedException(string? message) : base(message)
        {
        }

        public CreateUserFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
