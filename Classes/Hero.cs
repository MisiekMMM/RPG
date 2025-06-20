namespace RPG;

public class Hero
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
    public int level = 0;
    public int exp = 0;
    public int luck = 0;
    public Armor? armor = null;
    public Weapon? weapon = null;
    public Item[] inventory = new Item[8];

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
        defence -= this.armor!.defence;

        this.armor = armor;

        defence += this.armor.defence;
    }
}