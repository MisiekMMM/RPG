using System;
using System.Data;
using Terminal.Gui;

namespace RPG;

public static class Utils
{
    public static void Wyczysc()
    {
        Console.Clear();
    }
    public static bool IsAnyNull(object[] table)
    {
        foreach (object o in table)
        {
            if (o == null)
            {
                return true;
            }
        }
        return false;
    }
    public static int FindLastIndex(object[] table)
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    public static async Task WriteAsync(string text, int typeRate = 10)
    {
        Manager.flavorLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.flavorLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread

        }
    }
    private static void WaitForKeyPress(Action? onKeyPressed = null)
    {
        var keyHandler = new Window()
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            Visible = false // Invisible key catcher
        };

        keyHandler.KeyDown += (object? s, Key key) =>
        {
            Application.RequestStop(); // stop the modal window
            onKeyPressed?.Invoke();    // do something after key is pressed
        };

        Application.Run(keyHandler); // blocks until a key is pressed
    }

}