using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Creatures.Base;
using Pokemon_simulator.Domain.Interfaces;
using Pokemon_simulator.Domain.Creatures.Species;
using Spectre.Console;

namespace Pokemon_simulator.Domain.Creatures.Species;

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

    public Pokemon Evolve()
    {
        AnsiConsole.Status().Start("[yellow]Evolving...[/]", _ => Thread.Sleep(900));
        var evolved = new Charmeleon(Level + 10, _attacks.ToList());
        AnsiConsole.MarkupLine($"Charmander evolved into [bold]{evolved.Name}[/] at level [bold]{evolved.Level}[/]!");

        return evolved;
    }

    public override void Speak()
    {
        AnsiConsole.MarkupLine($"[gray]{Name} says:[/] Char Char!");
    }
}
