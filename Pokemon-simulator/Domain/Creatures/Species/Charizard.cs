using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Creatures.Base;
using Spectre.Console;

namespace Pokemon_simulator.Domain.Creatures.Species;

public sealed class Charizard : FirePokemon
{
    public Charizard(int level, IEnumerable<Attack> attacks)
        : base("Charizard", level, attacks) { }

    public override void Speak()
    {
        AnsiConsole.MarkupLine($"[gray]{Name} says:[/] CHAAAR-ZARD! :fire:");
    }

}