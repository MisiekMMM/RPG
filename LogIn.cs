using System.ComponentModel;
using System.Security.AccessControl;
using Terminal.Gui;

namespace RPG;


public partial class Login
{
    public Login()
    {
        Init();
    }
    void OnRegisterClicked()
    {
        string login = txtLogin.Text.ToString()!;
        string password = txtPassword.Text.ToString()!;
        if (!string.IsNullOrWhiteSpace(login.ToString()) && !string.IsNullOrWhiteSpace(password.ToString()))
        {
            if (!GetUserBase(Path.Combine(Environment.CurrentDirectory, @"users.txt"), Path.Combine(Environment.CurrentDirectory, @"passwords.txt")).ContainsKey(login.ToString()!))
            {
                AddUser(login.ToString()!, Hasher.ComputeSha256(password.ToString()!), Path.Combine(Environment.CurrentDirectory, @"users.txt"), Path.Combine(Environment.CurrentDirectory, @"passwords.txt"));
                MessageBox.Query("☺", "Utworzono użytkownika!", "Ok");

                Manager.login = login.ToString()!;
                Application.RequestStop();
            }
            else
            {
                MessageBox.Query("Nie zarejestrowano!", "Użytkownik o podanej nazwie już istnieje!", "Ok");
                txtLogin.Text = "";
            }
        }
        else
        {
            MessageBox.Query("Nie zarejestrowano!", "Nie wpisano loginu lub hasła.", "Ok");
        }
    }
    void OnButtonClicked()
    {
        string login = txtLogin.Text.ToString()!;
        string password = txtPassword.Text.ToString()!;

        Dictionary<string, string> database = GetUserBase(Path.Combine(Environment.CurrentDirectory, @"users.txt"), Path.Combine(Environment.CurrentDirectory, @"passwords.txt"));

        if (!string.IsNullOrWhiteSpace(login.ToString()) && !string.IsNullOrWhiteSpace(password.ToString()))
        {
            if (database.ContainsKey(login.ToString()!) && database[login.ToString()!] == Hasher.ComputeSha256(password.ToString()!))
            {
                MessageBox.Query("Ok", "Zalogowano pomyślnie", "Ok");

                Manager.login = login.ToString()!;
                Application.RequestStop();
            }
            else
            {
                MessageBox.Query("Błąd", "Błędny login lub hasło", "Ok");
                txtPassword.Text = "";
            }
        }
        else
        {
            MessageBox.Query("Nie zalogowano!", "Nie wpisano loginu lub hasła.", "Ok");
        }
    }
    Dictionary<string, string> GetUserBase(string users, string passwords)
    {
        Dictionary<string, string> database = [];

        string[] usersFileContents = File.ReadAllLines(users);
        string[] passwordsFileContents = File.ReadAllLines(passwords);

        for (int i = 0; i < usersFileContents.Length; i++)
        {
            database.Add(usersFileContents[i], passwordsFileContents[i]);
        }

        return database;
    }
    void AddUser(string login, string password, string users, string passwords)
    {
        File.AppendAllText(users, login + "\n");
        File.AppendAllText(passwords, password + "\n");
    }

}