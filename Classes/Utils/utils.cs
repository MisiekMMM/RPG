using System;
using System.Data;
using System.Reflection.Metadata;
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
    public static async Task WriteFightFlavorAsync(string text, bool waitForClick = false, int typeRate = 10)
    {
        Manager.FightFlavorLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.FightFlavorLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }

        //MessageBox.Query("1", "1", "1");

        if (waitForClick)
        {
            Manager.FightNextButton.Visible = true;
            Manager.FightNextButton.SetFocus();
            //MessageBox.Query("2", "2", "2");

            Manager.FightNextButton.Visible = true;

            await WaitForButtonClickAsync(Manager.FightNextButton);
            //MessageBox.Query("4", "4", "4");
        }
        //MessageBox.Query("3", "3", "3");
        Manager.FightNextButton.Visible = false;
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
    public static async Task WriteFightAsync(string text, int typeRate = 10)
    {
        Manager.FightStoryLabel!.Text = "";
        foreach (char c in text)
        {
            Manager.FightStoryLabel!.Text += c;
            await Task.Delay(typeRate); // Waits 1 second without blocking the thread
        }
    }
    public static async Task<int> WaitForInventoryButtonClickAsync(bool showNew = false)
    {
        WaitingForInventoryClick = true;

        if (showNew)
            Manager.inventoryButtons[8].Visible = true;

        var tcs = new TaskCompletionSource<int>();

        for (int i = 0; i < Manager.inventoryButtons.Count; i++)
        {
            int index = i; // 🔑 kluczowe

            Button button = Manager.inventoryButtons[index];

            EventHandler<CommandEventArgs>? handler = null;
            handler = (sender, args) =>
            {
                // odpinamy WSZYSTKIE handlery
                foreach (var b in Manager.inventoryButtons)
                    b.Accepting -= handler;

                tcs.TrySetResult(index);
            };

            button.Accepting += handler;
        }

        int result = await tcs.Task;

        WaitingForInventoryClick = false;
        Manager.inventoryButtons[8].Visible = false;

        return result;
    }
    public static async Task<int> WaitForFightButtonAsync(List<Button> buttons)
    {
        var tcs = new TaskCompletionSource<int>();

        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i; // 🔑 kluczowe

            Button button = buttons[index];

            EventHandler<CommandEventArgs>? handler = null;
            handler = (sender, args) =>
            {
                // odpinamy WSZYSTKIE handlery
                foreach (var b in buttons)
                    b.Accepting -= handler;

                tcs.TrySetResult(index);
            };

            button.Accepting += handler;
        }

        int result = await tcs.Task;

        return result;
    }
    public static async Task WaitForButtonClickAsync(Button button)
    {
        var tcs = new TaskCompletionSource<bool>();

        button.CanFocus = true;
        button.SetFocus();
        button.Visible = true;

        EventHandler<CommandEventArgs> handler = null!;
        handler = (object? sender, CommandEventArgs args) =>
        {
            //`MessageBox.Query("6", "6", "6");
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