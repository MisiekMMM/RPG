using System.Drawing;
using Terminal.Gui;

namespace RPG;

public partial class Game : Window
{
    FrameView LeftPanel = new();
    FrameView MiddlePanel = new();
    FrameView DownPanel = new();
    FrameView RightPanel = new();

    FrameView ShopMiddlePanel = new();

    TabView SpellPanel = new();

    List<Tab> SpellTabs = new();
    List<Button> SpellButtons = new();

    FrameView BattleMiddlePanel = new();
    FrameView BattleDownPanel = new();

    Label lblName = new();
    Label lblLevel = new();
    Label lblMoney = new();
    Label lblRaceClass = new();
    Label lblStats = new();

    Label lblFlavor = new();

    ComboBox cmbWybor = new();
    Label lblPytanie = new();

    Label lblWeapon = new();
    Label lblArmor = new();
    Label lblHP = new();
    Label lblMana = new();

    Button item1 = new();
    Button item2 = new();
    Button item3 = new();
    Button item4 = new();
    Button item5 = new();
    Button item6 = new();
    Button item7 = new();
    Button item8 = new();
    Button itemNew = new();

    Label lblStory = new();

    Button nextButton = new();//sftyusdy

    ListView ShopItemsListView = new();
    FrameView ShopDetails = new();
    Label ShopTalking = new();

    Label ItemName = new();
    Label ItemPrice = new();
    Label ItemType = new();
    Label ItemHP = new();
    Label ItemDescription = new();
    Button BtnItemBuy = new();

    Button BtnUse = new();
    Button BtnDrop = new();
    Button BtnItemInfo = new();

    ListView EnemiesListView = new();
    FrameView EnemyDetails = new();
    Label FightStoryLabel = new();
    Label EnemyNameHp = new();
    Label EnemyDescription = new();
    Button BtnFightUse = new();
    Button BtnFightAttack = new();
    Button BtnFightSpell = new();
    Label FightFlavorLabel = new();
    Button FightNextButton = new();

    TimingAttackView FightTimingAttackView = new();
    void Init()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
        ColorScheme = Manager.ColorScheme;

        SetBorderStyle(LineStyle.None);

        LeftPanel.Width = Dim.Percent(20);
        LeftPanel.Height = Dim.Fill();
        LeftPanel.SetBorderStyle(LineStyle.Rounded);
        LeftPanel.X = Pos.Percent(0);
        LeftPanel.Y = 0;
        LeftPanel.Add(lblName, lblLevel, lblRaceClass, lblStats, lblMoney, SpellPanel);

        MiddlePanel.Width = Dim.Percent(60);
        MiddlePanel.Height = Dim.Percent(70);
        MiddlePanel.SetBorderStyle(LineStyle.Rounded);
        MiddlePanel.X = Pos.Percent(20);
        MiddlePanel.Y = Pos.Percent(0);
        MiddlePanel.Add(lblStory);

        ShopMiddlePanel.Title = "Sklep";
        ShopMiddlePanel.Width = Dim.Percent(60);
        ShopMiddlePanel.Height = Dim.Percent(70);
        ShopMiddlePanel.SetBorderStyle(LineStyle.Rounded);
        ShopMiddlePanel.X = Pos.Percent(20);
        ShopMiddlePanel.Y = Pos.Percent(0);
        ShopMiddlePanel.Visible = false;
        ShopMiddlePanel.Add(ShopItemsListView, ShopDetails, ShopTalking);

        ShopItemsListView.Title = "Przedmioty";
        ShopItemsListView.X = 0;
        ShopItemsListView.Y = Pos.Percent(50);
        ShopItemsListView.Width = Dim.Percent(30);
        ShopItemsListView.Height = Dim.Percent(50);
        ShopItemsListView.AllowsMarking = false;
        ShopItemsListView.AllowsMultipleSelection = false;
        ShopItemsListView.BorderStyle = LineStyle.Dotted;
        ShopItemsListView.Arrangement = ViewArrangement.Fixed;
        ShopItemsListView.VerticalScrollBar.AutoShow = true;
        ShopItemsListView.SelectedItemChanged += UpdateShopItemDetails;
        //ShopLabel.Text = "12312\n12312\n12312\n12312\n12312\n12312\n1231212312\n12312\n12312\n12312\n12312\n12312\n1231212312\n12312\n12312\n12312\n12312\n12312\n12312";

