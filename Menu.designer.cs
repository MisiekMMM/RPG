using Terminal.Gui;

namespace RPG;

public partial class Menu : Window
{
    FrameView frameView = new();
    Button button = new();
    private void Init()
    {
        frameView.BorderStyle = LineStyle.Double;
        frameView.X = 1;
        frameView.Y = 1;
        frameView.Width = 22;
        frameView.Height = 10;

        frameView.Add(new Label()
        {
            Text = "This is a long label that should wrap when it reaches the edge.",
            X = 0,
            Y = 0,
            Width = 20,
            Height = 10,  // or specify number of lines
            TextAlignment = Alignment.Start,
        });

        BorderStyle = LineStyle.Rounded;
        Border.Thickness = new()
        {
            Left = 1,
            Right = 1,
            Top = 1,
            Bottom = 1
        };
        Width = Dim.Fill();
        Height = Dim.Fill();

        button.Text = "Click Me!";
        button.X = Pos.Center();
        button.Y = Pos.Center();

        button.Accepting += OnButtonClicked;

        Add(button, frameView);
    }
}

