using System.Security.Cryptography;

namespace Level2_Task1_Userinterface.Utils
{
    public static class TextGeneratorUtil
    {
        private const string charsUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string charsLowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string numbers = "123456789";

        public static string GenerteUpperCaseRandomText()
        {
            int lenght = RandomNumberGenerator.GetInt32(5, charsUpperCase.Length);
            string text = new string(Enumerable.Repeat(charsUpperCase, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, charsUpperCase.Length)]).ToArray());
            return text;
        }

        public static string GenerteLowerCaseRandomText()
        {
            int lenght = RandomNumberGenerator.GetInt32(4, charsLowerCase.Length);
            string text = new string(Enumerable.Repeat(charsLowerCase, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, charsLowerCase.Length)]).ToArray());
            return text;
        }

        public static string GenerteRandomNumber()
        {
            int lenght = 1;
            string text = new string(Enumerable.Repeat(numbers, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, numbers.Length)]).ToArray());
            return text;
        }
    }
}
