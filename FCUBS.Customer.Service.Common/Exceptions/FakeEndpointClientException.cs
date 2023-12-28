namespace FCUBS.Customer.Service.Common.Exceptions;

public class FakeEndpointClientException : BaseException
{
    public FakeEndpointClientException(string message, params object[] args) : base(string.Format(message, args))
    {

    }
}
