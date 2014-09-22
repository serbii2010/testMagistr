using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMagistr
{
    class Separator
    {
        public List<string> getWords(string path)
        {
            string[] buffer;
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            buffer = text.Split(' ');
            return  buffer.ToList();
        }

        public List<string> getDoubleWords(string path, int n)
        {
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd();

            List<string> buffer = new List<string>();
            while (text.Length>n)
            {
                buffer.Add(text.Substring(0, n));
                text = text.Remove(0, n);
            }
            if (text.Length>0)
            {
                buffer.Add(text);
            }
            return buffer;
        }
    }
}
