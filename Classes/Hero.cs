namespace RPG;

public class Hero
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
    public int level = 0;
    public int exp = 0;
    public Armor? armor = null;
    public Weapon? weapon = null;
    public Item[] inventory = new Item[8];
    public string klasa = "";
    public Race? rasa;
    public int mana;
    public int maxMana;

    public void AddHealth(int health)
    {
        this.health += health;

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }
    public void ChangeArmor(Armor armor)
    {
        Stats["defence"] -= this.armor!.defence;

        this.armor = armor;

        Stats["defence"] += this.armor.defence;
    }
    public void ChangeWeapon(Weapon weapon)
    {
        Stats["strength"] -= this.weapon!.strength;

        this.weapon = weapon;

        Stats["strength"] += this.weapon.strength;
    }
    public void ChangeMana(int mana)
    {
        this.mana += mana;

        if (this.mana > maxMana)
        {
            this.mana = maxMana;
        }
    }
}