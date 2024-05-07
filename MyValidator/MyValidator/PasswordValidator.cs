using System;
using System.Linq;

namespace MyValidators
{
    public class StrongPasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины пароля
            if (validateObject.Length < 8 || validateObject.Length > 20)
                return false;

            // Проверка на наличие символов латиницы, цифр и спец. знаков
            if (!validateObject.All(c => char.IsLetterOrDigit(c) || IsSpecialChar(c)))
                return false;

            // Проверка на наличие хотя бы одной заглавной буквы, одной цифры и одного спец. символа
            return validateObject.Any(char.IsUpper) &&
                   validateObject.Any(char.IsDigit) &&
                   validateObject.Any(IsSpecialChar);
        }

        private bool IsSpecialChar(char c)
        {
            return "!@#$%^&*-_".Contains(c);
        }
    }
}

