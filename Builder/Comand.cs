using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceAssistent.Builder
{
    public class Comand
    {
        string name;
        List<string> description;
        //! Trennzeichen = :: 

        public Comand(string name)
        {
            this.name = name;
            this.description = new List<string>();
        }

        public Comand(string name, List<string> description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get => name; set => name = value; }
        public List<string> Description { get => description; set => description = value; }
    }
}