        ShopDetails.Width = Dim.Percent(70);
        ShopDetails.Height = Dim.Percent(50);
        ShopDetails.Title = "Informacje";
        ShopDetails.X = Pos.Percent(30);
        ShopDetails.Y = Pos.Percent(50);
        ShopDetails.Add(ItemPrice, ItemHP, ItemName, ItemType, ItemDescription, BtnItemBuy);

        ItemName.X = 0;
        ItemName.Y = 0;
        ItemName.Text = "--";
        ItemName.Height = 2;
        ItemName.Width = Dim.Percent(50);

        ItemType.X = 0;
        ItemType.Y = Pos.Bottom(ItemName);
        ItemType.Text = "--";
        ItemType.Height = 2;
        ItemType.Width = Dim.Fill(50);

        ItemPrice.X = 0;
        ItemPrice.Y = Pos.Bottom(ItemType);
        ItemPrice.Text = "--$";
        ItemPrice.Height = 2;
        ItemPrice.Width = Dim.Percent(50);

        ItemHP.X = 0;
        ItemHP.Y = Pos.Bottom(ItemPrice);
        ItemHP.Text = "-- HP";

        ItemDescription.X = Pos.Right(ItemName);
        ItemDescription.Y = 0;
        ItemDescription.Text = "--";
        ItemDescription.Width = Dim.Percent(50);
        ItemDescription.Height = Dim.Fill(1);

        BtnItemBuy.Text = "Buy";
        BtnItemBuy.X = Pos.Percent(75);
        BtnItemBuy.Y = Pos.Bottom(ItemDescription);
        BtnItemBuy.Accepting += OnBuyClicked;

        ShopTalking.X = Pos.Center();
        ShopTalking.Y = Pos.Percent(10);
        ShopTalking.Width = Dim.Percent(75);
        ShopTalking.Height = Dim.Percent(40);
        ShopTalking.TextAlignment = Alignment.Center;
        ShopTalking.Text = "Witaj w sklepie!";

        lblStory.X = Pos.Center();
        lblStory.Y = Pos.Percent(10);
        lblStory.Width = Dim.Percent(75);
        lblStory.Height = Dim.Fill();
        lblStory.Text = "Press [>>>] to continue with the story";
        lblStory.TextAlignment = Alignment.Center;

        DownPanel.Width = Dim.Percent(60);
        DownPanel.Height = Dim.Percent(30);
        DownPanel.SetBorderStyle(LineStyle.Rounded);
        DownPanel.X = Pos.Percent(20);
        DownPanel.Y = Pos.Percent(70);
        DownPanel.Add(cmbWybor, lblFlavor, nextButton, BtnDrop, BtnItemInfo, BtnUse);

        RightPanel.Width = Dim.Percent(20);
        RightPanel.Height = Dim.Fill();
        RightPanel.SetBorderStyle(LineStyle.Rounded);
        RightPanel.X = Pos.Percent(80);
        RightPanel.Y = Pos.Percent(0);
        RightPanel.Add(lblArmor, lblWeapon, item1, item2, item3, item4, item5, item6, item7, item8, itemNew, lblHP, lblMana);

        lblName.X = Pos.Center();
        lblName.Y = 0;
        lblName.Text = "Name";

        lblLevel.X = Pos.Center();
        lblLevel.Y = Pos.Bottom(lblName);
        lblLevel.Text = "Level";

        lblMoney.X = Pos.Center();
        lblMoney.Y = Pos.Bottom(lblRaceClass);
        lblMoney.Text = "0 $";

