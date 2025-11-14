using Pokemon_simulator.Domain.Attacks;
using Pokemon_simulator.Domain.Common;
using Pokemon_simulator.Domain.Creatures.Base;
using Pokemon_simulator.Domain.Creatures.Species;

namespace Pokemon_simulator.Seed;

public static class DataSeeder
{
    public static IEnumerable<Attack> SeedAttacks()
    {
        var flamethrower = new Attack("Flamethrower", ElementType.Fire, 90);
        var ember = new Attack("Ember", ElementType.Fire, 40);
        var l_ember = new LegendaryAttack(ember);
        var l_flamethrower = new LegendaryAttack(flamethrower);

        var hydroPump = new Attack("Hydro Pump", ElementType.Water, 110);
        var waterGun = new Attack("Water Gun", ElementType.Water, 40);
        var l_waterGun = new LegendaryAttack(waterGun);
        var l_hydroPump = new LegendaryAttack(hydroPump);

        var solarBeam = new Attack("Solar Beam", ElementType.Grass, 120);
        var vineWhip = new Attack("Vine Whip", ElementType.Grass, 45);
        var l_vineWhip = new LegendaryAttack(vineWhip);
        var l_solarBeam = new LegendaryAttack(solarBeam);

        return new List<Attack>
        {
            ember, flamethrower, waterGun, hydroPump, vineWhip, solarBeam,
            l_ember, l_flamethrower, l_waterGun, l_hydroPump, l_vineWhip, l_solarBeam
        };

    }

    public static List<Pokemon>  SeedPokemons(IEnumerable<Attack> attacks)
    {
        var fireAttacks = attacks.Where(a => a.Type == ElementType.Fire);
        var waterAttacks = attacks.Where(a => a.Type == ElementType.Water);
        var grassAttacks = attacks.Where(a => a.Type == ElementType.Grass);

        return new List<Pokemon>
        {
            new Charmander("Charmander", 1, fireAttacks),
            new Squirtle("Squirtle", 2, waterAttacks),
            new Bulbasaur("Bulbasaur", 5, grassAttacks)


        };
    }
}





