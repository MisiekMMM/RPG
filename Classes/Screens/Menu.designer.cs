using Terminal.Gui;

namespace RPG;

public partial class Menu : Window
{
    FrameView save1 = new();
    FrameView save2 = new();
    FrameView save3 = new();
    Label label1 = new();
    Label label2 = new();
    Label label3 = new();
    Label lblTitle1 = new();
    Label lblTitle2 = new();
    Label lblTitle3 = new();
    Button btnPlay1 = new();
    Button btnPlay2 = new();
    Button btnPlay3 = new();
    void Init()
    {
        SetBorderStyle(LineStyle.None);
        ColorScheme = Manager.ColorScheme;

        save1.SetBorderStyle(LineStyle.Rounded);
        save1.Height = Dim.Fill();
        save1.Width = Dim.Percent(33);
        save1.Y = 0;
        save1.X = Pos.Percent(0);
        save1.Add(label1, lblTitle1, btnPlay1);

        save2.SetBorderStyle(LineStyle.Rounded);
        save2.Height = Dim.Fill();
        save2.Width = Dim.Percent(33);
        save2.Y = 0;
        save2.X = Pos.Percent(33);
        save2.Add(label2, lblTitle2, btnPlay2);

        save3.SetBorderStyle(LineStyle.Rounded);
        save3.Height = Dim.Fill();
        save3.Width = Dim.Percent(33);
        save3.Y = 0;
        save3.X = Pos.Percent(66);
        save3.Add(label3, lblTitle3, btnPlay3);

        label1.TextAlignment = Alignment.Center;
        label1.Width = Dim.Fill();
        label1.Height = Dim.Percent(50);
        label1.X = Pos.Center();
        label1.Y = Pos.Center();

        label2.TextAlignment = Alignment.Center;
        label2.Width = Dim.Fill();
        label2.Height = Dim.Percent(50);
        label2.X = Pos.Center();
        label2.Y = Pos.Center();

        label3.TextAlignment = Alignment.Center;
        label3.Width = Dim.Fill();
        label3.Height = Dim.Percent(50);
        label3.X = Pos.Center();
        label3.Y = Pos.Center();

        lblTitle1.TextAlignment = Alignment.Center;
        lblTitle1.Width = Dim.Fill();
        lblTitle1.Height = 1;
        lblTitle1.X = Pos.Center();
        lblTitle1.Y = Pos.Percent(5);
        lblTitle1.Text = "Zapis nr. 1";

        lblTitle2.TextAlignment = Alignment.Center;
        lblTitle2.Width = Dim.Fill();
        lblTitle2.Height = 1;
        lblTitle2.X = Pos.Center();
        lblTitle2.Y = Pos.Percent(5);
        lblTitle2.Text = "Zapis nr. 2";

        lblTitle3.TextAlignment = Alignment.Center;
        lblTitle3.Width = Dim.Fill();
        lblTitle3.Height = 1;
        lblTitle3.X = Pos.Center();
        lblTitle3.Y = Pos.Percent(5);
        lblTitle3.Text = "Zapis nr. 3";

        btnPlay1.Text = "Graj";
        btnPlay1.X = Pos.Center();
        btnPlay1.Y = Pos.Bottom(label1) + 3;
        btnPlay1.Accepting += onPlayClicked;

        btnPlay2.Text = "Graj";
        btnPlay2.X = Pos.Center();
        btnPlay2.Y = Pos.Bottom(label2) + 3;
        btnPlay2.Accepting += onPlayClicked;

        btnPlay3.Text = "Graj";
        btnPlay3.X = Pos.Center();
        btnPlay3.Y = Pos.Bottom(label3) + 3;
        btnPlay3.Accepting += onPlayClicked;

        Add(save1, save2, save3);
    }
}