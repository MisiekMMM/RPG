using System;

namespace RPG;

public class Item
{
    public string nazwa;
    public int hp;
    public Item(string nazwa, int hp)
    {
        this.hp = hp;
        this.nazwa = nazwa;
    }
}