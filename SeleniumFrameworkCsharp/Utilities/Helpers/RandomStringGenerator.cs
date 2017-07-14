using System;
using System.Text;

namespace SeleniumFrameworkCsharp.Utilities.Helpers
{
    public class RandomStringGenerator
    {
        private static Random Random = new Random((int)DateTime.Now.Ticks);

        public String GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                ch = Char.ToLower(ch);
                if (i % 3 == 0) ch = Char.ToUpper(ch);
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public String GetRandomSentence()
        {
            return GetRandomSentences(1);
        }

        public String GetRandomSentences(int howMany)
        {
            StringBuilder builder = new StringBuilder();

            var sentence = new NLipsum.Core.LipsumGenerator().GenerateSentences(howMany);
            foreach (string s in sentence) builder.Append(s);

            return builder.ToString();
        }
    }
}
