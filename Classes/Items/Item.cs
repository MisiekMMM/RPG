using System.Threading.Tasks;
using Terminal.Gui;

namespace RPG;

public class Item
{
    public static List<Item> itemList = new()
    {
        new("Chleb"){id = 0,health =  35, useText = { $"Zjadasz chleb!\nOdzyskujesz 35 HP", $"Chleb ropływa się w twoich ustach\nOdzyskujesz 35 HP", "Ten chleb powinien leczyć więcej niż 34 HP\nOdzyskujesz 35 HP" } },
    };
    public string name;
    public int health = 0;
    public int id = 0;
    public List<string> useText = new();
    public Item(string name)
    {
        this.name = name;
    }
    public virtual async Task Uzyj()
    {
        Manager.hero!.health += health;
        await Utils.WriteAsync(useText[new Random().Next(0, useText.Count - 1)]);
    }
    public static Item GetItem(int id)
    {
        return itemList[id];
    }
}