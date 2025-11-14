namespace Pokemon_simulator;

public static class DataSeeder
{
    public static IEnumerable<Attack> SeedAttacks()
    {
        return new List<Attack>
        {
            new Attack("Flamethrower", ElementType.Fire, 90),
            new Attack("Ember", ElementType.Fire, 40),

            new Attack("Hydro Pump", ElementType.Water, 110),
            new Attack("Water Gun", ElementType.Water, 40),

            new Attack("Solar Beam", ElementType.Grass, 120),
            new Attack("Vine Whip", ElementType.Grass, 45)
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





