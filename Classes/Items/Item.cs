using System.Threading.Tasks;
using Terminal.Gui;

namespace RPG;

public class Item
{
    public static List<Item> itemList = new()
    {
        new("Chleb"){id = 0,health =  35 },
    };
    public string name;
    public int health = 0;
    public int id = 0;
    public Item(string name)
    {
        this.name = name;
    }
    public virtual void Uzyj()
    {
        Manager.hero!.health += health;
    }
    public static Item GetItem(int id)
    {
        return itemList[id];
    }
    public static int CreateItem(string name, int health)
    {
        int id = itemList.Count;
        itemList.Add(new(name) { id = itemList.Count, health = health });
        return id;
    }
}