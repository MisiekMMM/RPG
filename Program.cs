using System.Diagnostics.CodeAnalysis;
using System.Text;
using Terminal.Gui;

namespace RPG;

public static class Program
{
    public static async Task MainAsync()
    {


    }
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        //MainAsync().GetAwaiter().GetResult();

        Console.Clear();
        string test = "El Kloc Big Kloc";
        Console.WriteLine(test[0..7]);
        Console.WriteLine("Ai loading...");
        AiManager.SetupChat();
        Console.WriteLine("Press any key...");
        Console.ReadKey();

        Application.Init();

        //Application.Run(new TempBattle());

        //Application.Run(new Login());
        //Application.Run(new Menu());

        Application.Run(new HeroCreator());

        // if (!File.Exists(Path.Combine(Environment.CurrentDirectory, @$"save{Manager.saveId}.sv")))
        // {
        //     Application.Run(new HeroCreator());
        // }

        Application.Run(new Game());
    }

}