namespace Pokemon_simulator;

public abstract class WaterPokemon : Pokemon
{
    protected WaterPokemon(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
        Type = ElementType.Water;
    }

}





