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
    ComboBox cmbKlasy = new();
    ComboBox cmbRasy2 = new();
    Label label3 = new();
    private void Init()
    {
        ColorScheme = Manager.ColorScheme;

        label1.X = Pos.Center();
        label1.Y = 0;
        label1.Text = "Podaj imię dla swojej postaci:";
        label1.TextAlignment = Alignment.Center;

        nameField.X = Pos.Center();
        nameField.Y = Pos.Bottom(label1);
        nameField.Height = 1;
        nameField.Width = Dim.Percent(30);
        nameField.TextAlignment = Alignment.Center;

        label3.X = Pos.Center();
        label3.Y = Pos.Bottom(nameField) + 3;
        label3.Text = "Wybierz rasę:";
        label3.TextAlignment = Alignment.Center;

        cmbRasy2.X = Pos.Center();
        cmbRasy2.Y = Pos.Bottom(label3);
        cmbRasy2.SetSource<string>(new() { "Człowiek", "Elf", "Krasnolud" });
        cmbRasy2.ReadOnly = true;
        cmbRasy2.Width = Dim.Percent(30);
        cmbRasy2.Height = 4;
        cmbRasy2.SelectedItemChanged += OnRasaChanged;
        cmbRasy2.TextAlignment = Alignment.Center;

        label2.X = Pos.Center();
        label2.Y = Pos.Bottom(cmbRasy2) + 3;
        label2.Text = "Wybierz klasę:";
        label2.TextAlignment = Alignment.Center;

        cmbKlasy.X = Pos.Center();
        cmbKlasy.Y = Pos.Bottom(label2);
        cmbKlasy.SetSource<string>(new() { "Wojownik", "Mag", "Mnich" });
        cmbKlasy.Width = Dim.Percent(30);
        cmbKlasy.Height = 4;
        cmbKlasy.SelectedItem = 0;
        cmbKlasy.ReadOnly = true;
        cmbKlasy.SelectedItemChanged += OnKlasaChanged;
        cmbKlasy.Text = "--Wybierz klasę--";
        cmbKlasy.TextAlignment = Alignment.Center;

        statsLabel.X = Pos.Center();
        statsLabel.Y = Pos.Bottom(cmbKlasy) + 3;
        statsLabel.Text = "Twoje statystyki dla klasy x:\n";
        statsLabel.Visible = false;
        statsLabel.Width = Dim.Percent(60);
        statsLabel.Height = 4;
        statsLabel.TextAlignment = Alignment.Center;

        losujButton.X = Pos.Center();
        losujButton.Y = Pos.Bottom(statsLabel);
        losujButton.Text = "Losój statystyki";
        losujButton.Accepting += OnLosujClicked;

        submitButton.Text = "Gotowe";
        submitButton.X = Pos.Center();
        submitButton.Y = Pos.Bottom(losujButton);
        submitButton.Accepting += OnButtonClicked;

        Add(label1, nameField, label3, cmbRasy2, label2, cmbKlasy, statsLabel, losujButton, submitButton);
    }
}

