namespace Volo.Abp.GraphQL.Client.Extensions
{
    internal static class StringExtensions
    {
        public static string ToGraphQLStringFormat(this string value)
        {
            return char.ToLower(value[0]) + value.Substring(1);
        }
    }
}
