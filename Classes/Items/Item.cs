using System.Threading.Tasks;
using Terminal.Gui;

namespace RPG;

public class Item
{
    public string name;
    public int health = 0;
    public string[] useText = { };
    public Item(string name)
    {
        this.name = name;
    }
    public virtual async Task Uzyj()
    {
        Manager.hero!.health += health;
        await Utils.WriteAsync(useText[new Random().Next(0, useText.Length - 1)]);
    }
}