using System.Runtime.InteropServices.JavaScript;
using Terminal.Gui;

namespace RPG;

public partial class Game
{
    public Task Initialization { get; }

    public Game()
    {
        Init();

        Manager.flavorLabel = lblFlavor;
        Manager.StoryLabel = lblStory;
        Manager.nextButton = nextButton;

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

        string stats = "Statystyki:\n";

        foreach (var Key in Manager.hero.Stats)
        {
            stats += $"{Key.Key}: {Key.Value}\n";
        }

        lblStats.Text = stats;
    }

    async Task Start()
    {
        await Utils.WriteAsync("TEst 123");
        await Utils.WriteAsync("12345678901234567890");
        await Utils.WriteAsync("123 Another test");



        Statystyki stats = new();
        stats.GetStatsFromHero(Manager.hero!);

        JSON json = new("", new(), true, new(), stats, Manager.hero!.inventory.ToList());

        string serialized = JSON.Serialize(json);

        await Utils.WriteAsync(await AiManager.Generate(serialized));
    }
}