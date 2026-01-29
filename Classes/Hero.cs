using System.Data;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
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
    public JSONItem? armor = null;
    public JSONItem? weapon = null;
    public JSONItem[] inventory = new JSONItem[8];
    public string klasa = "";
    public Race? rasa;
    public int mana;
    public int maxMana;
    public int money;

    public async Task UseItem(JSONItem item, int itemID)
    {
        if (item == null)
        {
            return;
        }

        if (item.Typ == "przedmiot")
        {
            item.Uzyj();
            if (item.Hp != 0)
                inventory[itemID] = null!;
        }
        else if (item.Typ == "zbroja")
        {
            await Manager.hero!.ChangeArmor(item, itemID);
        }
        else if (item.Typ == "bron")
        {
            await Manager.hero!.ChangeWeapon(item, itemID);
        }
    }

    public async Task GiveItem(JSONItem item)
    {
        if (Utils.IsAnyNull(inventory))
        {
            inventory[Utils.FindLastIndex(inventory)] = item;
        }
        else
        {
            await Utils.WriteFlavorAsync("Nie masz tyle miejsca w ekwipunku! Wybierz przedmiot, który chcesz wyrzucić.");
            Manager.inventoryButtons[8].Text = item.Nazwa;

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
    public async Task ChangeArmor(JSONItem armor, int itemID)
    {
        JSONItem OldItem = this.armor!;

        if (OldItem != null)
        {
            Stats["defence"] -= OldItem.Hp;

            this.armor = armor;

            Stats["defence"] += this.armor.Hp;

            inventory[itemID] = null!;

            await GiveItem(OldItem);
        }
        else
        {
            this.armor = armor;

            Stats["defence"] += this.armor.Hp;

            inventory[itemID] = null!;
        }
    }
    public async Task ChangeWeapon(JSONItem weapon, int itemID)
    {
        JSONItem OldWeapon = this.weapon!;

        if (OldWeapon != null)
        {
            Stats["strength"] -= OldWeapon.Hp;

            this.weapon = weapon;

            inventory[itemID] = null!;

            Stats["strength"] += this.weapon.Hp;

            await GiveItem(OldWeapon);
        }
        else
        {
            this.weapon = weapon;

            inventory[itemID] = null!;

            Stats["strength"] += this.weapon.Hp;
        }
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