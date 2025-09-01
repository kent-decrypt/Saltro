using KendoNET.DynamicLinq;
using System.Text.Json;

namespace Saltro.Application.Common;

internal static class DataRequestHelper
{
    internal static void FixSerialization(DataSourceRequest request)
    {
        ProcessFilter(request.Filter);
    }

    private static void ProcessFilter(Filter filter)
    {
        if (filter?.Value?.GetType() == typeof(JsonElement))
        {
            var json = (JsonElement)filter.Value;
            if (json.ValueKind == JsonValueKind.Null)
            {
                filter.Value = null;
            }
            else if (json.ValueKind == JsonValueKind.Number)
            {
                filter.Value = json.GetDecimal();
            }
            else if (json.ValueKind == JsonValueKind.True || json.ValueKind == JsonValueKind.False)
            {
                filter.Value = json.GetBoolean();
            }
            else
            {
                filter.Value = json.GetString();
            }
        }

        // Field to Pascal Case
        if (filter?.Field != null)
        {
            filter.Field = filter.Field.Substring(0, 1).ToUpper() + filter.Field.Substring(1);
        }

        // Recurse
        if (filter?.Filters != null)
        {
            foreach (var f in filter.Filters)
            {
                ProcessFilter(f);
            }
        }
    }

    /// <summary>
    /// Convert all the filter's value to lowercase
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    internal static DataSourceRequest LowerCaseFilterValue(this DataSourceRequest request)
    {
        if (request.Filter != null)
        {
            foreach (var filter in request.Filter.All())
            {
                if (filter.Value?.ToString() is string value)
                {
                    filter.Value = value.ToLower();
                }
            }
        }

        return request;
    }
}
