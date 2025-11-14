using Spectre.Console;

namespace Pokemon_simulator;

public class Squirtle : WaterPokemon
{
    public Squirtle(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
    }

    public override void Speak()
    {
        AnsiConsole.MarkupLine($"[gray]{Name} says:[/] Squirtle Squirt!");
    }
}