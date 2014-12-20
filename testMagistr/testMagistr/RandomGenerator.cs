using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMagistr
{
    internal class RandomGenerator
    {
        public static Dictionary<int, double> probabiliti = new Dictionary<int, double>();

        public static void setProbabiliti(List<string> dictionary, int length)
        {
            foreach (var i in dictionary)
            {
                if (probabiliti.ContainsKey(i.Length))
                {
                    probabiliti[i.Length] += (double)1/length;
                }
                else
                {
                    probabiliti.Add(i.Length, (double)1/length);
                }
            }
            probabiliti = probabiliti.OrderBy(pair => pair.Value).ToDictionary(pair=>pair.Key,pair=>pair.Value);

            double buf = 0;
            var buf1 = new Dictionary<int, double>();
            foreach (var d in probabiliti)
            {
                buf1.Add(d.Key,buf+d.Value);
                buf += d.Value;
            }
            probabiliti = buf1;
        }

        public static int nextRandom(double r)
        {
            foreach (var d in probabiliti)
            {
                if (d.Value>r)
                {
                    return d.Key;
                }
            }
            return 0;
        }
    }
}