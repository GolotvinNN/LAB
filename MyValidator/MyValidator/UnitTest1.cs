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
            new object[] { "user", true },           // �������� �����
            new object[] { "user123", true },        // �������� ����� � �������
            new object[] { "username123", true },    // �������� ����� � �������
            new object[] { "user_name_with_numbers", false },  // ������������ �������
            new object[] { "usernameveryverylong", false },    // ������� �������
            new object[] { null, false },             // ������ ��������
            new object[] { "", false }                // ������ ������
        };

        public static object[] PasswordCases =
        {
            new object[] { "password", false },            // ������� �������
            new object[] { "password123", false },         // ������� �������
            new object[] { "P@ssw0rd", false },            // ������� �������
            new object[] { "Password1!", true },           // �������� ������
            new object[] { "Passw0rd!", true },            // �������� ������
            new object[] { "pass_with_long_password", false },   // ������� �������
            new object[] { "passwordwithoutspecialchar", false },  // ��� ����. �������
            new object[] { null, false },                  // ������ ��������
            new object[] { "", false }                     // ������ ������
        };
    }
}