        lblRaceClass.X = Pos.Center();
        lblRaceClass.Y = Pos.Bottom(lblLevel);
        lblRaceClass.Text = "Rasa - Klasa";

        lblStats.X = Pos.Center();
        lblStats.Y = Pos.Bottom(lblMoney);
        lblStats.Height = 14;
        lblStats.Text = "Statystyki:\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----";

        SpellPanel.Width = Dim.Fill();
        SpellPanel.Height = Dim.Fill();//Dim.Percent(40);
        SpellPanel.X = 0;
        SpellPanel.Y = Pos.Bottom(lblStats);
        SpellPanel.BorderStyle = LineStyle.Double;
        SpellPanel.Title = "Spells";


        lblFlavor.Width = Dim.Fill();
        lblFlavor.Height = 2;
        lblFlavor.X = 0;
        lblFlavor.Y = 0;
        lblFlavor.Text = "Press [>>>] to continue with the story";

        BtnUse.Text = "Użyj";
        BtnUse.Y = Pos.Bottom(lblFlavor);
        BtnUse.X = Pos.Percent(25);
        BtnUse.Visible = false;

        BtnDrop.Text = "Upuść";
        BtnDrop.Y = Pos.Bottom(lblFlavor);
        BtnDrop.X = Pos.Percent(50);
        BtnDrop.Visible = false;

        BtnItemInfo.Text = "Info";
        BtnItemInfo.Y = Pos.Bottom(lblFlavor);
        BtnItemInfo.X = Pos.Percent(75);
        BtnItemInfo.Visible = false;

        cmbWybor.Y = Pos.Bottom(lblFlavor);
        cmbWybor.X = Pos.Center();
        cmbWybor.Visible = false;
        cmbWybor.Width = Dim.Percent(50);
        cmbWybor.Height = 4;
        cmbWybor.TextAlignment = Alignment.Center;
        cmbWybor.ReadOnly = true;

        nextButton.X = Pos.Center();
        nextButton.Y = Pos.Percent(100) - 1;
        nextButton.Text = ">>>";

        lblWeapon.X = Pos.Center();
        lblWeapon.Y = Pos.Percent(10);
        lblWeapon.Text = "Bron:";

        lblArmor.X = Pos.Center();
        lblArmor.Y = Pos.Bottom(lblWeapon);
        lblArmor.Text = "Zbroja:";

        item1.X = Pos.Center();
        item2.X = Pos.Center();
        item3.X = Pos.Center();
        item4.X = Pos.Center();
        item5.X = Pos.Center();
        item6.X = Pos.Center();
        item7.X = Pos.Center();
        item8.X = Pos.Center();
        itemNew.X = Pos.Center();

        item1.Y = Pos.Bottom(lblArmor) + 3;
        item2.Y = Pos.Bottom(item1);
        item3.Y = Pos.Bottom(item2);
        item4.Y = Pos.Bottom(item3);
        item5.Y = Pos.Bottom(item4);
        item6.Y = Pos.Bottom(item5);
        item7.Y = Pos.Bottom(item6);
        item8.Y = Pos.Bottom(item7);
        itemNew.Y = Pos.Bottom(item8) + 1;

        item1.Text = "---";
        item2.Text = "---";
        item3.Text = "---";
        item4.Text = "---";
        item5.Text = "---";
        item6.Text = "---";
        item7.Text = "---";
        item8.Text = "---";
        itemNew.Text = "---";

        itemNew.Visible = false;

        lblHP.X = Pos.Center();
        lblHP.Y = Pos.Bottom(item8) + 3;
        lblHP.Text = "HP: 100/100";

        lblMana.X = Pos.Center();
        lblMana.Y = Pos.Top(lblHP) - 2;
        lblMana.Text = "Mana: 20/20";

