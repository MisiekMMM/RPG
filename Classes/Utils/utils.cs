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
        Manager.nextButton!.Visible = false;

        Manager.flavorLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.flavorLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }
        Manager.nextButton!.Visible = true;
        await WaitForButtonClickAsync(Manager.nextButton!);
    }
    public static async Task WaitForButtonClickAsync(Button button)
    {
        var tcs = new TaskCompletionSource<bool>();

        EventHandler<CommandEventArgs> handler = null!;
        handler = (object? sender, CommandEventArgs args) =>
        {
            button.Accepting -= handler; // poprawne zdarzenie: Accepted
            tcs.SetResult(true);
        };

        button.Accepting += handler;
        await tcs.Task;
    }

}