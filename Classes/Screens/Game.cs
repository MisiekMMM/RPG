using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RPG;

public partial class Game
{
    public Task Initialization { get; }
    public bool CanClickBuy = true;
    public List<Item> UzytePrzedmioty = new();
    public List<Item> ZakupionePrzedmioty = new();

    int CurrentlyCheckedEnemy = 0;

    public Game()
    {
        Init();

        Manager.flavorLabel = lblFlavor;
        Manager.StoryLabel = lblStory;
        Manager.nextButton = nextButton;
        Manager.inventoryButtons = [item1, item2, item3, item4, item5, item6, item7, item8, itemNew];
        Manager.ShopTalkLabel = ShopTalking;
        Manager.FightFlavorLabel = FightFlavorLabel;
        Manager.FightNextButton = FightNextButton;

        Update();

        Initialization = Start();
    }
    public void Update()
    {
        lblName.Text = Manager.hero!.name;

        lblArmor.Text = $"Zbroja: " + (Manager.hero.armor != null ? $"{Manager.hero.armor.Nazwa} ({Manager.hero.armor!.Hp})" : "---");
        lblWeapon.Text = $"Broń: " + (Manager.hero.weapon != null ? $"{Manager.hero.weapon.Nazwa} ({Manager.hero.weapon!.Hp})" : "---");

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
                Manager.inventoryButtons[i].Text = Manager.hero.inventory[i].Nazwa;
            }
            else
            {
                Manager.inventoryButtons[i].Text = "---";
            }
        }

        if (CurrentlyCheckedEnemy < Manager.EnemyList.Count && Manager.EnemyList[CurrentlyCheckedEnemy] != null)
        {
            EnemyNameHp.Text = $"{Manager.EnemyList[CurrentlyCheckedEnemy].Nazwa} - {Manager.EnemyList[CurrentlyCheckedEnemy].EnemyElement} - {Manager.EnemyList[CurrentlyCheckedEnemy].Hp}";
            EnemyDescription.Text = Manager.EnemyList[CurrentlyCheckedEnemy].Opis;
        }
    }
    async Task Start()
    {
        GenerateNewSpellTab();
        GenerateNewSpellTab();
        GenerateNewSpellTab();

        await GiveStarterKit();

        Statystyki stats = new();

        stats.GetStatsFromHero(Manager.hero!);

        await Utils.WriteAsync("OH MY GOD I AM SO SORRY IT WAS JUST A JOKE I AM NOT RACIST");  // Just realised my test message used the n-word

        await StartBattle();

        await Utils.WriteAsync("Test123");


        JSONReport json = new("", UzytePrzedmioty, true, ZakupionePrzedmioty, stats, Manager.hero!.inventory.ToList());

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

            foreach (Item przedmiot in response.Przedmioty)
            {
                await Utils.WriteFlavorAsync($"Otrzymujesz {przedmiot.Nazwa} [>>>]");
                await Utils.WaitForButtonClickAsync(Manager.nextButton!);

                await Manager.hero.GiveItem(przedmiot);
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

                await ShowItemUsageButtons();

                stats.GetStatsFromHero(Manager.hero!);
                json = new(cmbWybor.Text, UzytePrzedmioty, true, ZakupionePrzedmioty, stats, Manager.hero!.inventory.ToList());

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

                await ShowItemUsageButtons();

                stats.GetStatsFromHero(Manager.hero!);
                json = new(cmbWybor.Text, UzytePrzedmioty, true, ZakupionePrzedmioty, stats, Manager.hero!.inventory.ToList());



                continue;
            }

            //Add battling here

            await Utils.WriteFlavorAsync("Press [>>>] to continue with the story");
            await ShowItemUsageButtons();

            stats.GetStatsFromHero(Manager.hero!);
            json = new("", UzytePrzedmioty, true, ZakupionePrzedmioty, stats, Manager.hero!.inventory.ToList());


            continue;

        }
    }
    async Task ShowItemUsageButtons()
    {
        BtnDrop.Visible = true;
        BtnItemInfo.Visible = true;
        BtnUse.Visible = true;

        EventHandler<CommandEventArgs> InfoHandler =
        async (object? sender, CommandEventArgs args) =>
        {
            nextButton.Visible = false;

            await Utils.WriteFlavorAsync("Wybierz przedmiot, który chcesz sprawdzić.");

            int buttonID = await Utils.WaitForInventoryButtonClickAsync();

            if (Manager.hero!.inventory[buttonID] != null)
            {
                BtnDrop.Visible = false;
                BtnItemInfo.Visible = false;
                BtnUse.Visible = false;

                Item item = Manager.hero!.inventory[buttonID]; // "przedmiot", "zbroja", "bron"
                if (Manager.hero!.inventory[buttonID].Typ == "bron")
                    await Utils.WriteFlavorAsync($"{item.Nazwa}: Broń atk:{item.Hp}");
                else if (Manager.hero!.inventory[buttonID].Typ == "zbroja")
                    await Utils.WriteFlavorAsync($"{item.Nazwa}: Zbroja def:{item.Hp}");
                else if (item.Hp != 0)
                    await Utils.WriteFlavorAsync($"{item.Nazwa}: Item HP:{item.Hp}");
                else
                    await Utils.WriteFlavorAsync($"{item.Nazwa}: Item");

                BtnDrop.Visible = true;
                BtnItemInfo.Visible = true;
                BtnUse.Visible = true;
            }

            nextButton.Visible = true;
        };

        EventHandler<CommandEventArgs> DropHandler =
        async (object? sender, CommandEventArgs args) =>
        {
            BtnDrop.Visible = false;
            BtnItemInfo.Visible = false;
            BtnUse.Visible = false;
            nextButton.Visible = false;

            await Utils.WriteFlavorAsync("Wybierz przedmiot, który chcesz wyrzucić.");

            int buttonID = await Utils.WaitForInventoryButtonClickAsync();

            if (Manager.hero!.inventory[buttonID] != null)
            {
                await Utils.WriteFlavorAsync($"Wyrzucasz {Manager.hero!.inventory[buttonID].Nazwa}");

                Manager.hero!.inventory[buttonID] = null!;

                Update();
            }

            nextButton.Visible = true;
            BtnDrop.Visible = true;
            BtnItemInfo.Visible = true;
            BtnUse.Visible = true;
        };


        EventHandler<CommandEventArgs> UseHandler =
        async (object? sender, CommandEventArgs args) =>
        {
            BtnDrop.Visible = false;
            BtnItemInfo.Visible = false;
            BtnUse.Visible = false;
            nextButton.Visible = false;

            await Utils.WriteFlavorAsync("Wybierz przedmiot, który chcesz użyć.");

            int buttonID = await Utils.WaitForInventoryButtonClickAsync();

            if (Manager.hero!.inventory[buttonID] != null)
            {
                await Utils.WriteFlavorAsync($"Używasz {Manager.hero!.inventory[buttonID].Nazwa}");
            }

            UzytePrzedmioty.Add(Manager.hero!.inventory[buttonID]);

            await Manager.hero!.UseItem(Manager.hero!.inventory[buttonID], buttonID);

            Update();

            nextButton.Visible = true;
            BtnDrop.Visible = true;
            BtnItemInfo.Visible = true;
            BtnUse.Visible = true;
        };


        BtnUse.Accepting += UseHandler;
        BtnDrop.Accepting += DropHandler;
        BtnItemInfo.Accepting += InfoHandler;

        await Utils.WaitForButtonClickAsync(nextButton);

        BtnDrop.Visible = false;
        BtnItemInfo.Visible = false;
        BtnUse.Visible = false;
    }

    void GenerateNewSpellTab()
    {
        // Determine the new tab number
        int number = SpellTabs.Count + 1;

        // Create a new Tab
        Tab newTab = new Tab
        {
            DisplayText = number.ToString()
        };

        // Create the main View for this tab
        View view = new View
        {
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        // Button layout settings
        int buttonCount = 4;
        int buttonHeight = 2; // Fixed height in terminal rows
        int buttonSpacing = 0; // Space between buttons

        for (int i = 0; i < buttonCount; i++)
        {
            Button newButton = new Button()
            {
                Text = "---",
                X = 0, // start at left
                Width = Dim.Fill(), // fill horizontally
                Height = buttonHeight,
                Y = i * (buttonHeight + buttonSpacing) // stack vertically
            };

            EventHandler<CommandEventArgs> handler =
            async (object? sender, CommandEventArgs args) =>
            {
                MessageBox.Query("a", $"{Console.WindowWidth} {Console.WindowHeight}", "ok");
            };

            newButton.Accepting += handler;

            // Optional debug message to check position
            // MessageBox.Query("Debug", $"Button {i}: Y={newButton.Y}, Height={newButton.Height}", "OK");

            SpellButtons.Add(newButton);
            view.Add(newButton);
        }

        // Assign the view to the tab
        newTab.View = view;

        // Add the new tab to the tab list
        SpellTabs.Add(newTab);

        // Add the tab to the TabView
        SpellPanel.AddTab(newTab, true);
    }


    async Task StartBattle()
    {
        Manager.EnemyList = [
            new(){
            Nazwa = "Wolf",
            Hp = 150,
            Opis = "He's the alpha, he's the leader. I dunno but i think he's the one to trust.",
            EnemyElement = Element.Earth,
            Ataki = [
                    new(){
                        Nazwa = "Wilcze majty",
                        AttackElement = Element.Dark,
                        attackType = AttackType.Physical,
                        MinStrength = 2,
                        MaxStrength = 1000
                    }
            ]
        },
new(){
            Nazwa = "Ligma",
            Hp = 3,
            Opis = "Who's Ligma?",
            EnemyElement = Element.Earth,
            Ataki = [
                    new(){
                        Nazwa = "This potion",
                        AttackElement = Element.Dark,
                        attackType = AttackType.Magic,
                        MinStrength = 2,
                        MaxStrength = 50
                    }
            ]
        }
        ];

        ObservableCollection<string> src = new();

        foreach (Enemy przeciwnik in Manager.EnemyList)
        {
            src.Add(przeciwnik.Nazwa);
        }

        EnemiesListView.SetSource<string>(src);

        MiddlePanel.Visible = false;
        DownPanel.Visible = false;

        BattleDownPanel.Visible = true;
        BattleMiddlePanel.Visible = true;

        _ = Utils.WriteFightAsync("Placeholder text");

        //MessageBox.ErrorQuery("2", "2", "2");

        while (CheckEnemiesStillLive(Manager.EnemyList))
        {
            BtnFightAttack.Visible = true;
            BtnFightSpell.Visible = true;
            BtnFightUse.Visible = true;

            List<Button> btns = [BtnFightAttack, BtnFightSpell, BtnFightUse];

            int ButtonClicked = await Utils.WaitForFightButtonAsync(btns);

            BtnFightAttack.Visible = false;
            BtnFightSpell.Visible = false;
            BtnFightUse.Visible = false;

            if (ButtonClicked == 0)
            {
                //MessageBox.Query("OOOooooo", "Do i even start? Who knows! OOOOoooo", "Omg such a scary pop up");

                BattleDownPanel.SetFocus();
                BattleDownPanel.CanFocus = true;

                FightTimingAttackView.SetFocus();
                FightTimingAttackView.CanFocus = true;

                FightTimingAttackView.Visible = true;
                FightTimingAttackView.Restart();

                EnemiesListView.SelectedItemChanged -= UpdateEnemyDetails!;

                await FightTimingAttackView.tcs.Task;

                FightTimingAttackView.Visible = false;

                EnemiesListView.SelectedItemChanged += UpdateEnemyDetails!;

                float AttackStrength = FightTimingAttackView.AttackStrength;

                bool DidKill = Manager.EnemyList[CurrentlyCheckedEnemy].ChangeHealthAndCheckKill((int)(-AttackStrength * Manager.hero!.Stats["strength"]), AttackType.Physical, Element.None);

                await Utils.WriteFightFlavorAsync($"Obrażenia wynoszą {(int)(AttackStrength * Manager.hero!.Stats["strength"])} HP", true);

                //MessageBox.Query("", "123", "abc");

                if (DidKill)
                {
                    Manager.EnemyList.RemoveAt(CurrentlyCheckedEnemy);
                    CurrentlyCheckedEnemy = 0;
                }
            }
            else if (ButtonClicked == 1)
            {

            }
            else if (ButtonClicked == 2)
            {
                await Utils.WriteFightFlavorAsync("Wybierz przedmiot, który chcesz użyć.");

                int buttonID = await Utils.WaitForInventoryButtonClickAsync();

                if (Manager.hero!.inventory[buttonID] != null)
                {
                    await Utils.WriteFightFlavorAsync($"Używasz {Manager.hero!.inventory[buttonID].Nazwa}", true);
                }

                UzytePrzedmioty.Add(Manager.hero!.inventory[buttonID]);

                await Manager.hero!.UseItem(Manager.hero!.inventory[buttonID], buttonID);
            }
            else
            {
                MessageBox.Query("Error", "Error", "LEave");
                Environment.Exit(1);
            }


            UpdateEnemySource();
            Update();

            await EnemyTurn();

            Update();

            BtnFightAttack.Visible = true;
            BtnFightSpell.Visible = true;
            BtnFightUse.Visible = true;
        }
    }
    async Task EnemyTurn()
    {
        Random random = new();

        int EnemyIndex = random.Next(Manager.EnemyList.Count);

        Attack atak = Manager.EnemyList[EnemyIndex].CastAttack();

        int AttackStrength = atak.GetAttackStrength();

        await Utils.WriteFightFlavorAsync($"{Manager.EnemyList[EnemyIndex].Nazwa} używa {atak.Nazwa}!", true);
        //await Utils.WriteFightFlavorAsync($"MOC ATAKU: {AttackStrength} (DELETE lATER)", true);

        switch (atak.attackType)
        {
            case AttackType.Healing:
                Manager.EnemyList[EnemyIndex].ChangeHealthAndCheckKill(AttackStrength, AttackType.Healing, Element.None);
                await Utils.WriteFightFlavorAsync($"{Manager.EnemyList[EnemyIndex].Nazwa} uzdrawia {AttackStrength} HP!", true);
                break;
            case AttackType.Physical or AttackType.Magic:
                AttackStrength = AttackStrength - AttackStrength * Manager.hero!.Stats["defence"] / 100;

                if (AttackStrength < 0)
                {
                    AttackStrength = 1;
                }

                Manager.hero!.AddHealth(-AttackStrength);
                await Utils.WriteFightFlavorAsync($"Obrażenia wynoszą {AttackStrength} HP!", true);
                break;
        }
    }
    void UpdateEnemySource()
    {
        ObservableCollection<string> src = new();

        foreach (Enemy przeciwnik in Manager.EnemyList)
        {
            src.Add(przeciwnik.Nazwa);
        }

        EnemiesListView.SetSource<string>(src);
    }

    bool CheckEnemiesStillLive(List<Enemy> Enemies)
    {
        return Enemies.Any(przeciwnik => przeciwnik.Hp != 0);
    }

    void UpdateEnemyDetails(object sender, ListViewItemEventArgs e)
    {
        CurrentlyCheckedEnemy = EnemiesListView.SelectedItem;

        Update();
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

        ZakupionePrzedmioty.Add(item.Przedmiot);

        if (Manager.hero!.money >= item.cena)
        {
            Manager.hero.money -= item.cena;
            await Manager.hero.GiveItem(item.Przedmiot);

            await Utils.WriteFlavorAsync($"Zakupiłeś {item.Przedmiot.Nazwa}");

            Update();
        }
        else
        {
            await Utils.WriteFlavorAsync("Nie masz wystarczającej ilości pieniędzy");
        }

        CanClickBuy = true;
    }

    async Task GiveStarterKit()
    {
        //Wojownik
        Item StalowyMiecz = new("bron", "Stalowy Miecz", 20);

        Item ZbrojaKolczatka = new("zbroja", "Zbroja Kolczatka", 20);

        //Mag

        //Tu wstawić 2 zaklęcia


        //Mnich

        Item MagicznaPeleryna = new("zbroja", "Magiczna Peleryna", 10);

        //Jedno zaklecie

        if (Manager.hero!.klasa == "Wojownik")
        {
            Manager.hero!.inventory = [StalowyMiecz, ZbrojaKolczatka];
        }
        else if (Manager.hero!.klasa == "Mag")
        {
            //Tutaj zaklęcia
        }
        else if (Manager.hero!.klasa == "Mnich")
        {
            Manager.hero!.inventory = [MagicznaPeleryna];
            // Zaklęcie
        }
    }
}