using Terminal.Gui;

namespace RPG;

public partial class HeroCreator : Window
{
    Label label1 = new();
    TextField nameField = new();
    Button submitButton = new();
    Button losujButton = new();
    Label statsLabel = new();
    Label label2 = new();
    ComboBox cmbRasy = new();
    ComboBox cmbKlasy = new();
    Label label3 = new();
    private void Init()
    {
        ColorScheme = Manager.ColorScheme;

        label1.X = 0;
        label1.Y = 0;
        label1.Text = "Podaj imię dla swojej postaci:";

        nameField.X = 0;
        nameField.Y = Pos.Bottom(label1);
        nameField.Height = 1;
        nameField.Width = Dim.Percent(30);

        label3.X = 0;
        label3.Y = Pos.Bottom(nameField) + 3;
        label3.Text = "Wybierz rasę:";

        cmbRasy.X = 0;
        cmbRasy.Y = Pos.Bottom(label3);
        cmbRasy.SetSource<string>(new() { "Człowiek", "Elf", "Krasnolud" });
        cmbRasy.Width = Dim.Percent(30);
        cmbRasy.Height = 4;
        cmbRasy.SelectedItem = 0;
        cmbRasy.ReadOnly = true;

        label2.X = 0;
        label2.Y = Pos.Bottom(cmbRasy) + 3;
        label2.Text = "Wybierz klasę:";

        cmbKlasy.X = 0;
        cmbKlasy.Y = Pos.Bottom(label2);
        cmbKlasy.SetSource<string>(new() { "Wojownik", "Mag", "Mnich" });
        cmbKlasy.Width = Dim.Percent(30);
        cmbKlasy.Height = 4;
        cmbKlasy.SelectedItem = 0;
        cmbKlasy.ReadOnly = true;

        statsLabel.X = 0;
        statsLabel.Y = Pos.Bottom(cmbKlasy) + 3;
        statsLabel.Text = "Twoje statystyki dla klasy x:";
        statsLabel.Visible = false;

        losujButton.X = 0;
        losujButton.Y = Pos.Bottom(statsLabel);
        losujButton.Text = "Losój statystyki";
        losujButton.Accepting += OnLosujClicked;

        submitButton.Text = "Gotowe";
        submitButton.X = 0;
        submitButton.Y = Pos.Bottom(losujButton);
        submitButton.Accepting += OnButtonClicked;

        Add(label1, nameField, label3, cmbRasy, label2, cmbKlasy, statsLabel, losujButton, submitButton);
    }
}

