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
    public string Opis { get; set; }
}