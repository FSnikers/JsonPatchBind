using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonPatchBind.Converters;

public class OptionalConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && 
               typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);
    }

    public override JsonConverter CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var valueType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(OptionalConverter<>).MakeGenericType(valueType);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}
