namespace Pokemon_simulator;

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
}