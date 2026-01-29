using Terminal.Gui;

public partial class TempBattle : Window
{
    Label statusBar = new();
    TimingAttackView timingAttackView = new();
    void Init()
    {
        statusBar.Text = "1234";
        statusBar.X = Pos.Center();
        statusBar.Y = Pos.Percent(10);

        timingAttackView.X = Pos.Center();
        timingAttackView.Y = Pos.Center();

        timingAttackView.CanFocus = true;
        timingAttackView.SetFocus();

        Add(statusBar, timingAttackView);

        timingAttackView.CanFocus = true;
        timingAttackView.SetFocus();
    }
}