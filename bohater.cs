using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace RPG;

public class Bohater
{
    protected int[] levels = new int[] { 0, 0, 10, 25, 50, 50, 60, 70, 80, 95, 110 };
    protected int maxHP { get; set; }
    protected string? imie { get; }

    protected int hp { get; set; }

    protected int zloto { get; set; }

    protected int Sila { get; set; }
    protected int Magia { get; set; }
    protected int Level { get; set; }
    protected int exp { get; set; }
    public int nagrodaExp { get; set; }

    public Item[] items = new Item[12];
    public Bohater(string imie)
    {
        this.imie = imie;
        this.hp = 0;
        this.zloto = 0;
        this.Level = 1;
    }

    public string GetImie()
    {
        return imie!;
    }
    public int GetHP()
    {
        return hp;
    }
    public void UstawHP(int hp)
    {
        this.hp = hp;
        if (this.hp > maxHP)
        {
            this.hp = maxHP;
        }
    }
    public void DodajPrzedmiot(Item item)
    {
        if (Utils.IsAnyNull(items))
        {
            int lastIndex = Utils.FindLastIndex(items);

            items[lastIndex] = item;
        }
    }
    protected void UsunPrzedmiot(int index)
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        items[index] = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        for (int i = 0; i < items.Length; i++)
        {
            //if (i == 0 && items[i] != null)
            if (i != 0 && items[i - 1] == null && items[i] != null)
            {
                items[i - 1] = items[i];
                Utils.DeleteItemFromArray(ref items, i);
            }
        }

    }
    public void ZmienZloto(int money)
    {
        zloto += money;
    }

    protected void UstawSile(int sila)
    {
        this.Sila = sila;
    }
    protected void UstawMagie(int magia)
    {
        this.Magia = magia;
    }
    protected void UstawLevel(int level)
    {
        this.Level = level;
    }
    public bool ZmienEXP(int exp)
    {
        this.exp += exp;
        if (this.exp > levels[Level + 1])
        {
            exp -= levels[Level + 1];
            LevelUp();

            return true;
        }
        else
        {
            return false;
        }
    }
    public void LevelUp()
    {

        Level++;
        maxHP += 20;
        hp = maxHP;
        Sila += 5;
        Magia += 5;
        Console.WriteLine("Twój level się zwiększył do poziomu " + Level);
    }
    public int GetZloto()
    {
        return zloto;
    }
    protected void UstawNagrody(int exp)
    {
        nagrodaExp = exp;
    }
    public int GetSila()
    {
        return Sila;
    }
    public int GetMoc()
    {
        return Magia;
    }
    protected void SetMaxHP(int hp)
    {
        maxHP = hp;
    }
    public bool UzyjPrzedmiotu(int index)
    {
        if (items[index] != null)
        {
            UstawHP(hp + items[index].hp);

            UsunPrzedmiot(index);

            return true;
        }
        return false;
    }

}