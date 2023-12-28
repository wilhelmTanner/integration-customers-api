namespace FCUBS.Customer.Service.Common.Models.Settings;

public class ServicesSettings
{
    public ServiceSettings? Core { get; set; }
    public ServiceSettings? Risk { get; set; }
    public ServiceSettings? Email { get; set; }
}

public class ServiceSettings
{
    public string? Host { get; set; }
    public string? Token { get; set; }
    public string? Version { get; set; }
    public string? SubscriptionKey { get; set; }
    public string? System { get; set; }
}