namespace Pokemon_simulator;

public abstract class GrassPokemon : Pokemon
{
    protected GrassPokemon(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
        Type = ElementType.Grass;
    }

}





