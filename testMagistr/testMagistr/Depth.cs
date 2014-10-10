using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMagistr
{
    class Depth
    {
        public static double getDepth(List<string> text)
        {
            double _depth = 0;

            Dictionary<string,int> dictionary = new Dictionary<string, int>();

            foreach (var word in text)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word,1);
                }
            }
            _depth = 0;
            foreach (var i in dictionary)
            {
                int interval=1;
                foreach (var word in text)
                {
                    if (i.Key!=word)
                    {
                        interval++;
                    }
                    else
                    {
                        _depth += Math.Log(interval, 2);
                    }
                }
            }

            return _depth/text.Count;
        }
    }
}
