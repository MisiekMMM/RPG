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
    public Element AttackElement { get; set; }

    [JsonPropertyName("min")]
    public int MinStrength { get; set; }
    [JsonPropertyName("max")]
    public int MaxStrength { get; set; }
    [JsonPropertyName("attackType")]
    public AttackType attackType;

    public int GetAttackStrength()
    {
        Random random = new();

        return random.Next(MinStrength, MaxStrength + 1);
    }
}