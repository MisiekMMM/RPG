using System.Text.Json.Serialization;
using RPG;

public class Sklep
{
    [JsonPropertyName("rozmowa")]
    public string Rozmowa { get; set; } = "";
    [JsonPropertyName("przedmioty")]
    public List<PrzedmiotSklep> Przedmioty { get; set; } = new();
}