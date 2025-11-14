namespace Pokemon_simulator;

public abstract class FirePokemon : Pokemon
{
    protected FirePokemon(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
        Type = ElementType.Fire;
    }
}





