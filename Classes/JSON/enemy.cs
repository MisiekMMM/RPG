using System.Diagnostics;
using System.Text.Json.Serialization;
using RPG;

public class Pzeciwnik
{
    [JsonPropertyName("nazwa")]
    public string Nazwa { get; set; } = "";

    [JsonPropertyName("hp")]
    public int Hp { get; set; }

    [JsonPropertyName("atak")]
    public int Atak { get; set; }

    [JsonPropertyName("opis")]
    public string Opis { get; set; } = "";
    [JsonPropertyName("typ")]
    public string Typ { get; set; } = "";

    [JsonPropertyName("ataki")]
    public List<Atak> Ataki { get; set; } = [];

    public Atak CastAttack()
    {
        Random random = new();

        Atak atak = Ataki[random.Next(0, Ataki.Count + 1)];

        return atak;
    }

    public bool ChangeHealthAndCheckKill(int health, string attackType)
    {
        if (attackType == "heal")
        {
            Hp += health;
        }
        else if (attackType == "")


            Hp += health;

        if (Hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}