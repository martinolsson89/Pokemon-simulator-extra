using Spectre.Console;

namespace Pokemon_simulator;

public class Charmander : FirePokemon, IEvolvable
{
    public Charmander(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
    }

    public override void Attack()
    {
        AnsiConsole.MarkupLine("[yellow][[Charmander override]] Attack()[/]");
        RandomAttack();
    }

    public void Evolve()
    {
        var old = Name;
        AnsiConsole.Status()
            .Start("[yellow]Evolving...[/]", ctx =>
            {
                Thread.Sleep(900);
                Level += 10;
                Name = "Charmeleon";
            });

        AnsiConsole.MarkupLine($"{old} is evolving... Now it is a [bold]{Name}[/] and its level is [bold]{Level}[/]");
    }
}