using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Common;
using Spectre.Console;

namespace Pokemon_simulator.Domain.Creatures.Base;

public abstract class FirePokemon : Pokemon
{
    protected FirePokemon(string name, int level, IEnumerable<Attack> attacks)
        : base(name, level, attacks)
    {
        Type = ElementType.Fire;
    }
}





