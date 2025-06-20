using Terminal.Gui;

namespace RPG;

public partial class Menu : Window
{
    Label label1 = new();
    TextField nameField = new();
    Button submitButton = new();
    Button losujButton = new();
    Label statsLabel = new();
    Label label2 = new();
    RadioGroup rgKlasy = new();

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

        label2.X = 0;
        label2.Y = Pos.Bottom(nameField) + 3;
        label2.Text = "Wybierz klasę:";

        rgKlasy.X = 0;
        rgKlasy.Y = Pos.Bottom(label2);
        rgKlasy.Title = "Wybierz klasę:";
        rgKlasy.RadioLabels = ["Wojownik", "Mag", "Mnich"];
        rgKlasy.SelectedItem = 0;

        statsLabel.X = 0;
        statsLabel.Y = Pos.Bottom(rgKlasy) + 3;
        statsLabel.Text = "Twoje statystyki dla klasy x:";
        statsLabel.Visible = false;

        losujButton.X = 0;
        losujButton.Y = Pos.Bottom(statsLabel);
        losujButton.Text = "Losój statystyki";

        submitButton.Text = "Gotowe";
        submitButton.X = 0;
        submitButton.Y = Pos.Bottom(losujButton);
        submitButton.Accepting += OnButtonClicked;

        Add(label1, nameField, label2, rgKlasy, statsLabel, losujButton, submitButton);
    }
}

