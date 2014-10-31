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
        public static List<string> GetWords(string path, bool norm, bool mix = false)
        {
            string[] buffer;
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd().ToLower();

            if (norm)
            {
                text = Regex.Replace(text, "\r", "");
                buffer = text.Split('\n');
            }
            else
            {
                text = Regex.Replace(text, "[^\\w\\s]+", "");
                text = Regex.Replace(text, "[\\s]+", " ");
                buffer = text.Split(' ');
            }
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

        public static List<string> GetBlockWords(string path, int lengthBlok, bool norm)
        {
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd().ToLower();

            if (norm)
            {
                text = Regex.Replace(text, "\r", "");
            }
            else
            {
                text = Regex.Replace(text, "[^\\w\\s]+", "");
                text = Regex.Replace(text, "[\\s]+", "");
            }

            Random rand = new Random();
            List<string> buffer = new List<string>();
            //lengthBlok = rand.Next(1, 5);
            while (text.Length > lengthBlok)
            {
                buffer.Add(text.Substring(0, lengthBlok));
                text = text.Remove(0, lengthBlok);
                //lengthBlok = rand.Next(1, 5);
            }
            if (text.Length > 0)
            {
                buffer.Add(text);
            }

            return buffer;
        }
    }
}