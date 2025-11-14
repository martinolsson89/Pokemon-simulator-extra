using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Creatures.Base;
using Pokemon_simulator.Domain.Interfaces;
using Spectre.Console;

namespace Pokemon_simulator.Domain.Creatures.Species;

public class Charmeleon : FirePokemon, IEvolvable
{
    public Charmeleon(int level, IEnumerable<Attack> attacks)
        : base("Charmeleon", level, attacks) { }

    public override void Speak()
    {
        AnsiConsole.MarkupLine($"[gray]{Name} says:[/] Char-meleon!");
    }

    public Pokemon Evolve()
    {
        AnsiConsole.Status().Start("[yellow]Evolving...[/]", _ => Thread.Sleep(900));
        var evolved = new Charizard(Level + 10, _attacks.ToList());
        AnsiConsole.MarkupLine($"Charmeleon evolved into [bold]{evolved.Name}[/] at level [bold]{evolved.Level}[/]!");

        return evolved;
    }

    public override Pokemon RaiseLevel()
    {
        base.RaiseLevel();
        return ReachedThreshold ? Evolve() : this;
    }
}
