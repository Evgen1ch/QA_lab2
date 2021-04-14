using System;
using System.Collections.Generic;
using System.Text;

namespace QA_lab2
{
    static class FieldGenerator
    {
        public static string GenerateValidName()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            int length = random.Next(3, 9);
            for(int i = 0; i < length; i++)
            {
                sb.Append((char)random.Next(33, 127));
            }

            return sb.ToString();
        }

        public static string GenerateValidEmail()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            int length = random.Next(3, 9);
            for (int i = 0; i < length; i++)
            {
                sb.Append((char)random.Next(97, 123));
            }

            sb.Append("@some.mail");

            return sb.ToString();
        }

        public static string GenerateValidPassword()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            int length = random.Next(6, 11);
            for (int i = 0; i < length; i++)
            {
                sb.Append((char)random.Next(33, 127));
            }

            return sb.ToString();
        }

    }
}
