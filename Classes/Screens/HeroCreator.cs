using System.ComponentModel;
using System.Security.AccessControl;
using Terminal.Gui;

namespace RPG;

public partial class HeroCreator
{
    int kloc = 0;
    public HeroCreator()
    {
        Manager.hero = new();

        Init();

        nameField.SetFocus();
    }
    /// <summary>
    /// Submit button
    /// </summary>
    void OnButtonClicked(object s, CancelEventArgs e)
    {

    }
    void OnLosujClicked(object s, CancelEventArgs e)
    {
        if (kloc >= 2)
        {
            statsLabel.Visible = true;
            statsLabel.Text = $"Twoje statystyki dla {Manager.hero!.rasa} {Manager.hero!.klasa}";
        }

    }
    private void OnKlasaChanged(object sender, ListViewItemEventArgs e)
    {
        Manager.hero!.klasa = cmbKlasy.Text;
        kloc++;
    }
    void OnRasaChanged(object sender, ListViewItemEventArgs e)
    {
        Manager.hero!.rasa = cmbRasy.Text;
        kloc++;
    }
}

