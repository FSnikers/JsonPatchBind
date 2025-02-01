using System.ComponentModel.DataAnnotations;

namespace JsonPatchBind.ValidationAttributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
public class ValidateOptionalAttribute : ValidationAttribute
{
    private readonly ValidationAttribute? _innerAttribute;

    public ValidateOptionalAttribute(Type validationAttributeType, params object[] args)
    {
        _innerAttribute = (ValidationAttribute)Activator.CreateInstance(validationAttributeType, args)!;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var optionalType = value.GetType();
        var valueProperty = optionalType.GetProperty("Value");

        if (valueProperty == null)
            return new ValidationResult("Invalid Optional type.");

        var actualValue = valueProperty.GetValue(value);
        return _innerAttribute?.GetValidationResult(actualValue, validationContext);
    }
}