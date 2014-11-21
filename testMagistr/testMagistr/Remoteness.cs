using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testMagistr
{
    class Remoteness
    {
        public static double getRemotenessChar(List<string> text)
        {
            int length=0;
            var dictionary = new Dictionary<char, int>();

            foreach (var s in text)
            {
                length += s.Length;
                foreach (var c in s)
                {
                    if (dictionary.ContainsKey(c))
                    {
                        dictionary[c]++;
                    }
                    else
                    {
                        dictionary.Add(c, 1);
                    }
                }
            }
            double _depth = 0;

            foreach (var c in dictionary)
            {
                int interval = 0;
                foreach (char c1 in text.SelectMany(s => s))
                {
                    interval++;
                    if (c.Key==c1)
                    {
                        _depth += Math.Log(interval, 2);
                        interval = 0;
                    }
                }
            }
            return _depth/length;
        }
        public static double getRemoteness(List<string> text)
        {
            var dictionary = new List<string>();

            foreach (var word in text.Where(word => !dictionary.Contains(word)))
            {
                dictionary.Add(word);
            }
            double _depth = 0;
            
            Mutex mutex = new Mutex();
            Parallel.ForEach(dictionary, j =>
            {
                var interval = 0;
                var divChar = new List<char>();
                foreach (var c2 in j.Where(c2 => !divChar.Contains(c2)))
                {
                    divChar.Add(c2);
                }
                foreach (var cd in divChar)
                {
                    foreach (var s in text)
                    {
                        foreach (var c in s)
                        {
                            interval++;
                            if (cd == c && j == s)
                            {
                                mutex.WaitOne();
                                _depth += Math.Log(interval, 2);
                                mutex.ReleaseMutex();
                                interval = 0;
                            }
                        }
                    }
                }
            }
                );
             
            /*
            foreach (var i in dictionary)
            {
                var interval = 0;
                var divChar = new List<char>();
                foreach (var c2 in i.Where(c2 => !divChar.Contains(c2)))
                {
                    divChar.Add(c2);
                }
                foreach (var cd in divChar)
                {
                    foreach (var s in text)
                    {
                        foreach (var c in s)
                        {
                            interval++;
                            if (cd == c && i == s)
                            {
                                _depth += Math.Log(interval, 2);
                                interval = 0;
                            }
                        }
                    }
                }
            }*/
            /*
            foreach (var i in dictionary)
            {
                int interval=0;
                foreach (var word in text)
                {
                    interval++;
                    if (i.Key==word)
                    {
                        _depth += Math.Log(interval, 2);
                        interval = 0;
                    }
                }
            }*/

            return _depth / text.Count;
        }
    }
}
