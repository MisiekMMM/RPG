using System.Text.Json.Serialization;
using RPG;

public class PrzedmiotSklep
{
    [JsonPropertyName("cena")]
    public int cena { get; set; }
    [JsonPropertyName("opis")]
    public string Opis { get; set; } = "";
    [JsonPropertyName("przedmiot")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Item Przedmiot { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}