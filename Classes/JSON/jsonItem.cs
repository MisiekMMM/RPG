using System.Text.Json.Serialization;
using RPG;

public class Przedmiot
{
    [JsonPropertyName("typ")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Typ { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("nazwa")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Nazwa { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("hp")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public int Hp { get; set; } // string because JSON has "0"
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Przedmiot(string Typ, string Nazwa, int Hp)
    {
        this.Typ = Typ;
        this.Nazwa = Nazwa;
        this.Hp = Hp;
    }
    public Item ConvertIntoItem()
    {
        //dodać typ
        int id = Item.CreateItem(Nazwa, Hp);

        return Item.GetItem(id);
    }
    public static Przedmiot ConvertFromItem(Item item)
    {
        if (item.GetType() == typeof(Weapon))
        {
            return new("bron", item.name, item.health);
        }
        else if (item.GetType() == typeof(Armor))
        {
            return new("zbroja", item.name, item.health);
        }
        else
        {
            return new("przedmiot", item.name, item.health);
        }
    }
}
