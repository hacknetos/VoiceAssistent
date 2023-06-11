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
using VoiceAssistent.Handler;

internal class Program
{
    //the GtateLibory Has Listet all the other CommandLiberys to Search;
    public static Dictionary<string, LiboryHandler> TheGrateLibory = new Dictionary<string, LiboryHandler>();
    static string logLable = "[darkviolet][[MAI]][/]";
    private static void Main(string[] args)
    {

        //TODO ARGS START EINBAUNE
        List<string> ChoiceList = new List<string>();
        LogHandler Log = LogHandler.Instance;
        AnsiConsole.Write(new FigletText("Voice Assist"));

        SpeechRecognitionEngine recordnizer = new SpeechRecognitionEngine();

        Dictionary<string, Comand> VoiceAssistStandartLibory = new Dictionary<string, Comand>();

        VoiceAssistStandartLibory.Add("Hallo", new Comand("Hallo", new List<string>() { "WRITE::Hallo " + System.Security.Principal.WindowsIdentity.GetCurrent().Name }));
        VoiceAssistStandartLibory.Add("Time", new Comand("Time", new List<string>() { "WRITE::" + TimeOnly.FromDateTime(DateTime.Now) }));
        VoiceAssistStandartLibory.Add("Date", new Comand("Date", new List<string>() { "WRITE::" + DateOnly.FromDateTime(DateTime.Now) }));
        VoiceAssistStandartLibory.Add("HIDE", new Comand("HIDE", new List<string>() { "HIDEWIN::", "WRITE::Windows is Hiden" }));
        VoiceAssistStandartLibory.Add("SHOW", new Comand("SHOW", new List<string>() { "SHOWWIN::", "WRITE::Windows is Show" }));
        VoiceAssistStandartLibory.Add("LOGMODE", new Comand("LOGMODE", new List<string>() { "LogMode::" }));
        VoiceAssistStandartLibory.Add("Help", new Comand("Help", new List<string>() { "WRITE::HELP" }));
        VoiceAssistStandartLibory.Add("Exit", new Comand("Exit", new List<string>() { "EXIT::EXIT" }));

        LiboryHandler AssistLibory = new LiboryHandler("Assist", "[deepskyblue2][[LIH]][/]", VoiceAssistStandartLibory);

        foreach (var Key in VoiceAssistStandartLibory.Keys)
        {
            ChoiceList.Add(Key);
        }

        Log.ListAusgabe("AI ", "Assist", ChoiceList.ToArray(), logLable);

        Choices AssistChoices = new Choices(ChoiceList.ToArray());

        GrammarBuilder AssistGrammerBuild = new GrammarBuilder("Assist");

        AssistGrammerBuild.Append(AssistChoices);

        Grammar AssistGrammer = new Grammar(AssistGrammerBuild);

        recordnizer.LoadGrammarAsync(AssistGrammer);

        TheGrateLibory.Add("Assist", AssistLibory);

        // TODO UserCommands.





        recordnizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recordnizer_SpeedchRecongized);
        recordnizer.SetInputToDefaultAudioDevice();
        recordnizer.RecognizeAsync(RecognizeMode.Multiple);
        while (true)
        {
            Console.ReadLine();
        }
    }

    private static void recordnizer_SpeedchRecongized(object? sender, SpeechRecognizedEventArgs e)
    {
        LogHandler Log = LogHandler.Instance;
        string spliter = e.Result.Text;
        TheGrateLibory[spliter.Split(" ")[0]].Executing(spliter.Split(" ")[1]);
        Log.Log("[lime]"+e.Result.Text+"[/] Is Recognized", "[darkviolet][[MAI]][/]->[purple_1][[REC]][/]");
    }
}