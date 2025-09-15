using ConsoleRpg.Helpers;
using ConsoleRpg.Services;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models;
using ConsoleRpgEntities; // For chest classes

namespace ConsoleRpg;

/// <summary>
/// GameEngine orchestrates the game flow and user interaction.
/// It now supports both player management and chest interaction.
/// </summary>
public class GameEngine
{
    private readonly MenuManager _menuManager;
    private readonly OutputManager _outputManager;

    private readonly IPlayerService _playerService;
    private Player _player;

    public GameEngine(IContext context, MenuManager menuManager, OutputManager outputManager, IPlayerService playerService)
    {
        _menuManager = menuManager;
        _outputManager = outputManager;
        _playerService = playerService;
    }

    public void Run()
    {
        if (_menuManager.ShowMainMenu())
        {
            SetupGame();
        }
    }

    private void SetupGame()
    {
        _outputManager.AddLogEntry("Welcome! Choose a mode:");
        while (true)
        {
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("Main Menu:");
            _outputManager.AddLogEntry("1. Player Management");
            _outputManager.AddLogEntry("2. Chest Interaction");
            _outputManager.AddLogEntry("0. Quit");
            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    SetupPlayerManagement();
                    break;
                case "2":
                    ChestGameLoop();
                    break;
                case "0":
                    _outputManager.ShowGoodbyeModal();
                    Environment.Exit(0);
                    break;
                default:
                    _outputManager.AddLogEntry("[red]Invalid selection. Please choose a valid option.[/]");
                    break;
            }
        }
    }

    // --- Player Management (original logic) ---

    private void SetupPlayerManagement()
    {
        _player = SelectPlayer();
        if (_player == null)
        {
            _outputManager.AddLogEntry("[red]No player selected. Exiting player management.[/]");
            return;
        }
        _outputManager.AddLogEntry($"{_player.Name} has entered player management.");
        Thread.Sleep(500);
        GameLoop();
    }

    private void GameLoop()
    {
        while (true)
        {
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("Player Management Menu:");
            _outputManager.AddLogEntry("1. Level Up Player");
            _outputManager.AddLogEntry("2. Add Player");
            _outputManager.AddLogEntry("3. List All Players");
            _outputManager.AddLogEntry("0. Return to Main Menu");
            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    _outputManager.AddLogEntry("Leveling up player...");
                    _playerService.LevelUpPlayer(_player);
                    break;
                case "2":
                    var newPlayer = PromptForNewPlayer();
                    if (newPlayer != null)
                    {
                        _playerService.AddPlayer(newPlayer);
                    }
                    break;
                case "3":
                    ListAllPlayers();
                    break;
                case "0":
                    return;
                default:
                    _outputManager.AddLogEntry("Invalid selection. Please choose a valid option.");
                    break;
            }
        }
    }

    private Player PromptForNewPlayer()
    {
        var name = _outputManager.GetUserInput("Enter player name:");
        var profession = _outputManager.GetUserInput("Enter profession:");
        var levelStr = _outputManager.GetUserInput("Enter level:");
        var hitPointsStr = _outputManager.GetUserInput("Enter hit points:");
        var equipmentStr = _outputManager.GetUserInput("Enter equipment (comma or | separated):");

        if (!int.TryParse(levelStr, out var level) || !int.TryParse(hitPointsStr, out var hitPoints))
        {
            _outputManager.AddLogEntry("[red]Invalid level or hit points. Player not added.[/]");
            return null;
        }

        var equipment = equipmentStr
            .Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(e => e.Trim())
            .ToList();

        return new Player(name, profession, level, hitPoints, equipment);
    }

    private Player SelectPlayer()
    {
        var players = _playerService.GetAllPlayers();
        if (players == null || players.Count == 0)
        {
            _outputManager.AddLogEntry("[red]No players found. Please add a player first.[/]");
            return null;
        }

        _outputManager.ShowPlayerTable(players, "Available Players");

        while (true)
        {
            var input = _outputManager.PromptInput("Select a player by number:");
            if (int.TryParse(input, out int index) && index > 0 && index <= players.Count)
            {
                return players[index - 1];
            }
            _outputManager.AddLogEntry("[red]Invalid selection. Please enter a valid number.[/]");
        }
    }

    private void ListAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        if (players == null || players.Count == 0)
        {
            _outputManager.AddLogEntry("[red]No players found.[/]");
            return;
        }
        _outputManager.ShowPlayerTable(players, "All Players");
        _outputManager.PromptInput("Press [green]Enter[/] to return to the menu...");
    }

    // --- Chest Interaction (new logic) ---

    private void ChestGameLoop()
    {
        var openableChest = new OpenableChest();
        var pickableChest = new PickableChest(keyId: 1, isLocked: true);

        while (true)
        {
            _outputManager.AddLogEntry("");
            _outputManager.AddLogEntry("Chest Menu:");
            _outputManager.AddLogEntry("1. Open a simple chest");
            _outputManager.AddLogEntry("2. Attempt to open a locked pickable chest");
            _outputManager.AddLogEntry("3. Pick the lock on the pickable chest");
            _outputManager.AddLogEntry("4. Open the pickable chest after picking");
            _outputManager.AddLogEntry("0. Return to Main Menu");

            var input = _outputManager.GetUserInput("Choose an action:");

            switch (input)
            {
                case "1":
                    TryOpenSimpleChest(openableChest);
                    break;
                case "2":
                    TryOpenPickableChest(pickableChest);
                    break;
                case "3":
                    TryPickLock(pickableChest);
                    break;
                case "4":
                    TryOpenPickableChest(pickableChest);
                    break;
                case "0":
                    return;
                default:
                    _outputManager.AddLogEntry("[red]Invalid selection. Please choose a valid option.[/]");
                    break;
            }
        }
    }

    private void TryOpenSimpleChest(OpenableChest chest)
    {
        _outputManager.AddLogEntry("Attempting to open a simple chest...");
        try
        {
            chest.Open();
            _outputManager.AddLogEntry("[green]The simple chest is now open.[/]");
        }
        catch (InvalidOperationException ex)
        {
            _outputManager.AddLogEntry($"[red]Cannot open: {ex.Message}[/]");
        }
    }

    private void TryOpenPickableChest(PickableChest chest)
    {
        _outputManager.AddLogEntry("Attempting to open the pickable chest...");
        try
        {
            chest.Open();
            _outputManager.AddLogEntry("[green]The pickable chest is now open.[/]");
        }
        catch (InvalidOperationException ex)
        {
            _outputManager.AddLogEntry($"[red]Cannot open: {ex.Message}[/]");
        }
    }

    private void TryPickLock(PickableChest chest)
    {
        _outputManager.AddLogEntry("Attempting to pick the lock...");
        try
        {
            chest.Pick();
            _outputManager.AddLogEntry("[green]The pickable chest lock has been picked.[/]");
        }
        catch (InvalidOperationException ex)
        {
            _outputManager.AddLogEntry($"[red]Cannot pick: {ex.Message}[/]");
        }
    }
}
