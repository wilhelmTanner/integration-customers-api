namespace FCUBS.Customer.Service.Common.Extensions;

public static class StringExtensions
{
    public static string ToSqlLikeSearch(this string source)
    {
        return "%" + source.Replace("[", "[[]").Replace("%", "[%]") + "%";
    }
}
