namespace Tanner.Payment.Button.Common.Interfaces.HttpClients;

public interface IFakeEndpointClient
{
    /// <summary>
    /// Se obtiene toda la data.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ExternalServiceResponse>> GetAllData();
}