        BattleMiddlePanel.Width = Dim.Percent(60);
        BattleMiddlePanel.Height = Dim.Percent(70);
        BattleMiddlePanel.SetBorderStyle(LineStyle.Rounded);
        BattleMiddlePanel.X = Pos.Percent(20);
        BattleMiddlePanel.Y = Pos.Percent(0);
        BattleMiddlePanel.Add(EnemiesListView, EnemyDetails, FightStoryLabel);

        BattleMiddlePanel.Visible = false;

        BattleDownPanel.Width = Dim.Percent(60);
        BattleDownPanel.Height = Dim.Percent(30);
        BattleDownPanel.SetBorderStyle(LineStyle.Rounded);
        BattleDownPanel.X = Pos.Percent(20);
        BattleDownPanel.Y = Pos.Percent(70);
        BattleDownPanel.Add(BtnFightAttack, BtnFightSpell, BtnFightUse, FightFlavorLabel, FightTimingAttackView, FightNextButton);

        BattleDownPanel.Visible = false;

        FightTimingAttackView.Visible = false;
        FightTimingAttackView.X = Pos.Center();
        FightTimingAttackView.Y = 0;
        FightTimingAttackView.Width = Dim.Fill();
        FightTimingAttackView.Height = Dim.Fill();

        FightFlavorLabel.Width = Dim.Fill();
        FightFlavorLabel.Height = Dim.Fill(3);
        FightFlavorLabel.X = 0;
        FightFlavorLabel.Y = 0;
        FightFlavorLabel.Text = "Wybierz czynność:";

        BtnFightAttack.Text = "Atak";
        BtnFightAttack.Y = Pos.Bottom(FightFlavorLabel);
        BtnFightAttack.X = Pos.Percent(25);

        BtnFightSpell.Text = "Zaklęcie";
        BtnFightSpell.Y = Pos.Bottom(FightFlavorLabel);
        BtnFightSpell.X = Pos.Percent(50);

        BtnFightUse.Text = "Przedmiot";
        BtnFightUse.Y = Pos.Bottom(FightFlavorLabel);
        BtnFightUse.X = Pos.Percent(75);

        FightNextButton.X = Pos.Center();
        FightNextButton.Y = Pos.Percent(100) - 1;
        FightNextButton.Text = ">>>";
        FightNextButton.Visible = false;

        EnemiesListView.Title = "Przeciwnicy";
        EnemiesListView.X = 0;
        EnemiesListView.Y = Pos.Percent(50);
        EnemiesListView.Width = Dim.Percent(30);
        EnemiesListView.Height = Dim.Percent(50);
        EnemiesListView.AllowsMarking = false;
        EnemiesListView.AllowsMultipleSelection = false;
        EnemiesListView.BorderStyle = LineStyle.Dotted;
        EnemiesListView.Arrangement = ViewArrangement.Fixed;
        EnemiesListView.VerticalScrollBar.AutoShow = true;
        EnemiesListView.SelectedItemChanged += UpdateEnemyDetails;

        EnemyDetails.Width = Dim.Percent(70);
        EnemyDetails.Height = Dim.Percent(50);
        EnemyDetails.Title = "Informacje";
        EnemyDetails.X = Pos.Percent(30);
        EnemyDetails.Y = Pos.Percent(50);
        EnemyDetails.Add(EnemyNameHp, EnemyDescription);

        EnemyNameHp.Width = Dim.Fill();
        EnemyNameHp.Height = Dim.Percent(25);
        EnemyNameHp.X = 0;
        EnemyNameHp.Y = 0;

        EnemyDescription.Width = Dim.Fill();
        EnemyDescription.Height = Dim.Percent(75);
        EnemyDescription.X = 0;
        EnemyDescription.Y = Pos.Bottom(EnemyNameHp);

        Add(LeftPanel, MiddlePanel, DownPanel, RightPanel, ShopMiddlePanel, BattleDownPanel, BattleMiddlePanel);
    }

    private Label CreateLabel(string txt)
    {
        return new Label
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            X = Pos.Center(),
            Y = Pos.Center(),
            Text = txt
        };
    }
}