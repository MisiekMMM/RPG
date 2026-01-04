using Terminal.Gui;

namespace RPG;

public class Armor : Item
{
    public int defence = 0;
    public Armor(string name) : base(name)
    {

    }

    public override void Uzyj()
    {
        Manager.hero!.ChangeArmor(this);
    }
}