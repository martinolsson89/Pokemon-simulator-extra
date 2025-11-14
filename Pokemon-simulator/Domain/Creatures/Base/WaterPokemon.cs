using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Common;

namespace Pokemon_simulator.Domain.Creatures.Base;

public abstract class WaterPokemon : Pokemon
{
    protected WaterPokemon(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
        Type = ElementType.Water;
    }

}





