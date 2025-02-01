using System.Text.Json.Serialization;
using JsonPatchBind.Converters;

namespace JsonPatchBind;

[JsonConverter(typeof(OptionalConverterFactory))]
public struct Optional<T>
{
    public T? Value { get; private set; }
    public bool HasValue { get; private set; }

    public Optional(T? value)
    {
        Value = value;
        HasValue = true;
    }

    public static implicit operator T?(Optional<T?> optional) => optional.Value;
    public static implicit operator Optional<T>(T value) => new Optional<T>(value);
}