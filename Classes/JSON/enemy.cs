using System.Diagnostics;
using System.Text.Json.Serialization;
using RPG;

namespace RPG;

public enum Element
{
    Water,
    Earth,
    Fire,
    Air,
    Light,
    Dark,
    None
}

public class Enemy
{
    [JsonPropertyName("nazwa")]
    public string Nazwa { get; set; } = "";

    [JsonPropertyName("hp")]
    public int Hp { get; set; }

    [JsonPropertyName("opis")]
    public string Opis { get; set; } = "";
    [JsonPropertyName("typ")]

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Element EnemyElement { get; set; } = Element.None;

    [JsonPropertyName("ataki")]
    public List<Attack> Ataki { get; set; } = [];

    public Attack CastAttack()
    {
        Random random = new();

        Attack atak = Ataki[random.Next(Ataki.Count)];

        return atak;
    }

    public bool ChangeHealthAndCheckKill(int Health, AttackType AttackType, Element AttackElement, out int Damage)
    {
        if (AttackType == AttackType.Healing)
        {
            Hp += Health;
            Damage = 0;
            return false;
        }
        else if (AttackType == AttackType.Physical)
        {
            Damage = Health;
            Hp += Health;

            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (AttackType == AttackType.Magic)
        {   //woda, ziemia, ogien, powietrze, swiatlo, cien

            Dictionary<Element, Dictionary<Element, float>> elementChart =
            new Dictionary<Element, Dictionary<Element, float>>
            {
                {
                    Element.Water, new Dictionary<Element, float>
                    {
                        { Element.Water, 1f },
                        { Element.Earth, 1.5f },
                        { Element.Fire, 1.5f },
                        { Element.Air, 0.5f },
                        { Element.Light, 1f },
                        { Element.Dark, 1f }
                    }
                },
                {
                    Element.Earth, new Dictionary<Element, float>
                    {
                        { Element.Water, 0.5f },
                        { Element.Earth, 1f },
                        { Element.Fire, 1.5f },
                        { Element.Air, 1.5f },
                        { Element.Light, 1f },
                        { Element.Dark, 1f }
                    }
                },
                {
                    Element.Fire, new Dictionary<Element, float>
                    {
                        { Element.Water, 0.5f },
                        { Element.Earth, 0.5f },
                        { Element.Fire, 1f },
                        { Element.Air, 1.5f },
                        { Element.Light, 1f },
                        { Element.Dark, 1f }
                    }
                },
                {
                    Element.Air, new Dictionary<Element, float>
                    {
                        { Element.Water, 1.5f },
                        { Element.Earth, 0.5f },
                        { Element.Fire, 1.5f },
                        { Element.Air, 1f },
                        { Element.Light, 1f },
                        { Element.Dark, 1f }
                    }
                },
                {
                    Element.Light, new Dictionary<Element, float>
                    {
                        { Element.Water, 1f },
                        { Element.Earth, 1f },
                        { Element.Fire, 1f },
                        { Element.Air, 1f },
                        { Element.Light, 0.6f },
                        { Element.Dark, 2f }
                    }
                },
                {
                    Element.Dark, new Dictionary<Element, float>
                    {
                        { Element.Water, 1f },
                        { Element.Earth, 1f },
                        { Element.Fire, 1f },
                        { Element.Air, 1f },
                        { Element.Dark, 0.6f },
                        { Element.Light, 2f }
                    }
                }
            };

            Damage = (int)(Health * elementChart[AttackElement][EnemyElement]);

            Hp += Damage;

            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Damage = Health;

        if (Hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}