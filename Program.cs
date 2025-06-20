using System.Text;
using Terminal.Gui;

namespace RPG;

public static class Program
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.Clear();
        Console.WriteLine("El kloc");
        Console.ReadKey();

        Application.Init();

        Application.Run(new Login());
        Application.Run(new HeroCreator());
    }

}