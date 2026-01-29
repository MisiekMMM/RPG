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
        LeftPanel.Add(lblName, lblLevel, lblRaceClass, lblStats, lblMoney);

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
        RightPanel.Add(lblArmor, lblWeapon, item1, item2, item3, item4, item5, item6, item7, item8, itemNew, lblHP);

        lblName.X = Pos.Center();
        lblName.Y = Pos.Percent(10);
        lblName.Text = "Name";

        lblLevel.X = Pos.Center();
        lblLevel.Y = Pos.Percent(13);
        lblLevel.Text = "Level";

        lblMoney.X = Pos.Center();
        lblMoney.Y = Pos.Bottom(lblRaceClass);
        lblMoney.Text = "0 $";

        lblRaceClass.X = Pos.Center();
        lblRaceClass.Y = Pos.Percent(16);
        lblRaceClass.Text = "Rasa - Klasa";

        lblStats.X = Pos.Center();
        lblStats.Y = Pos.Bottom(lblRaceClass) + 3;
        lblStats.Height = 14;
        lblStats.Text = "Statystyki:\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----\n--:----";

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

        Add(LeftPanel, MiddlePanel, DownPanel, RightPanel, ShopMiddlePanel);
    }
}