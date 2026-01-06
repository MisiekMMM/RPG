using System.Text.Json.Serialization;
using RPG;

public class PrzedmiotSklep
{
    [JsonPropertyName("cena")]
    public int cena { get; set; }
    [JsonPropertyName("opis")]
    public string Opis { get; set; } = "";
    [JsonPropertyName("przedmiot")]
    public Przedmiot Przedmiot { get; set; } = new("", "", 0);
}