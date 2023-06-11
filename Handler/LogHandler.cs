using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
namespace VoiceAssistent.Handler
{
    public class LogHandler
    {
        //TODO Write a Log Handler to use in the Project 
        string label = "[deepskyblue2][[LH ]][/]";
        public LogHandler(string label)
        {
            this.Label = label;
        }

        public string Label { get => label; set => label = value; }

        public void Log(string msg)
        {
            AnsiConsole.MarkupLine("[aqua][[LOG]][/]{0} {1}", Markup.Escape(this.Label), Markup.Escape(msg));
        }
        public void warrning(string msg)
        {
            AnsiConsole.MarkupLine("[darkorange3][[WAR]][/]{0} {1}", Markup.Escape(this.Label), Markup.Escape(msg));

        }
        public void Error(string msg)
        {
            AnsiConsole.MarkupLine("[red3][[ERR]][/]{0} {1}", Markup.Escape(this.Label), Markup.Escape(msg));

        }
        public void Panic(string msg)
        {
            AnsiConsole.MarkupLine("[darkred_1][[LOG]][/]{0} {1}", Markup.Escape(this.Label), Markup.Escape(msg));

        }

    }
}