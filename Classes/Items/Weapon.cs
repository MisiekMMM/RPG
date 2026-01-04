using Terminal.Gui;

namespace RPG;

public class Weapon : Item
{
    public int strength = 0;
    public Weapon(string name) : base(name)
    {

    }

    public override void Uzyj()
    {
        Manager.hero!.ChangeWeapon(this);

        return;
    }
}