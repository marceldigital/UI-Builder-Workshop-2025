using System.Text.Json;
using Umbraco.Cms.Core.Serialization;
using Umbraco.UIBuilder.Mapping;

namespace UIBuilderWorkshop.Core.ValueMappers;

internal class SingleEnumtoUmbracoDropdownValueMapper<TEnumType>
    : ValueMapper where TEnumType : Enum
{
    private readonly IJsonSerializer _jsonSerializer;

    public SingleEnumtoUmbracoDropdownValueMapper(IJsonSerializer jsonSerializer)
    {
        _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
    }

    public override object? EditorToModel(object? input)
    {
        if (input is string jsonString)
        {
            try
            {
                var values = _jsonSerializer.Deserialize<string[]>(jsonString);
                if (values?.Length > 0 && Enum.TryParse(typeof(TEnumType), values[0], out var enumValue))
                {
                    return enumValue;
                }
            }
            catch (JsonException)
            {
                return null;
            }
        }
        return null;
    }

    public override object? ModelToEditor(object? input)
    {
        if (input is int enumValue)
        {
            var enumName = Enum.GetName(typeof(TEnumType), enumValue);
            if (!string.IsNullOrEmpty(enumName))
            {
                var jsonString = _jsonSerializer.Serialize(new[] { enumName });
                return jsonString;
            }
        }
        return null;
    }
}
