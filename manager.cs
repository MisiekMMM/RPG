using Terminal.Gui;

namespace RPG;

public static class Manager
{
    public static string login = "";

    public static ColorScheme ColorScheme = new()
    {
        Normal = new Terminal.Gui.Attribute(Color.White, Color.Black),
        Focus = new Terminal.Gui.Attribute(Color.Black, Color.White),
    };
}