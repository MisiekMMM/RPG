using System.Text;
using Terminal.Gui;

namespace RPG;

public static class Program
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        Application.Init();
        Application.Run(new Login());
        Application.Run(new Menu(Manager.login));
    }

}