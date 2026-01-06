using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlmTornado.Code;
using Terminal.Gui;

namespace RPG;

public class Response
{
    [JsonPropertyName("historia")]
    public string Historia { get; set; }
    [JsonPropertyName("wybor")]
    public Wybor Wybor { get; set; }
    [JsonPropertyName("przedmioty")]
    public List<Przedmiot> Przedmioty { get; set; }
    [JsonPropertyName("sklep")]
    public Sklep Sklep { get; set; }
    [JsonPropertyName("money")]
    public int Money { get; set; }
    [JsonPropertyName("walka")]
    public Walka Walka { get; set; }
    [JsonPropertyName("zycie")]
    public int Zycie { get; set; }

    public static Response SetValuesFromJson(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        Response scena = JsonSerializer.Deserialize<Response>(json, options)!;

        return scena;
    }

}