
using Spectre.Console;

namespace Pokemon_simulator;

public static class ConsoleUi
{
    public static void Run(List<Pokemon> team)
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold]Choose an action[/]")
                    .AddChoices("Show team", "Choose & attack", "Level up all", "Evolve eligibles", "Charts", "Exit"));

            switch (choice)
            {
                case "Show team":
                    ShowTeamTable(team);
                    break;

                case "Choose & attack":
                    var p = AnsiConsole.Prompt(
                        new SelectionPrompt<Pokemon>()
                            .Title("[bold]Pick your Pokemon[/]")
                            .UseConverter(x => $"{x.Name} [grey]({x.Type}, Lv {x.Level})[/]")
                            .AddChoices(team));

                    AnsiConsole.Write(new Rule($"[blue]{p.Name}[/]").RuleStyle(Style.Parse("blue")));
                    p.Attack();
                    break;

                case "Level up all":
                    foreach (var x in team) x.RaiseLevel();
                    break;

                case "Evolve eligibles":
                    foreach (var x in team)
                    {
                        if (x is IEvolvable e)
                        {
                            AnsiConsole.MarkupLine($"[grey]Trying to evolve {x.Name}...[/]");
                            e.Evolve();
                        }
                    }
                    break;

                case "Charts":
                    ShowLevelBarChart(team);
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[grey]Bye![/]");
                    return;
            }
        }
    }

    private static void ShowTeamTable(IEnumerable<Pokemon> team)
    {
        var table = new Table().Border(TableBorder.Rounded).Title("[u]Team[/]");
        table.AddColumn("Name");
        table.AddColumn(new TableColumn("Type").Centered());
        table.AddColumn(new TableColumn("Level").RightAligned());
        table.AddColumn(new TableColumn("#Attacks").RightAligned());

        foreach (var p in team)
            table.AddRow(
                Markup.Escape(p.Name),
                ColorizeType(p.Type),
                p.Level.ToString(),
                p.AttackCount.ToString());


        AnsiConsole.Write(table);

        var root = new Tree("[bold]Pokémons[/]");
        foreach (var p in team)
        {
            var node = root.AddNode($"{p.Name} [grey]({p.Type}, Lv {p.Level})[/]");
            foreach (var a in p.KnownAttacks())
                node.AddNode($"{a.Name} [grey]({a.BasePower})[/]");
        }
        AnsiConsole.Write(root);
    }

    private static void ShowLevelBarChart(IEnumerable<Pokemon> team)
    {
        var chart = new BarChart().Width(60).Label("[bold]Levels[/]").CenterLabel();
        foreach (var p in team)
        {
            if (p.Type == ElementType.Fire)
                chart.AddItem(p.Name, p.Level, Color.Red);
            if (p.Type == ElementType.Water)
                chart.AddItem(p.Name, p.Level, Color.Aqua);
            if (p.Type == ElementType.Grass)
                chart.AddItem(p.Name, p.Level, Color.Green);

        }
        AnsiConsole.Write(chart);
    }

    private static string ColorizeType(ElementType type) => type switch
    {
        ElementType.Fire => "[red]Fire[/]",
        ElementType.Water => "[aqua]Water[/]",
        ElementType.Grass => "[green]Grass[/]",
        _ => "[grey]Unknown[/]"
    };

}
