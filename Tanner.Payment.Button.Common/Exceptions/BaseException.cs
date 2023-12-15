namespace Tanner.Payment.Button.Common.Exceptions;

/// <summary>
/// Excepción base para middleware
/// </summary>
public class BaseException : Exception
{
    public BaseException(string message, params object[] args) : base(string.Format(message, args))
    {
    }
}
