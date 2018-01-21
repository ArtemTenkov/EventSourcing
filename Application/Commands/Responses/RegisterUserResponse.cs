namespace Application.Commands.Responses
{
    public class RegisterUserResponse
    {
        public string ErrorMessage { get; }
        public RegisterUserResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
