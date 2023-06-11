using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
namespace VoiceAssistent.Handler
{
    public class LogHandler
    {
        private static LogHandler instance = null;
        private static readonly object padlock = new object();
        //TODO Write a Log Handler to use in the Project 
        string label = "[deepskyblue2][[LH ]][/]";
        bool openLog = true;
        LogHandler()
        {
        }
        public static LogHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new LogHandler();
                        }
                    }
                }
                return instance;
            }
        }
        public string Label { get => label; set => label = value; }
        public bool OpenLog { get => openLog; set => openLog = value; }

        public void Log(string msg, string label)
        {
            if (!openLog)
            {
                return;
            }
            AnsiConsole.MarkupLine(label + "->[aqua][[LOG]][/] "+ msg);
        }
        public void warrning(string msg, string label)
        {
            if (!openLog)
            {
                return;
            }
            AnsiConsole.MarkupLine(label+"->[darkorange3][[WAR]][/] "+ msg);

        }
        public void Error(string msg, string label)
        {
            if (!openLog)
            {
                return;
            }
            AnsiConsole.MarkupLine(label+"->[red3][[ERR]][/] "+ msg);

        }
        public void Panic(string msg, string label)
        {
            if (!openLog)
            {
                return;
            }
            AnsiConsole.MarkupLine(label+"->[darkred_1][[LOG]][/] "+ msg);

        }
        public void ListAusgabe(string ListLabele, string forwahl, string[] elemente, string label)
        {

            AnsiConsole.Write(new Rule(forwahl).LeftJustified().RuleStyle(Style.WithForeground(Color.DarkGoldenrod)));
            for (int i = 0; i < elemente.Length; i++)
            {
                AnsiConsole.MarkupLine(label + "->[deepskyblue2][[{0}]][/] [lime]{1}[/]", Markup.Escape(ListLabele), Markup.Escape(elemente[i]));
            }

        }

    }
}