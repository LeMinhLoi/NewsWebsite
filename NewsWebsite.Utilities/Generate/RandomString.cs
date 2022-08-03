using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsWebsite.Utilities.Generate
{
    public static class RandomString
    {
        private static Random random = new Random();
        public static string Result(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
