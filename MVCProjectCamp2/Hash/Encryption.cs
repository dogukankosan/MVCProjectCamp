using System;

namespace MVCProjectCamp2.Hash
{
    public static class Encryption
    {
        public static string Enc(string text)
        {
            char[] array = text.ToCharArray();
            string password = string.Empty;
            foreach (char item in array)
            {
                password += Convert.ToChar(item + 35);
            }
            return password;
        }

        public static string Desc(string text)
        {
            char[] array = text.ToCharArray();
            string password = string.Empty;
            foreach (char item in array)
            {
                password += Convert.ToChar(item - 35);
            }
            return password;
        }
    }
}