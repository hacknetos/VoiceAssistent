using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Recognition;
using Spectre.Console;
using VoiceAssistent.Builder;
internal class Program
{
    private static void Main(string[] args)
    {
        //TODO ARGS START EINBAUNE
        AnsiConsole.Write(new FigletText("ChatAssist"));
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        SpeechRecognitionEngine recordnizer = new SpeechRecognitionEngine();

        // TODO Eingebaute Commands.
        
        // TODO UserCommands.
        /** Castem Type of a Diconary pls :) */
        Dictionary<string, string> TheGrateLibory = new Dictionary<string, string>();
        //the GtateLibory Has Listet all the other CommandLiberys to Search;
        
    }
}