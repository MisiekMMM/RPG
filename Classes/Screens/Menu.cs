using System.ComponentModel;
using Terminal.Gui;

namespace RPG;

public partial class Menu
{
    public Menu()
    {
        Init();

        if (Manager.Load(Path.Combine(Environment.CurrentDirectory, "save1.sv")))
        {
            label1.Text = $"{Manager.hero!.name} lvl {Manager.hero.level}\n{Manager.hero.klasa}\n{Manager.hero.rasa!.name}\n";
            btnPlay1.Text = $"Graj";
        }
        else
        {
            label1.Text = "------\n------\n------\n";
            btnPlay1.Text = $"Nowa gra";
        }

        if (Manager.Load(Path.Combine(Environment.CurrentDirectory, "save2.sv")))
        {
            label2.Text = $"{Manager.hero!.name} lvl {Manager.hero.level}\n{Manager.hero.klasa}\n{Manager.hero.rasa!.name}\n";
            btnPlay2.Text = $"Graj";
        }
        else
        {
            label2.Text = "------\n------\n------\n";
            btnPlay2.Text = $"Nowa gra";
        }

        if (Manager.Load(Path.Combine(Environment.CurrentDirectory, "save3.sv")))
        {
            label3.Text = $"{Manager.hero!.name} lvl {Manager.hero.level}\n{Manager.hero.klasa}\n{Manager.hero.rasa!.name}\n";
            btnPlay3.Text = $"Graj";
        }
        else
        {
            label3.Text = "------\n------\n------\n";
            btnPlay3.Text = $"Nowa gra";
        }
    }
    void onPlayClicked(object s, CommandEventArgs e)
    {
        if (s.Equals(btnPlay1))
        {
            Manager.saveId = 1;
        }
        else if (s.Equals(btnPlay2))
        {
            Manager.saveId = 2;
        }
        else if (s.Equals(btnPlay3))
        {
            Manager.saveId = 3;
        }

        Application.RequestStop();
    }
}