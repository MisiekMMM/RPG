using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

namespace RPG;

public partial class Login : Window
{
    TextField txtPassword = new();
    TextField txtLogin = new();
    Label label1 = new();
    Label label2 = new();
    Button loginButton = new();
    Label imageLabel = new();
    Button registerButton = new();

    void Init()
    {
        ColorScheme = new ColorScheme
        {
            Normal = new Attribute(Color.White, Color.Black),
            Focus = new Attribute(Color.Black, Color.White),
        };


        Width = Dim.Fill();
        Height = Dim.Fill();
        Title = "Login";

        imageLabel.Text = "                                                                             \n ░█▒▓░░░░░░░░░░▒██████▓██▒██░██▒▓▓▓▓▒▓▒▓▒▒▒▒░▒▒▒▒▒▓▓▓▓▒░▓███▓█▒░▒▓█▓▓▒░░░░░░ \n ░▓▒▒░▒▓▓░░░░░░▓██▓█████▓▒██▒██▓█▓██▒▒▓▒░░░▒▒▒▒▒░▒▒▒▓▓▒░░█████▒▒█████▒▒▒▓▒░░ \n ░▒▒░░▒░▒▒▒░▒▓█▒███████▓█▒█▓▓▒▓▒▒░░░▒▒▓▓▒▒▒░░░░░▒▒▓█▓▒▓▒░██▒██▒░▓▒░▒██▓▓▓▓█▓ \n ░░▒░░▒▒░▓▓░▓██▓█▓██░░░░█░█░░░▒░░░░░▒▓▓░░░▒▒▒▓█▓▒░░▒▓▒█▒▓▓████▓░▒▓▒▒██▒▒▒▒▓▓ \n ░░▒░░▒▓▓▒▓▓█████░██░░░░███░░░░░░▒▒░░▒▒▓▒▒▒▒▒░░▒▓▓██▓▒█▒▒▒████▓▒▒▓▒███▒▒░░▓▓ \n ░░▒▒▒▓▓░░▓▓███▓█▓█▒░▒▒▒▒▓▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▓▓▒░░░░░░░▒▒░░░███▓██▒▓██▒█▒░░▒▒▒ \n ░░▒▒▒▓▒▒▒▓██▒█▒███░▒░▒▒▒▓▒░░░▒▒▒░░░▒▒▒▒▒░▒███▓▒░▒░░▒▓▒▒░░██▓▒██▒░██▓██▓░░▒▒ \n ▒██▒▒▓▓▒▒█████▓███▒░▒▓▓▓▓▓▓░▓▓▒░▒▒░▒░░░██▒█▒█▓▒▒▒█▓▓▒▒░░░██▓▓█▒░░▓█████▒▒▒▒ \n ████░▒▓▒░████▓▓███▓▓▓▒▓▓█▓▓░▓▒▓▓▒▒▒▓▓█████▓▒▓██████████▓▓█▓██▒░▒▒░██▓███▒▒▓ \n ██▒█▓░▒▒▒█▒██▒▓▓▓▓▓▒░░░░░░▓░▒▒▒▓█████████████████████▓███▒▓█▓░▒░░▒████▓█▓▓▓ \n █▒▒█▓░▒▓████▓░░░░▒▒▒▒░░░▒▒▒░░░▒██████████████████████████▓▒▒▓░▒▓▓▒██████▓▓▒ \n ▒███▓▒▒▓████░░░░░░▒▒░░░░▒█▓▒░▒██████████▓░░░░░░░░▒████████▓▒▓▒░░███▓█░░▓▓▓░ \n ▓█░██▒███▓██░░▒░░░░░▒░▒▒▓█▓▓▒███▓▒███▒███▓░░░░░░░░░░▒██████▓▓▒▒▒████▓▒▒▒▒▒░ \n ▒▒███▒█▓█▓█▒░░░░▒▒░▒░▒▒▒██▓████▓▓▒░▒▓▒▓███▒░░░░░░░░░░░░█████▓▓▒░██▓█▒▓▓▒▒▒▒ \n ▓██████████▒░▒░░▒░░▒▒░▒██▓▓███▓▓▒░░▒▒▒░▒████▓░░░░░░░▓▓▓█████▓▓▓███▓█▓▓▓▒▒░█ \n ▓██░░██████▒▒░▒▒▒▒░░░░▓█▓▓▓███▒▓▓▓▒░░░░░▒██████▓░▒████████▓▓█▒███▓░▓██▓▒▒██ \n ██▓░▒▓██▓▒░▒▒▒▒░▒▒░░░░▓▓▒▓▓█▓█▒░█▓▒▒▒▒░░░░▒▓███████████████▓█▒████████▒▓██▒ \n █████░░░▒▒▒▒░▓██▒▒▒▒░▒▓▓▒██▓██▒░████▓▒▒▒▒▒▒░░░▒███████▓▒▓█▓░████████░████▒█ \n ██▒██████▓█▓▒██████████████▓██▓▓▓██▓░▒▒▒▒▒░▓▓▓▓▓▓████░▒░▒▒▓░▒█████▓░███▒▓█▓ \n █▓█▓██████████▓▓█████████▓▒▒██▓▓▓████▓░░▒░░▒▒▓▓▓▒▓▒▓▓▓▒▒▒▓████▓▓▓▓███████▓▒ \n ▒▓████▓▓▒▓░░▒▓▒░░▒▒▒▓█▓▓▓▓▓███▓▒▓██████████▓▒▓▓▓▒░░██░░▓▓▒░▓██▒▒▒▒▓▒▓███▓▒▒ \n █████▓▒▒▓████████████████████████████████████████████▒▒▓▒░▒▒░▓██▓██████▓▒▒▒ \n ████▓▓▒▒▒▓█▒▒▓███▓▓▓▒▓▓▓█████████████████████████████████████████▒▒▒▒▒░░░░░ \n ░▒██████▓▓▓███████████████▒░▒▓███▓█▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒░▒▓████▓▓▓▒▒▒▒░░░░░░▒▒▒░░ \n                                                                             \n";

        imageLabel.X = Pos.Center();

        label1.Text = "Username";
        label1.X = Pos.Center();

        label2.Text = "Password";
        label2.X = Pos.Center();

        txtPassword.Secret = true;

        txtLogin.Width = Dim.Percent(30);
        txtPassword.Width = Dim.Percent(30);

        txtLogin.X = Pos.Center();
        txtPassword.X = Pos.Center();

        txtLogin.TextAlignment = TextAlignment.Centered;
        txtPassword.TextAlignment = TextAlignment.Centered;

        loginButton.Text = "Login";
        loginButton.X = Pos.Percent(30);

        registerButton.Text = "Register";
        registerButton.X = Pos.Percent(62);

        loginButton.Clicked += OnButtonClicked;
        registerButton.Clicked += OnRegisterClicked;

        Add(txtLogin, txtPassword, loginButton, registerButton, label1, label2, imageLabel);

        label1.Y = 0;
        txtLogin.Y = 1;
        label2.Y = 3;
        txtPassword.Y = 4;
        loginButton.Y = 5;
        registerButton.Y = 5;
        imageLabel.Y = 7;
    }
}