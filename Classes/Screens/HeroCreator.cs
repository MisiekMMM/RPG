using System.ComponentModel;
using System.Security.AccessControl;
using Terminal.Gui;

namespace RPG;

public partial class HeroCreator
{
    Random rnd = new();
    int kloc = 0;
    bool areStats = false;
    public HeroCreator()
    {
        Manager.hero = new();

        Init();

        //nameField.SetFocus();
    }
    /// <summary>
    /// Submit button
    /// </summary>
    void OnButtonClicked(object s, CancelEventArgs e)
    {
        if (areStats)
        {
            Manager.Save($"save{Manager.saveId}.sv");
            MessageBox.Query("!!!", "Zapisano", "Wyjdź", "Wyjdź");
            Application.RequestStop();
        }
        else
        {
            MessageBox.Query("Błąd", "Najpierw wylosuj statystyki!", "Ok");
        }
    }
    void OnLosujClicked(object s, CancelEventArgs e)
    {
        if (kloc >= 2)
        {
            areStats = true;

            Manager.hero = new();
            Manager.hero.name = nameField.Text;
            Manager.hero.rasa = Manager.races[cmbRasy2.Text];

            Manager.hero.health = Manager.hero.rasa.health;
            Manager.hero.maxHealth = Manager.hero.rasa.maxHealth;
            Manager.hero.mana = Manager.hero.rasa.mana;
            Manager.hero.maxMana = Manager.hero.rasa.maxMana;

            string statString = "";

            foreach (var key in Manager.hero.Stats)
            {
                Manager.hero.Stats[key.Key] = rnd.Next(20, 50) + Manager.hero.rasa.Stats[key.Key];
                statString += $"{key.Key}: {Manager.hero.Stats[key.Key]},";
            }

            statsLabel.Visible = true;
            statsLabel.Text = $"Twoje statystyki dla {Manager.hero!.rasa.name} {Manager.hero!.klasa}:\n{statString}";
        }

    }
    private void OnKlasaChanged(object sender, ListViewItemEventArgs e)
    {
        Manager.hero!.klasa = cmbKlasy.Text;
        kloc++;
    }
    void OnRasaChanged(object sender, ListViewItemEventArgs e)
    {
        Manager.hero!.rasa = Manager.races![cmbRasy2.Text];
        kloc++;
    }
}

