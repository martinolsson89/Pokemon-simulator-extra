using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Creatures.Base;
using Spectre.Console;

namespace Pokemon_simulator.Domain.Creatures.Species;

public class Bulbasaur : GrassPokemon
{
    public Bulbasaur(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
    }

    public void Eating()
    {
        Console.WriteLine($"[{GetType().Name}] Eating executed.");
        Console.WriteLine($"{Name} is eating some grass.");
    }

    public override void Speak()
    {
        AnsiConsole.MarkupLine($"[gray]{Name} says:[/] Bulba bulba!");
    }
}