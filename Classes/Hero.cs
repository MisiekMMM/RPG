using System.Data;
using Terminal.Gui;

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
    public int level = 1;
    public int exp = 0;
    public int[] levels = { 0, 0, 25, 30, 30, 35, 40, 40, 45, 50, 55, 60, 61 };
    public Armor? armor = null;
    public Weapon? weapon = null;
    public Item[] inventory = new Item[8];
    public string klasa = "";
    public Race? rasa;
    public int mana;
    public int maxMana;
    public int money;

    public void UseItem(Item item, int itemID)
    {
        if (item == null)
        {
            return;
        }
        item.Uzyj();
        Manager.hero!.inventory[itemID] = null!;
    }

    public async Task GiveItem(Item item)
    {
        if (Utils.IsAnyNull(inventory))
        {
            inventory[Utils.FindLastIndex(inventory)] = item;
        }
        else
        {
            await Utils.WriteFlavorAsync("Nie masz tyle miejsca w ekwipunku! Wybierz przedmiot, który chcesz wyrzucić.");
            Manager.inventoryButtons[8].Text = item.name;

            int buttonId = await Utils.WaitForInventoryButtonClickAsync(true);

            MessageBox.Query("Info", buttonId.ToString(), "ok");

            if (buttonId == 9)
            {
                return;
            }
            else
            {
                Manager.hero!.inventory[buttonId] = item;
            }
        }
    }
    public void AddHealth(int health)
    {
        this.health += health;

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }
    public void AddEXP(int exp)
    {
        this.exp += exp;

        if (exp >= levels[level + 1])
        {
            level++;
            exp -= levels[level];
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