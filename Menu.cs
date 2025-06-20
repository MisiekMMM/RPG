using System.ComponentModel;
using System.Security.AccessControl;
using Terminal.Gui;

namespace RPG;

public partial class Menu
{

    public Menu()
    {
        Init();
    }

    void OnButtonClicked(object s, CancelEventArgs e)
    {
        OpenDialog openDialog = new();

        Application.Run(openDialog);

        IReadOnlyList<string> paths = openDialog.FilePaths;

        MessageBox.Query("Dupa", paths[0], "Ok");
    }
}

