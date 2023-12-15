﻿namespace Tanner.Payment.Button.Common.Extensions;

public static class StringExtensions
{
    public static string ToSqlLikeSearch(this string source)
    {
        return "%" + source.Replace("[", "[[]").Replace("%", "[%]") + "%";
    }
}
