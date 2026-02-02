using System.Text.Json.Serialization;
using RPG;

public class Walka
{
    [JsonPropertyName("przeciwnicy")]
    public List<Enemy> Przeciwnicy { get; set; }
}