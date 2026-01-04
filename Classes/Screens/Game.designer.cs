using Terminal.Gui;

namespace RPG;

public partial class Game : Window
{
    FrameView LeftPanel = new();
    FrameView MiddlePanel = new();
    FrameView DownPanel = new();
    FrameView RightPanel = new();

    Label lblName = new();
    Label lblLevel = new();
    Label lblRaceClass = new();
    Label lblStats = new();

    Label lblFlavor = new();

    Label lblWeapon = new();
    Label lblArmor = new();
    Label lblHP = new();

    Button item1 = new();
    Button item2 = new();
    Button item3 = new();
    Button item4 = new();
    Button item5 = new();
    Button item6 = new();
    Button item7 = new();
    Button item8 = new();

    Button nextButton = new();
    void Init()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
        ColorScheme = Manager.ColorScheme;

        SetBorderStyle(LineStyle.None);

        LeftPanel.Width = Dim.Percent(20);
        LeftPanel.Height = Dim.Fill();
        LeftPanel.SetBorderStyle(LineStyle.Rounded);
        LeftPanel.X = Pos.Percent(0);
        LeftPanel.Y = 0;
        LeftPanel.Add(lblName, lblLevel, lblRaceClass, lblStats);

        MiddlePanel.Width = Dim.Percent(60);
        MiddlePanel.Height = Dim.Percent(70);
        MiddlePanel.SetBorderStyle(LineStyle.Rounded);
        MiddlePanel.X = Pos.Percent(20);
        MiddlePanel.Y = Pos.Percent(0);

        DownPanel.Width = Dim.Percent(60);
        DownPanel.Height = Dim.Percent(30);
        DownPanel.SetBorderStyle(LineStyle.Rounded);
        DownPanel.X = Pos.Percent(20);
        DownPanel.Y = Pos.Percent(70);
        DownPanel.Add(lblFlavor, nextButton);

        RightPanel.Width = Dim.Percent(20);
        RightPanel.Height = Dim.Fill();
        RightPanel.SetBorderStyle(LineStyle.Rounded);
        RightPanel.X = Pos.Percent(80);
        RightPanel.Y = Pos.Percent(0);
        RightPanel.Add(lblArmor, lblWeapon, item1, item2, item3, item4, item5, item6, item7, item8, lblHP);

        lblName.X = Pos.Center();
        lblName.Y = Pos.Percent(10);
        lblName.Text = "Name";

        lblLevel.X = Pos.Center();
        lblLevel.Y = Pos.Percent(13);
        lblLevel.Text = "Level";

        lblRaceClass.X = Pos.Center();
        lblRaceClass.Y = Pos.Percent(16);
        lblRaceClass.Text = "Rasa - Klasa";

        lblStats.X = Pos.Center();
        lblStats.Y = Pos.Bottom(lblRaceClass) + 3;
        lblStats.Height = 14;
        lblStats.Text = "Statystyki:\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----";

        lblFlavor.Width = Dim.Fill();
        lblFlavor.Height = Dim.Fill(1);
        lblFlavor.X = 0;
        lblFlavor.Y = 0;
        lblFlavor.Text = " * Test!";

        nextButton.X = Pos.Center();
        nextButton.Y = Pos.Bottom(lblFlavor);
        nextButton.Text = ">>>";

        lblWeapon.X = Pos.Center();
        lblWeapon.Y = Pos.Percent(10);
        lblWeapon.Text = "Bron:";

        lblArmor.X = Pos.Center();
        lblArmor.Y = Pos.Bottom(lblWeapon);
        lblArmor.Text = "Zbroja:";

        item1.X = Pos.Center();
        item2.X = Pos.Center();
        item3.X = Pos.Center();
        item4.X = Pos.Center();
        item5.X = Pos.Center();
        item6.X = Pos.Center();
        item7.X = Pos.Center();
        item8.X = Pos.Center();

        item1.Y = Pos.Bottom(lblArmor) + 3;
        item2.Y = Pos.Bottom(item1);
        item3.Y = Pos.Bottom(item2);
        item4.Y = Pos.Bottom(item3);
        item5.Y = Pos.Bottom(item4);
        item6.Y = Pos.Bottom(item5);
        item7.Y = Pos.Bottom(item6);
        item8.Y = Pos.Bottom(item7);

        item1.Text = "---";
        item2.Text = "---";
        item3.Text = "---";
        item4.Text = "---";
        item5.Text = "---";
        item6.Text = "---";
        item7.Text = "---";
        item8.Text = "---";

        lblHP.X = Pos.Center();
        lblHP.Y = Pos.Bottom(item8) + 3;
        lblHP.Text = "HP: 100/100";

        Add(LeftPanel, MiddlePanel, DownPanel, RightPanel);
    }
}