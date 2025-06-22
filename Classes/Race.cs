using Terminal.Gui;

namespace RPG;

public class Race
{
    public Dictionary<string, int> Stats = new(){
        { "strength", 0},
        {"fighting", 0},
        {"shootingSkills",0 },
        {"agility", 0},
        {"speed", 0 },
        {"condition", 0},
        {"inteligence", 0},
        {"wisdom", 0},
        {"charisma", 0},
        {"defence", 0},
        {"magic",0 },
        {"luck", 0},
        { "willPower",0},
    };
    public string name = "";
    public int health = 0;
    public int maxHealth = 0;
    public int mana;
    public int maxMana;

    public Race(string nazwa, int strength, int fighting, int shootingSkills,
     int agility, int speed, int condition, int inteligence, int wisdom,
     int charisma, int maxMana, int maxHealth
     )
    {
        this.name = nazwa;
        this.mana = maxMana;
        this.maxMana = maxMana;
        this.maxHealth = maxHealth;
        this.health = maxHealth;

        Stats["strength"] = strength;
        Stats["fighting"] = fighting;
        Stats["shootingSkills"] = shootingSkills;
        Stats["agility"] = agility;
        Stats["speed"] = speed;
        Stats["condition"] = condition;
        Stats["inteligence"] = inteligence;
        Stats["wisdom"] = wisdom;
        Stats["charisma"] = charisma;
    }
}