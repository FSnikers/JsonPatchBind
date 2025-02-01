JsonPatchBind
A lightweight library for handling partial updates in ASP.NET Core APIs without JSON Patch.

Problem:
When building APIs for partial updates (PATCH requests), developers often struggle to:

Differentiate between explicit null and omitted fields.

Avoid overwriting fields not sent in the request.

Use Swagger/Swashbuckle for accurate schema documentation.

Solution:
JsonPatchBind introduces the Optional<T> type to elegantly solve these challenges:

🎯 Track Field Presence: Detect whether a property was included in the JSON payload (even if its value is null).

🛡️ Safe Updates: Update only the fields provided in the request, leaving others unchanged.

🔄 Native JSON Integration: Seamless serialization/deserialization via System.Text.Json.

📚 Swagger Support: Automatic schema generation for Optional<T> fields.

Features
✅ Optional<T> Wrapper:

HasValue = true → Field was sent (value can be null).

HasValue = false → Field was omitted.

✅ Custom JSON Converter: Serialize/deserialize Optional<T> with correct null-handling.

✅ Swagger Schema Filter: Show Optional<T> as nullable fields in OpenAPI docs.

✅ ASP.NET Core Integration: Works with [FromBody] model binding.

✅ No Dependencies: Built on standard .NET components.

Why Not JSON Patch?
While JSON Patch (RFC 6902) is a standard, it:

❌ Requires clients to send complex operations (replace, remove).

❌ Overcomplicates simple partial updates.

❌ Demands extra validation.
