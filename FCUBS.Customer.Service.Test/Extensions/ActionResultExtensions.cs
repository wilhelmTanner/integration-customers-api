﻿namespace FCUBS.Customer.Service.Test.Extensions;

public static class ActionResultExtensions
{
    public static T GetObjectResult<T>(this ActionResult<T> result)
    {
        if (result.Result != null)
            return (T)((ObjectResult)result.Result).Value;
        return result.Value;
    }
}