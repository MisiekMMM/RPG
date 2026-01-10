using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Terminal.Gui;

namespace RPG;

public partial class Game
{
    public Task Initialization { get; }
    public bool CanClickBuy = true;

    public Game()
    {
        Init();

        Manager.flavorLabel = lblFlavor;
        Manager.StoryLabel = lblStory;
        Manager.nextButton = nextButton;
        Manager.inventoryButtons = [item1, item2, item3, item4, item5, item6, item7, item8, itemNew];
        Manager.ShopTalkLabel = ShopTalking;

        Update();

        Initialization = Start();
    }
    public void Update()
    {
        lblName.Text = Manager.hero!.name;

        lblArmor.Text = $"Zbroja: " + (Manager.hero.armor != null ? Manager.hero.armor.name : "---");
        lblWeapon.Text = $"Broń: " + (Manager.hero.weapon != null ? Manager.hero.weapon.name : "---");

        lblHP.Text = $"HP: {Manager.hero.health}/{Manager.hero.maxHealth}";

        lblLevel.Text = $"lvl: {Manager.hero.level} exp: {Manager.hero.exp}";

        lblRaceClass.Text = $"{Manager.hero.rasa!.name} - {Manager.hero.klasa}";

        lblMoney.Text = $"{Manager.hero.money}$";

        string stats = "Statystyki:\n";

        foreach (var Key in Manager.hero.Stats)
        {
            stats += $"{Key.Key}: {Key.Value}\n";
        }

        lblStats.Text = stats;

        for (int i = 0; i < Manager.hero.inventory.Length; i++)
        {
            if (Manager.hero.inventory[i] != null)
            {
                Manager.inventoryButtons[i].Text = Manager.hero.inventory[i].name;
            }
            else
            {
                Manager.inventoryButtons[i].Text = "---";
            }
        }
    }

    async Task Start()
    {
        Statystyki stats = new();

        stats.GetStatsFromHero(Manager.hero!);

        await Utils.WriteAsync("Nigger");

        JSONReport json = new("", new(), true, new(), stats, Manager.hero!.inventory.ToList());

        while (true)
        {
            string serialized = JSONReport.Serialize(json);
            //MessageBox.Query("Bob", "the builder 2", "ok");

            string responseJson = File.ReadAllText(@"response.txt");//await AiManager.Generate(serialized);//

            Response response = Response.SetValuesFromJson(responseJson);

            await Utils.WriteAsync(response.Historia);

            Manager.hero.money += response.Money;

            if (response.Money != 0)
            {
                await Utils.WriteFlavorAsync($"Otrzymujesz {response.Money}$ [>>>]");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);
                Update();
            }

            foreach (Przedmiot przedmiot in response.Przedmioty)
            {
                Item item = przedmiot.ConvertIntoItem();

                await Utils.WriteFlavorAsync($"Otrzymujesz {item.name} [>>>]");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);

                await Manager.hero.GiveItem(item);
                Update();
            }

            if (response.Zycie < 0)
            {
                await Utils.WriteFlavorAsync($"Tracisz {response.Zycie} HP [>>>]");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);
            }
            else if (response.Zycie > 0)
            {
                await Utils.WriteFlavorAsync($"Regenerujesz {response.Zycie} HP [>>>]");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);
            }

            Manager.hero.AddHealth(response.Zycie);

            Update();

            if (response.Wybor.Opcje.Count != 0)
            {
                await Utils.WriteFlavorAsync(response.Wybor.pytanie);
                cmbWybor.Visible = true;
                cmbWybor.SetFocus();
                var source = new ObservableCollection<string>(response.Wybor.Opcje);
                cmbWybor.SetSource(source);
                cmbWybor.SelectedItem = 0;
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);

                cmbWybor.Visible = false;

                stats.GetStatsFromHero(Manager.hero!);
                json = new(cmbWybor.Text, new(), true, new(), stats, Manager.hero!.inventory.ToList());

                continue;
            }

            if (response.Sklep.Przedmioty.Count != 0)
            {
                MiddlePanel.Visible = false;
                ShopMiddlePanel.Visible = true;

                Manager.ShopList = response.Sklep.Przedmioty;

                ObservableCollection<string> itemNames = new();

                foreach (PrzedmiotSklep p in response.Sklep.Przedmioty)
                {
                    itemNames.Add(p.Przedmiot.Nazwa);
                }

                ShopItemsListView.SetSource(itemNames);

                await Utils.WriteFlavorAsync("Press [>>>] to continue with the story");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);

                MiddlePanel.Visible = true;
                ShopMiddlePanel.Visible = false;

                stats.GetStatsFromHero(Manager.hero!);
                json = new(cmbWybor.Text, new(), true, new(), stats, Manager.hero!.inventory.ToList());

                continue;
            }

            //Add battling here
            stats.GetStatsFromHero(Manager.hero!);
            json = new("", new(), true, new(), stats, Manager.hero!.inventory.ToList());

            continue;

        }
    }
    void UpdateShopItemDetails(object sender, ListViewItemEventArgs e)
    {
        PrzedmiotSklep item = Manager.ShopList[ShopItemsListView.SelectedItem];

        ItemName.Text = item.Przedmiot.Nazwa;
        ItemHP.Text = item.Przedmiot.Hp.ToString() + " HP";
        ItemDescription.Text = item.Opis;
        ItemPrice.Text = item.cena.ToString() + "$";
        ItemType.Text = item.Przedmiot.Typ;
    }
    async void OnBuyClicked(object? sender, CommandEventArgs args)
    {
        if (!CanClickBuy)
        {
            return;
        }

        CanClickBuy = false;

        PrzedmiotSklep item = Manager.ShopList[ShopItemsListView.SelectedItem];
        if (Manager.hero!.money >= item.cena)
        {
            Manager.hero.money -= item.cena;
            await Manager.hero.GiveItem(item.Przedmiot.ConvertIntoItem());

            await Utils.WriteFlavorAsync($"Zakupiłeś {item.Przedmiot.Nazwa}");

            Update();
        }
        else
        {
            await Utils.WriteFlavorAsync("Nie masz wystarczającej ilości pieniędzy");
        }

        CanClickBuy = true;
    }
}