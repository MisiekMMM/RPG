using Terminal.Gui;

public partial class NewScreen : Window
{
    public TabView tabView = new();
    public Tab Tab1 = new();
    public Tab Tab2 = new();
    public Tab Tab3 = new();



    public void Init()
    {
        tabView.Width = Dim.Percent(30);
        tabView.Height = Dim.Percent(30);

        View view1 = new() { Width = Dim.Fill(), Height = Dim.Fill() };
        View view2 = new() { Width = Dim.Fill(), Height = Dim.Fill() };
        View view3 = new() { Width = Dim.Fill(), Height = Dim.Fill() };

        view1.Add(CreateLabel("123"));
        view2.Add(CreateLabel("321"));
        view3.Add(CreateLabel("Lorem ipsum"));

        Tab1.View = view1;
        Tab2.View = view2;
        Tab3.View = view3;

        tabView.AddTab(Tab1, true);
        tabView.AddTab(Tab2, true);
        tabView.AddTab(Tab3, true);

        Add(tabView);
    }

    public NewScreen()
    {
        Init();
    }

    private Label CreateLabel(string txt)
    {
        return new Label
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            X = Pos.Center(),
            Y = Pos.Center(),
            Text = txt
        };
    }
}
