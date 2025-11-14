using Spectre.Console;
namespace Pokemon_simulator;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            AnsiConsole.Write(new FigletText("Pokemon").Centered().Color(Color.Orange1));
            AnsiConsole.Write(new Rule("[yellow]Training Simulator[/]").Centered());

            // Seeda data
            IEnumerable<Attack> attacks = DataSeeder.SeedAttacks();
            List<Pokemon> team = DataSeeder.SeedPokemons(attacks);

            ConsoleUi.Run(team);

        }

        catch (ArgumentException ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
        }

        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
        }
    }

}





