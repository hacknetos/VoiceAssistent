using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VoiceAssistent.Builder;
namespace VoiceAssistent.Handler
{
    public class CommandHandler
    {
        string logLable = "[darkslategray2][[CH ]][/]";

        public CommandHandler()
        {
        }

        public CommandHandler(string logLable)
        {
            this.LogLable = logLable;
        }

        public string LogLable { get => logLable; set => logLable = value; }

        public void CommandExecuter(Comand Command)
        {
            LogHandler Log = LogHandler.Instance;
            OptionsCommandHandler OCH = OptionsCommandHandler.Instance;
            // Log.Log("Executing Command [lime]" + Command.Name + "[/]", this.logLable);
            foreach (var Stap in Command.Description)
            {
                bool tmp;
                switch (Stap.Split("::")[0])
                {
                    case "WEB":
                        Log.Log("Try Open Website [lime]" + Stap.Split("::")[1] + "[/]", this.logLable);
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    case "OPEN":
                        //TODO File Open
                        Log.Error("OPEN (WIP)", this.logLable);
                        break;
                    case "START":
                        Log.Log("Try Start [lime]" + Stap.Split("::")[1] + "[/]", this.logLable);
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    case "EXECUTE":
                        Log.Log("Try EXECUTE [lime]" + Stap.Split("::")[1] + "[/]", this.logLable);
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    case "WRITE":
                        Log.Log("[lime]" + Stap.Split("::")[1] + "[/]", this.logLable);
                        break;
                    case "SHOWWIN":
                        tmp = OCH.SwitchWindowMode();
                        if (tmp)
                        {
                            Log.Log("The Window is Shown", this.logLable);
                        }
                        else
                        {
                            Log.Log("The Window is Hide", this.logLable);
                        }
                        break;
                    case "HIDEWIN":
                        tmp = OCH.SwitchWindowMode();
                        if (tmp)
                        {
                            Log.Log("The Window is Shown", this.logLable);
                        }
                        else
                        {
                            Log.Log("The Window is Hide", this.logLable);
                        }
                        break;
                    case "LogMode":
                        OCH.SwitchLogMode();
                        break;
                    case "HELP":
                        //TODO Help Command Einfügen
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;

                    //TODO ADD Mohr Options
                    //Z.B. Find OR Scann
                    default:
                        Log.warrning("This Type of Description [lime]" + Stap + "[/] Is Broke", this.logLable);
                        break;
                }
            }
        }

    }
}