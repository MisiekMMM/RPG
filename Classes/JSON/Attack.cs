using System;
using System.Text.Json.Serialization;

namespace RPG;

public enum AttackType
{
    Physical,
    Magic,
    Healing
}

public class Attack
{
    [JsonPropertyName("nazwa")]
    public string Nazwa { get; set; } = "";

    [JsonPropertyName("typ")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Element AttackElement { get; set; } = Element.None;

    [JsonPropertyName("min")]
    public int MinStrength { get; set; }
    [JsonPropertyName("max")]
    public int MaxStrength { get; set; }
    [JsonPropertyName("attackType")]

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AttackType attackType = AttackType.Physical;

    [JsonPropertyName("mana")]
    public int ManaCost { get; set; }

    public int GetAttackStrength()
    {
        Random random = new();

        return random.Next(MinStrength, MaxStrength + 1);
    }
}