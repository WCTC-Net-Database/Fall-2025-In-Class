using ConsoleRpg;
using ConsoleRpg.Decorators;
using ConsoleRpg.Helpers;
using ConsoleRpg.Services;
using ConsoleRpgEntities.Data;

namespace ConsoleRpg;

public static class Program
{
    private static void Main(string[] args)
    {
        // Manually create each dependency, from the "bottom" up.
        // Notice how each object is constructed with the objects it needs.
        var context = new GameContext();
        var outputManager = new OutputManager();
        var menuManager = new MenuManager(outputManager);
        var playerDao = new PlayerDao(context);
        var playerService = new PlayerService(outputManager, playerDao);

        // Decorate the player service with auto-save functionality.
        // This wraps the playerService so that changes are automatically saved.
        var autoSavePlayerService = new AutoSavePlayerServiceDecorator(playerService, context);

        // Pass all dependencies to the GameEngine.
        // This is called "constructor injection" (even though we're doing it manually).
        var gameEngine = new GameEngine(context, menuManager, outputManager, autoSavePlayerService);

        // Start the game!
        gameEngine.Run();
    }
}