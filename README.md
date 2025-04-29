# 🎯 JsonPatchBind 

✨ A lightweight library for handling partial updates in ASP.NET Core APIs without JSON Patch.  

---

## 📖 Description  

When building APIs for partial updates (PATCH requests), developers often face challenges such as:  

  • 🧩 Differentiating between an explicit `null` and an omitted field  
  • 🛡️ Avoiding overwriting fields that weren't sent by the client  
  • 📚 Ensuring accurate schema documentation with Swagger/Swashbuckle  

**JsonPatchBind** elegantly solves these problems using the `Optional<T>` type!  

---

## 🌟 Key Benefits  

  • **Field Presence Tracking** - Know if a property was included (even if `null`)  
  • **Safe Updates** - Only modify fields provided in the request  
  • **Native JSON Support** - Works seamlessly with `System.Text.Json`  
  • **Swagger Ready** - Automatic schema generation for `Optional<T>`  

---

## 🚀 Features  

| Feature | Description |
|---------|-------------|
| **`Optional<T>` Wrapper** | `HasValue = true` → Field was sent (value can be null) |
| **Custom JSON Converter** | Handles serialization/deserialization perfectly |
| **Swagger Schema Filter** | Shows `Optional<T>` as nullable fields in docs |
| **ASP.NET Core Integration** | Works with `[FromBody]` out of the box |
| **Zero Dependencies** | Pure .NET solution |

---

## ❓ Why Not JSON Patch?  

While JSON Patch (RFC 6902) is standard, it has drawbacks:  

| Issue | JsonPatchBind | JSON Patch |
|-------|--------------|------------|
| **Payload Complexity** | Simple JSON | Complex operations |
| **Null Handling** | Clear differentiation | Ambiguous |
| **Swagger Support** | Automatic | Manual config needed |
| **Validation** | Minimal | Extensive |

---

## ⚖️ Comparison Table  

### When to Use Which?

| Criteria               | JsonPatchBind ✅ | JSON Patch ❌ |
|-----------------------|----------------|-------------|
| Simple updates        | Perfect fit    | Overkill    |
| Client simplicity     | Easy JSON      | Complex ops |
| Field tracking        | Built-in       | Not native  |
| Swagger integration   | Auto-magic     | Manual work |

---

## 🔧 Installation  

1. Add the NuGet package:  
```bash
   dotnet add package JsonPatchBind
```
2. Configure Services:
```csharp
   builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new OptionalConverterFactory());
    });
```
3. **Add Swagger Support:**
```csharp
   builder.Services.AddSwaggerGen(c =>
   {
    c.SchemaFilter<OptionalSchemaFilter>();
   });
```


## 🎮 Usage Example

Model definition:
```csharp
   public class UserDto
   {
    public int Id { get; set; }

    public string Name { get; set; }
    
    [ValidateOptional(typeof(StringLengthAttribute), 32)]
    [ValidateOptional(typeof(RegularExpressionAttribute), "\\d+")]
    public Optional<string> SurName { get; set; }
    
    public Optional<int> Age { get; set; }
    
    public Optional<AddressDto> Address { get; set; }

   }
```

Controller:

```csharp
[HttpPatch("{id}")]
public IActionResult UpdateUser(int id, [FromBody] UserDto user)
{
    // Only update fields that were actually sent
    if (user.SurName.HasValue)
    {
        // Handle surname update
    }
}
```


