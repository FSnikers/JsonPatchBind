=
                         JsonPatchBind
=

A lightweight library for handling partial updates in ASP.NET Core APIs without JSON Patch.


Description
-----------
When building APIs for partial updates (PATCH requests), developers often face challenges such as:

  • Differentiating between an explicit null and an omitted field.
  • Avoiding overwriting fields that were not sent by the client.
  • Ensuring accurate schema documentation with Swagger/Swashbuckle.

**JsonPatchBind** elegantly addresses these challenges by introducing the `Optional<T>` type.

Key Benefits:
-------------
  • **Field Presence Tracking:** Determine if a property was included in the JSON payload (even if its value is null).
  • **Safe Updates:** Update only the fields provided in the request, leaving others unchanged.
  • **Native JSON Integration:** Seamless serialization/deserialization via System.Text.Json.
  • **Swagger Support:** Automatic schema generation for `Optional<T>` fields.

Features
--------
  ✅ **Optional<T> Wrapper:**
     - `HasValue = true`  → Field was sent (value can be null).
     - `HasValue = false` → Field was omitted.

  ✅ **Custom JSON Converter:** Serializes/deserializes `Optional<T>` correctly while handling nulls.

  ✅ **Swagger Schema Filter:** Displays `Optional<T>` as nullable fields in OpenAPI documentation.

  ✅ **ASP.NET Core Integration:** Works seamlessly with [FromBody] model binding.

  ✅ **No External Dependencies:** Built using standard .NET components.

Why Not JSON Patch?
-------------------
Although JSON Patch (RFC 6902) is a standard, it comes with several drawbacks:

  ❌ Clients must send complex operations (replace, remove, add).

  ❌ It overcomplicates simple partial updates.

  ❌ It demands extra validation.

=
Сomparison Table: When to Use
=
      

| **Criteria**               | **JsonPatchBind**                                        | **JSON Patch**                                 |
|----------------------------|----------------------------------------------------------|------------------------------------------------|
| **Use Case**               | Simple partial updates using `Optional<T>`             | Updates using operations (replace, remove, add)|
| **Client Complexity**      | Simple JSON payload structure                            | Requires constructing complex operation objects|
| **Field Tracking**         | Clearly differentiates between explicit null and omitted fields | Does not explicitly track field presence       |
| **Swagger Integration**    | Automatically generates accurate schema                | Often requires manual adjustments              |
| **Validation**             | Minimal additional validation needed                   | Requires extra validation steps                |

=
           Pros and Cons: JSON Patch vs. JsonPatchBind
=

| **Aspect**              | **JsonPatchBind**                                         | **JSON Patch**                                |
|-------------------------|-----------------------------------------------------------|-----------------------------------------------|
| **Simplicity**          | ✅ Simple and intuitive approach                           | ❌ More complex payload structure             |
| **Field Tracking**      | ✅ Explicitly determines if a field was sent (even if null)  | ❌ Lacks built-in mechanism for field tracking  |
| **Swagger Support**     | ✅ Built-in support for accurate schema generation          | ❌ Requires additional configuration           |
| **Validation**          | ✅ Minimal extra validation                                | ❌ Additional data validation is often necessary |
| **Standardization**     | ❌ Custom solution (not an official standard)               | ✅ Official standard (RFC 6902)                |

=
                    When to Use JsonPatchBind?
=
Use **JsonPatchBind** if:

  • You need to implement partial updates without overcomplicating your logic.
  
  • You require precise tracking of which fields were sent by the client.
  
  • You want to minimize extra validation and work seamlessly with OpenAPI/Swagger.
  
  • You do not need the full set of JSON Patch operations.

=
Installation & Integration
=
1. **Installation:**
   Add the package to your project via NuGet:
   
       dotnet add package JsonPatchBind

2. **Usage in a Controller:**
   Example model:
   
   ```csharp
   public class UpdateUserModel
   {
       public Optional<string> FirstName { get; set; }
       public Optional<string> LastName { get; set; }
       public Optional<string> Email { get; set; }
   }
