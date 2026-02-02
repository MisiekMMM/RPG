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
    public Element EnemyElement { get; set; }

    [JsonPropertyName("ataki")]
    public List<Attack> Ataki { get; set; } = [];

    public Attack CastAttack()
    {
        Random random = new();

        Attack atak = Ataki[random.Next(Ataki.Count)];

        return atak;
    }

    public bool ChangeHealthAndCheckKill(int Health, AttackType AttackType, Element AttackElement)
    {
        if (AttackType == AttackType.Healing)
        {
            Hp += Health;
            return false;
        }
        else if (AttackType == AttackType.Physical)
        {
            Hp += Health;
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

            Hp += (int)(Health * elementChart[AttackElement][EnemyElement]);
        }


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