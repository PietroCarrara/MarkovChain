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

        public string[] Values { get; private set; }
    }
}