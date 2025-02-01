using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JsonPatchBind.Swashbuckle;

public class OptionalSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsGenericType && 
            context.Type.GetGenericTypeDefinition() == typeof(Optional<>))
        {
            var valueType = context.Type.GetGenericArguments()[0];
            var innerSchema = context.SchemaGenerator.GenerateSchema(valueType, context.SchemaRepository);
            
            // Копируем свойства внутреннего типа
            schema.Type = innerSchema.Type;
            schema.Format = innerSchema.Format;
            schema.Reference = innerSchema.Reference;
            schema.Properties = innerSchema.Properties;
            schema.Nullable = true; // Помечаем как nullable
        }
    }
}