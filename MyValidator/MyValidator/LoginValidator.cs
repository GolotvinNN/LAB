using System;
using System.Linq;

namespace MyValidators
{
    public interface IValidator
    {
        bool Validate(string? validateObject);
    }

    public class SimpleLoginValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины логина
            if (validateObject.Length < 4 || validateObject.Length > 12)
                return false;

            // Проверка на символы букв и цифр
            return validateObject.All(c => char.IsLetterOrDigit(c));
        }
    }

    public class StrongPasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины пароля
            if (validateObject.Length < 8 || validateObject.Length > 20)
                return false;

            // Проверка на наличие хотя бы одной заглавной буквы, одной строчной буквы, одной цифры и одного спец. символа
            return validateObject.Any(char.IsUpper) &&
                   validateObject.Any(char.IsLower) &&
                   validateObject.Any(char.IsDigit) &&
                   validateObject.Any(c => "!@#$%^&*-_".Contains(c));
        }
    }
}

