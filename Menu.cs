using System.ComponentModel;
using System.Security.AccessControl;
using Terminal.Gui;

namespace RPG;

public partial class Menu
{
    string username;
    public Menu(string Username)
    {
        Init();
        username = Username;
    }

    void OnButtonClicked(object s, CancelEventArgs e)
    {
        string[] options = { "Hello", "???", "Ass", "Joe", "Mumma", "Maciek Pierdzioch", username };

        int o = MessageBox.Query("Dupa", $"Hello {username}!", options);

        if (o != -1)
            MessageBox.Query(options[o], options[o], options[o]);
        else
            MessageBox.Query("Escape", "Escape", "Escape");
    }
}

