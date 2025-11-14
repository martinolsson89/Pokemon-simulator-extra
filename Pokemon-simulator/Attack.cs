namespace Pokemon_simulator;

public class Attack
{

    private string _name = string.Empty;
    private int _basepower;
    public string Name
    {
        get => _name;
        init
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 20)
                throw new ArgumentException("Name must be 2–20 characters.", nameof(Name));

            _name = value;
        }
    }
    public int BasePower
    {
        get => _basepower;
        init
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException("BasePower must be ≥ 1.", nameof(BasePower));

            _basepower = value;
        }
    }
    public ElementType Type { get; init; }

    public Attack(string name, ElementType type, int basePower)
    {
        Name = name;
        Type = type;
        BasePower = basePower;
    }


    public void Use(int level)
    {
        Console.WriteLine($"{Name} hit with a total power of {BasePower + level}\n");
    }
}
