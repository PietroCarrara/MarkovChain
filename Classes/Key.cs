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

        public Dictionary(string key, string[] values)
        {
            Setup();

            Values.AddRange(values);
        }

        public Dictionary(string key, string value)
        {
            Setup();

            Values.Add(value);
        }

        private void Setup()
        {
            Values = new List<string>();
        }
    }
}