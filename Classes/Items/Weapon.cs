using Terminal.Gui;

namespace RPG;

public class Weapon : Item
{
    public int sila = 0;
    public Weapon(string name) : base(name)
    {

    }

    public override Task Uzyj()
    {
        Manager.hero!.weapon = this;

        return Task.CompletedTask;
    }
}