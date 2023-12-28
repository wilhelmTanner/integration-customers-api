namespace FCUBS.Customer.Service.API.Utils;

public class AddRoleNameInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        telemetry.Context.Cloud.RoleName = "Template_Base_Api";
    }
}