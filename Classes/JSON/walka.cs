using System.Text.Json.Serialization;
using RPG;

public class Walka
{
    [JsonPropertyName("przeciwnicy")]
    public List<Przeciwnik> Przeciwnicy { get; set; }
}