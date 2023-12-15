namespace Tanner.Payment.Button.Common.Exceptions;

public class FakeEndpointClientException : BaseException
{
    public FakeEndpointClientException(string message, params object[] args) : base(string.Format(message, args))
    {

    }
}
