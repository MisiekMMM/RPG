using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlmTornado.Code;
using Terminal.Gui;

namespace RPG;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

public class Response
{
    [JsonPropertyName("historia")]
    public string Historia { get; set; }

    [JsonPropertyName("wybor")]
    public Wybor Wybor { get; set; }
    [JsonPropertyName("przedmioty")]
    public List<Item> Przedmioty { get; set; }
    [JsonPropertyName("sklep")]
    public Sklep Sklep { get; set; }
    [JsonPropertyName("money")]
    public int Money { get; set; }
    [JsonPropertyName("walka")]
    public List<Enemy> Walka { get; set; }
    [JsonPropertyName("zycie")]
    public int Zycie { get; set; }

    [JsonPropertyName("statystyki")]
    public Dictionary<string, int> Stats { get; set; }

    [JsonPropertyName("exp")]
    public int Exp { get; set; }

    [JsonPropertyName("zaklecia")]
    public List<Attack> Spells { get; set; } = [];

    public static Response SetValuesFromJson(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        Response scena = JsonSerializer.Deserialize<Response>(json, options)!;

        return scena;
    }

}