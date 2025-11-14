using Spectre.Console;

namespace Pokemon_simulator;

public abstract class Pokemon
{
    private string _name = string.Empty;
    private int _level;
    private readonly List<Attack> _attacks;
    public int AttackCount => _attacks.Count;

    public string Name
    {
        get => _name;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 15)
                throw new ArgumentException("Name must be 2–15 characters.");

            _name = value.Trim();
        }
    }
    public int Level
    {
        get => _level;
        protected set
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException(nameof(Level), "Level must be ≥ 1.");

            _level = value;
        }
    }

    public ElementType Type { get; protected set; }

    protected Pokemon(string name, int level, IEnumerable<Attack> attacks)
    {
        ArgumentNullException.ThrowIfNull(attacks);

        _attacks = attacks.ToList();

        if (_attacks.Count == 0)
            throw new ArgumentException("A Pokémon must know at least one attack.", nameof(attacks));

        Name = name;
        Level = level;
    }

    public void RandomAttack()
    {
        Random rnd = new Random();
        int index = rnd.Next(0, _attacks.Count);
        var attack = _attacks[index];

        AnsiConsole.MarkupLine($"[grey]{Name} used[/] [bold]{attack.Name}[/]!");
        attack.Use(Level);
    }

    public virtual void Attack()
    {
        var selected = AnsiConsole.Prompt(
        new SelectionPrompt<Attack>()
            .Title($"[bold yellow]Choose {Name}'s attack[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up/down to see more)[/]")
            .UseConverter(a => $"{a.Name} [grey]({a.Type}, {a.BasePower} base)[/]")
            .AddChoices(_attacks));

        AnsiConsole.MarkupLine($"\n[grey]{Name} used[/] [bold]{selected.Name}[/]!");
        selected.Use(Level);
    }

    public void RaiseLevel()
    {
        Level += 1;
        AnsiConsole.MarkupLine($"[green]{Name} leveled up to {Level}![/]");
    }

    public IEnumerable<Attack> KnownAttacks() => _attacks.ToArray();

}




