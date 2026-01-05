using System.Text.Json.Serialization;
using RPG;

public class Statystyki
{
    [JsonPropertyName("poziom")]
    public int Poziom { get; set; }

    [JsonPropertyName("imie")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Imie { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("rasa")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Rasa { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("klasa")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Klasa { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("exp")]
    public int Exp { get; set; }

    [JsonPropertyName("exp_kolejny_poziom")]
    public int ExpKolejnyPoziom { get; set; }

    [JsonPropertyName("mana")]
    public int Mana { get; set; }

    [JsonPropertyName("maxMana")]
    public int MaxMana { get; set; }

    [JsonPropertyName("money")]
    public int Money { get; set; }

    public int Strength { get; set; }
    public int Fighting { get; set; }
    public int ShootingSkills { get; set; }
    public int Agility { get; set; }
    public int Speed { get; set; }
    public int Condition { get; set; }
    public int Inteligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int Defence { get; set; }
    public int Magic { get; set; }
    public int Luck { get; set; }
    public int WillPower { get; set; }

    public void GetStatsFromHero(Hero hero)
    {
        Strength = hero.Stats["strength"];
        Fighting = hero.Stats["fighting"];
        ShootingSkills = hero.Stats["shootingSkills"];
        Agility = hero.Stats["agility"];
        Speed = hero.Stats["speed"];
        Condition = hero.Stats["condition"];
        Inteligence = hero.Stats["inteligence"];
        Wisdom = hero.Stats["wisdom"];
        Charisma = hero.Stats["charisma"];
        Defence = hero.Stats["defence"];
        Magic = hero.Stats["magic"];
        Luck = hero.Stats["luck"];
        WillPower = hero.Stats["willPower"];
    }
}
