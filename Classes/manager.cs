using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Terminal.Gui;

namespace RPG;

public static class Manager
{
    public static string login = "";
    public static Label? flavorLabel;
    public static Label? StoryLabel;
    public static Button? nextButton;
    public static Hero? hero;
    public static int saveId = 0;
    public static List<int> values = new();
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
    public static void Save(string path)
    {
        using StreamWriter sW = new(path);

        sW.WriteLine(hero!.name);
        foreach (var key in hero.Stats)
        {
            sW.WriteLine(key.Value);
        }
        sW.WriteLine(hero!.health);
        sW.WriteLine(hero!.maxHealth);
        sW.WriteLine(hero!.mana);
        sW.WriteLine(hero!.maxMana);
        sW.WriteLine(hero!.level);
        sW.WriteLine(hero!.exp);
        foreach (Item item in hero!.inventory)
        {
            if (item != null)
            {
                sW.WriteLine(item.id);
            }
            else
            {
                sW.WriteLine("-");
            }
        }
        sW.WriteLine(hero!.armor == null ? "-" : hero.armor.id);
        sW.WriteLine(hero!.weapon == null ? "-" : hero.weapon.id);
        sW.WriteLine(hero!.rasa!.name);
        sW.WriteLine(hero!.klasa);//change later

        for (int i = 0; i < values.Count; i++)
        {
            sW.WriteLine(values[i]);
        }
    }
    public static bool Load(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }

        hero = new();

        using StreamReader sR = new(path);

        hero!.name = sR.ReadLine()!;
        foreach (var key in hero.Stats)
        {
            hero.Stats[key.Key] = int.Parse(sR.ReadLine()!);
        }
        hero!.health = int.Parse(sR.ReadLine()!);
        hero!.maxHealth = int.Parse(sR.ReadLine()!);
        hero!.mana = int.Parse(sR.ReadLine()!);
        hero!.maxMana = int.Parse(sR.ReadLine()!);
        hero!.level = int.Parse(sR.ReadLine()!);
        hero!.exp = int.Parse(sR.ReadLine()!);

        for (int i = 0; i < hero.inventory.Length; i++)
        {
            string vl = sR.ReadLine()!;
            if (vl != "-")
            {
                hero.inventory[i] = Item.GetItem(int.Parse(vl));
            }
            else
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                hero.inventory[i] = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }
        }
        string rd = sR.ReadLine()!;
        if (rd != "-")
        {
            hero.armor = (Armor)Item.GetItem(int.Parse(rd));
        }
        else
        {
            hero.armor = null;
        }

        rd = sR.ReadLine()!;
        if (rd != "-")
        {
            hero.weapon = (Weapon)Item.GetItem(int.Parse(rd));
        }
        else
        {
            hero.weapon = null;
        }
        hero.rasa = races[sR.ReadLine()!];
        hero.klasa = sR.ReadLine()!;//change later

        for (int i = 0; i < values.Count; i++)
        {
            values[i] = int.Parse(sR.ReadLine()!);
        }

        return true;
    }
}