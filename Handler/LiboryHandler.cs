using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceAssistent.Builder;
namespace VoiceAssistent.Handler
{
    public class LiboryHandler
    {
        string name;
        string liboryLable;
        Dictionary<string, Comand> libory;
        public LiboryHandler(string name, string liboryLable)
        {
            this.Name = name;
            this.LiboryLable = liboryLable;
            this.libory = new Dictionary<string, Comand>();
        }
        public LiboryHandler(string name, string liboryLable, Dictionary<string, Comand> libory)
        {
            this.Name = name;
            this.LiboryLable = liboryLable;
            this.Libory = libory;
        }

        public string Name { get => name; set => name = value; }
        public string LiboryLable { get => liboryLable; set => liboryLable = value; }
        public Dictionary<string, Comand> Libory { get => libory; set => libory = value; }
    }
}