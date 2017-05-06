using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkovChain.Classes
{
    public class Dictionary
    {
        public string Key { get; private set; }

        public List<string> Values { get; private set; }

        public Dictionary(string key, IEnumerable<string> values)
        {
            Setup(key);
            
            Values.AddRange(values);
        }

        public Dictionary(string key, string value)
        {
            Setup(key);

            Values.Add(value);
        }

        public void Add(string val)
        {
            Values.Add(val);
        }

        public void AddRange(IEnumerable<string> vals)
        {
            Values.AddRange(vals);
        }

        private void Setup(string key)
        {
            Key = key;

            Values = new List<string>();
        }
    }
}