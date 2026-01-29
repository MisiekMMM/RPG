using Terminal.Gui;

public class TimingAttackView : View
{
    float progress;
    bool finished;
    Timer timer;

    Label bar;
    Label info;

    public float AttackStrength { get; private set; }

    public TimingAttackView()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();

        info = new Label()
        {
            X = Pos.Center(),
            Y = 1,
            Text = "Press SPACE at the center!"
        };

        bar = new Label()
        {
            X = Pos.Center(),
            Y = 3
        };

        Add(info, bar);

        KeyDown += OnKeyDown;

        timer = new Timer(_ => Tick(), null, 0, 16);
    }

    void Tick()
    {
        if (finished)
        {
            timer.Dispose();
            return;
        }

        progress += 0.01f;

        if (progress > 1f)
        {
            finished = true;
            KeyDown -= OnKeyDown;
            info.Text = "MISSED (0%)";
            AttackStrength = 0f;
        }

        Application.Invoke(DrawBar);
    }

    void DrawBar()
    {
        int width = 20;
        int pos = (int)(progress * width);

        char[] chars = new string('-', width).ToCharArray();
        chars[Math.Min(pos, width - 1)] = '|';

        bar.Text = $"[{new string(chars)}]";
    }

    void OnKeyDown(object? sender, Key e)
    {
        if (e.KeyCode == KeyCode.Space && !finished)
        {
            finished = true;

            float distance = Math.Abs(progress - 0.5f);
            AttackStrength = Math.Max(0f, 1f - (distance / 0.5f));

            int percent = (int)(AttackStrength * 100);

            info.Text = $"ATTACK! {percent}%";
            e.Handled = true;
        }
    }
}