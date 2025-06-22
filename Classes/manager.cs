using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Terminal.Gui;

namespace RPG;

public static class Manager
{
    public static string login = "";
    public static Label? flavorLabel;
    public static Hero? hero;
    public static Dictionary<string, Race> races = new()
    {
        {"Człowiek", new("Człowiek", 10,10,5,5,5,10,0,0,0,-10, 180)},
        {"Krasnolud", new("Krasnolud", 15, 10, 0, -20, -10, 0, -20, -10, 0, -20, 200) },
        {"Elf", new("Elf", -10, 0, 10, 5, 5, 5, 10,10, 0, 20, 150) }
    };
    public static ColorScheme ColorScheme = new()
    {
        Normal = new Terminal.Gui.Attribute(Color.White, Color.Black),
        Focus = new Terminal.Gui.Attribute(Color.Black, Color.White),
    };
}