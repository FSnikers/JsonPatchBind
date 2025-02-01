using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonPatchBind.Converters;

public class OptionalConverter<T> : JsonConverter<Optional<T>>
{
    public override Optional<T> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Если поле присутствует в JSON, десериализуем его
        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return new Optional<T>(value);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Optional<T> value,
        JsonSerializerOptions options)
    {
        // Сериализуем только если значение было задано
        if (value.HasValue)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}