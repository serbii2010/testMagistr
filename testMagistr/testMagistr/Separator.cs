using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace testMagistr
{
    internal class Separator
    {
        public static List<string> GetWords(string path, bool mix = false)
        {
            string[] buffer;
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd().ToLower();

            text = Regex.Replace(text, "\r", " ");
            text = Regex.Replace(text, "\n", " ");
            text = Regex.Replace(text, "[^\\w\\s]+", "");
            text = Regex.Replace(text, "[\\s]+", " ");
            buffer = text.Trim().Split(' ');

            List<string> ret = buffer.ToList();

            if (mix)
            {
                Random rand = new Random();
                for (int i = 0; i < ret.Count; i++)
                {
                    var r1 = rand.Next(ret.Count);
                    var r2 = rand.Next(ret.Count);
                    var slovo = ret[r1];
                    ret[r1] = ret[r2];
                    ret[r2] = slovo;
                }
            }
            /*
            if (mix)
            {
                ret.Sort();
            }*/
            return ret;
        }

        public static List<string> GetBlockWords(string path, int lengthBlok, bool random = false)
        {
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd().ToLower();

            text = Regex.Replace(text, "\r", " ");
            text = Regex.Replace(text, "\n", " ");
            text = Regex.Replace(text, "[^\\w\\s]+", "");
            text = Regex.Replace(text, "[\\s]+", "");
            text = text.Trim();

            Random rand = new Random();
            List<string> buffer = new List<string>();
            if (random)
            {
                lengthBlok = RandomGenerator.nextRandom(rand.NextDouble());
            }
            while (text.Length > lengthBlok)
            {
                buffer.Add(text.Substring(0, lengthBlok));
                text = text.Remove(0, lengthBlok);
                if (random)
                {
                    lengthBlok = RandomGenerator.nextRandom(rand.NextDouble());
                }
            }
            if (text.Length > 0)
            {
                buffer.Add(text);
            }

            return buffer;
        }

        public static Dictionary<string, int> createDict(List<string> words)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }
            return dict;
        }
    }
}