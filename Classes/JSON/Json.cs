using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlmTornado.Code;
using Terminal.Gui;

namespace RPG;

public class JSONReport
{
    [JsonPropertyName("wybor")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Wybor { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("przedmioty")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public List<Item> Przedmioty { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("wygranoWalke")]
    public bool WygranoWalke { get; set; }

    [JsonPropertyName("zakupionePrzedmioty")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public List<Item> ZakupionePrzedmioty { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("statystyki")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Statystyki Statystyki { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("ekwipunek")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public List<Item> Ekwipunek { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [JsonPropertyName("zaklecia")]
    public List<Attack> Spells { get; set; } = [];
    public JSONReport(string Wybor, List<Item> Przedmioty, bool wygranoWalke, List<Item> ZakupionePrzedmioty, Statystyki statystyki, List<Item> Ekwipunek, List<Attack> SpellList)
    {

        this.Wybor = Wybor;

        this.Przedmioty = new();

        foreach (Item item in Przedmioty)
        {
            this.Przedmioty.Add(item);
        }

        this.WygranoWalke = wygranoWalke;

        this.ZakupionePrzedmioty = new();
        foreach (Item item in ZakupionePrzedmioty)
        {
            this.ZakupionePrzedmioty.Add(item);
        }

        this.Statystyki = statystyki;

        this.Ekwipunek = new();
        foreach (Item item in Ekwipunek)
        {
            if (item != null)
            {
                this.Ekwipunek.Add(item);
            }
        }

        this.Spells = SpellList;
    }

    public static string Serialize(JSONReport obj)
    {

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        string json = JsonSerializer.Serialize(obj, options);

        return json;
    }
}