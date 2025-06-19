using Terminal.Gui;

namespace RPG;

public partial class Menu : Window
{
    FrameView frameView = new();
    Button button = new();
    private void Init()
    {
        frameView.Border = new()
        {
            BorderStyle = BorderStyle.Double
        };
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
            TextAlignment = TextAlignment.Left,
        });

        Border = new()
        {
            BorderStyle = BorderStyle.Double,
        };
        Width = Dim.Fill();
        Height = Dim.Fill();

        button.Text = "Click Me!";
        button.X = Pos.Center();
        button.Y = Pos.Center();

        button.Clicked += OnButtonClicked;

        Add(button, frameView);
    }
}

