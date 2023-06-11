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
        string logLable = "[deepskyblue2][[CH ]][/]";

        public CommandHandler()
        {
        }

        public CommandHandler(string logLable)
        {
            this.logLable = logLable;
        }

        public void CommandExecuter(Comand Command)
        {
            LogHandler Log = new LogHandler(this.logLable);
            Log.Log("Executing Command [lime]" + Command.Name + "[/]");
            foreach (var Stap in Command.Description)
            {
                switch (Stap.Split("::")[0])
                {
                    case "WEB":
                        Log.Log("Try Open Website [lime]" + Stap.Split("::")[1] + "[/]");
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    case "OPEN":
                        //TODO File Open
                        Log.Error("OPEN (WIP)");
                        break;
                    case "START":
                        Log.Log("Try Start [lime]" + Stap.Split("::")[1] + "[/]");
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    case "EXECUTE":
                        Log.Log("Try EXECUTE [lime]" + Stap.Split("::")[1] + "[/]");
                        Process.Start(new ProcessStartInfo(Stap.Split("::")[1]) { UseShellExecute = true });
                        break;
                    //TODO ADD Mohr Options
                    default:
                        Log.warrning("This Type of Description [lime]" + Stap + "[/] Is Broke");
                        break;
                }
            }
        }
    
    }
}