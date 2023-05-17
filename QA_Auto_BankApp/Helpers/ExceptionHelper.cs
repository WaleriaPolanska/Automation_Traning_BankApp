namespace QA_Auto_BankApp.Helpers;

public static class ExceptionHelper
{
    private const string ErrorMessage = "{0} is invalid";

    public static string GetInvalidParameterMessage(string parameterName) => string.Format(ErrorMessage, parameterName);
}