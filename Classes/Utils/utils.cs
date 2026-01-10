using System;
using System.Data;
using Terminal.Gui;

namespace RPG;

public static class Utils
{
    public static bool WaitingForInventoryClick = false;
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
    public static async Task GeneratingLoadingAsync()
    {

        char[] loadingChars = ['⠋', '⠙', '⠹', '⠸', '⠼', '⠴', '⠦', '⠧', '⠇', '⠏'];

        while (AiManager.isGenerating)
        {
            foreach (char c in loadingChars)
            {
                Application.Invoke(() =>
                {
                    Manager.flavorLabel!.Text = c.ToString();
                });

                await Task.Delay(90);
            }
        }

        Application.Invoke(() =>
        {
            Manager.flavorLabel!.Text = "Press [>>>] to continue";
        });
    }

    public static async Task WriteAsync(string text, string restText = "", int typeRate = 10)
    {
        // text = text.Replace("\n", "");
        // text = text.Replace(Environment.NewLine, "");
        // 52x18 = 936
        Manager.nextButton!.Visible = false;

        if (text.Length > 936)
        {
            restText = text[936..];
            text = text[..936];
        }

        Manager.StoryLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.StoryLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }
        Manager.nextButton!.Visible = true;
        await WaitForButtonClickAsync(Manager.nextButton!);
        if (restText != "")
        {
            await WriteAsync(restText, "", typeRate);
        }
    }
    public static async Task WriteFlavorAsync(string text, int typeRate = 10)
    {
        Manager.flavorLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.flavorLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }
    }
    public static async Task WriteShopAsync(string text, int typeRate = 10)
    {
        Manager.ShopTalkLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.ShopTalkLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }
    }
    public static async Task<int> WaitForInventoryButtonClickAsync(bool showNew = false)
    {
        WaitingForInventoryClick = true;
        if (showNew)
        {
            Manager.inventoryButtons[8].Visible = true;
        }

        var tcs = new TaskCompletionSource<bool>();

        int buttonId = 0;

        for (int i = 0; i < Manager.inventoryButtons.Count; i++)
        {
            Button button = Manager.inventoryButtons[i];

            EventHandler<CommandEventArgs> handler = null!;
            handler = (object? sender, CommandEventArgs args) =>
            {
                button.Accepting -= handler; // poprawne zdarzenie: Accepted
                buttonId = i;
                tcs.SetResult(true);
            };

            button.Accepting += handler;
        }
        await tcs.Task;
        WaitingForInventoryClick = false;
        Manager.inventoryButtons[8].Visible = false;
        return buttonId;
    }
    public static async Task WaitForButtonClickAsync(Button button)
    {
        var tcs = new TaskCompletionSource<bool>();

        EventHandler<CommandEventArgs> handler = null!;
        handler = (object? sender, CommandEventArgs args) =>
        {
            button.CanFocus = true;
            button.HasFocus = true;
            button.SetFocus();
            button.Accepting -= handler; // poprawne zdarzenie: Accepted
            tcs.SetResult(true);
        };

        button.Accepting += handler;
        await tcs.Task;
    }

}