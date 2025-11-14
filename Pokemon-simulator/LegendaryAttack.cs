using Spectre.Console;

namespace Pokemon_simulator;

public class LegendaryAttack : Attack
{
    public LegendaryAttack(Attack baseAttack)
        : base(baseAttack.Name, baseAttack.Type, baseAttack.BasePower)
    {
    }

    public override void Use(int level)
    {
        AnsiConsole.MarkupLine($"[grey]{Name} used[/] unleashes its potemtial with total power [bold]{BasePower + level * 2}[/]\n");
    }
}
