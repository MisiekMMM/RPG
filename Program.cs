using System.Diagnostics.CodeAnalysis;
using System.Text;
using Terminal.Gui;

namespace RPG;

public static class Program
{
    public static async Task MainAsync()
    {
        await AiManager.Generate("Explain what is ai in a few sentences");

    }
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        //MainAsync().GetAwaiter().GetResult();

        Console.Clear();
        Console.WriteLine("El kloc");
        Console.ReadKey();

        Application.Init();

        Application.Run(new Login());
        Application.Run(new Menu());

        if (!File.Exists(Path.Combine(Environment.CurrentDirectory, @$"save{Manager.saveId}.sv")))
        {
            Application.Run(new HeroCreator());
        }

        Application.Run(new Game());
    }

}