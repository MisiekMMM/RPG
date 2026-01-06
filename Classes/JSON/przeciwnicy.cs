using System.Text.Json.Serialization;
using RPG;

public class Przeciwnik
{
    // "nazwa": "",
    //             "hp": 0,
    //             "atak": 0,
    //             "opis": ""
    [JsonPropertyName("nazwa")]
    public string nazwa { get; set; } = "";
    [JsonPropertyName("hp")]
    public int Hp { get; set; }
    [JsonPropertyName("atak")]
    public int Atak { get; set; }
    [JsonPropertyName("opis")]
    public string Opis { get; set; } = "";
}