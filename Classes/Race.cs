using Terminal.Gui;

namespace RPG;

public class Race
{
    public string name = "";
    public int strength = 0;
    public int agility = 0;
    public int condition = 0;
    public int inteligence = 0;
    public int wisdom = 0;
    public int charisma = 0;
    public int mana;
    public int defence = 0;
    public int health = 0;
    public int maxHealth = 0;
    public int magic = 0;
    public int luck = 0;

    public Race(string nazwa)
    {
        this.name = nazwa;
    }
}