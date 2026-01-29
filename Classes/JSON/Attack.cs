using System;
using System.Text.Json.Serialization;

namespace RPG;

public enum AttackType
{
    Physical,
    Magical,
    Healing,
    Fire,
    Poison,
}

public class Atak
{
    [JsonPropertyName("nazwa")]
    public string Nazwa { get; set; } = "";

    [JsonPropertyName("typ")]
    public string Typ { get; set; } = "";

    [JsonPropertyName("min")]
    private int MinStrength { get; }
    [JsonPropertyName("max")]
    private int MaxStrength { get; }

    public AttackType attackType;

    public int GetAttackStrength()
    {
        Random random = new();

        return random.Next(MinStrength, MaxStrength + 1);
    }
}