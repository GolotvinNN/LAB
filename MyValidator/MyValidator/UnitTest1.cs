using NUnit.Framework;
using MyValidators;

namespace MyValidatorsTests
{
    public class ValidatorTests
    {
        [Test]
        [TestCaseSource(typeof(ValidatorTestData), nameof(ValidatorTestData.LoginCases))]
        public void SimpleLoginValidator_Test(string login, bool expectedResult)
        {
            var validator = new SimpleLoginValidator();
            var result = validator.Validate(login);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCaseSource(typeof(ValidatorTestData), nameof(ValidatorTestData.PasswordCases))]
        public void StrongPasswordValidator_Test(string password, bool expectedResult)
        {
            var validator = new StrongPasswordValidator();
            var result = validator.Validate(password);
            Assert.AreEqual(expectedResult, result);
        }
    }

    public class ValidatorTestData
    {
        public static object[] LoginCases =
        {
            new object[] { "user", true },           // Валидный логин
            new object[] { "user123", true },        // Валидный логин с цифрами
            new object[] { "username123", true },    // Валидный логин с цифрами
            new object[] { "user_name_with_numbers", false },  // Недопустимые символы
            new object[] { "usernameveryverylong", false },    // Слишком длинный
            new object[] { null, false },             // Пустое значение
            new object[] { "", false }                // Пустая строка
        };

        public static object[] PasswordCases =
        {
            new object[] { "password", false },            // Слишком простой
            new object[] { "password123", false },         // Слишком простой
            new object[] { "P@ssw0rd", false },            // Слишком простой
            new object[] { "Password1!", true },           // Валидный пароль
            new object[] { "Passw0rd!", true },            // Валидный пароль
            new object[] { "pass_with_long_password", false },   // Слишком длинный
            new object[] { "passwordwithoutspecialchar", false },  // Нет спец. символа
            new object[] { null, false },                  // Пустое значение
            new object[] { "", false }                     // Пустая строка
        };
    }
}
