using System.Text.Json.Serialization;
using RPG;

public class JSONItem
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
    public JSONItem(string Typ, string Nazwa, int Hp)
    {
        this.Typ = Typ;
        this.Nazwa = Nazwa;
        this.Hp = Hp;
    }

    public virtual void Uzyj()
    {
        if (Hp == 0)
        {
            return;
        }
        Manager.hero!.health += Hp;
    }
}
