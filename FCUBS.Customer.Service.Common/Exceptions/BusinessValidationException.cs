﻿namespace FCUBS.Customer.Service.Common.Exceptions;

public class BusinessValidationException : BaseException
{
    public BusinessValidationException(string message, params object[] args) : base(string.Format(message, args))
    {

    }
}
