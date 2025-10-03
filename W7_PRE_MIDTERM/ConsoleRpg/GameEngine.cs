using ConsoleRpg.Services;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace ConsoleRpg;

public class GameEngine
{
    private readonly IPlayerService _playerService;
    //private readonly IMonsterService _monsterService;

    private Player _player;
    private readonly IEntityDao<MonsterBase> _monsterDao;
    private readonly IGameUi _ui;

    public GameEngine(
        IPlayerService playerService,
        //IMonsterService monsterService,
        IEntityDao<MonsterBase> monsterDao,
        IGameUi ui)
    {
        _playerService = playerService;
        _monsterDao = monsterDao;
        _ui = ui;
    }

    public void Run()
    {
        SetupGame();
    }

    private void SetupGame()
    {
        var players = _playerService.GetAllPlayers();
        _player = _ui.SelectPlayer(players);


        if (_player == null)
        {
            _ui.ShowMessage("No player selected. Exiting game setup.");
            Environment.Exit(0);
        }
        _ui.ShowMessage($"{_player.Name} has entered the game.");
        Thread.Sleep(500);
        GameLoop();
    }

    private void GameLoop()
    {
        while (true)
        {
            _ui.ShowMenu();
            var input = _ui.GetUserInput();

            switch (input)
            {
                case "1":
                    _ui.ShowMessage("Leveling up player...");
                    _playerService.LevelUpPlayer(_player);
                    break;
                case "2":
                    var newPlayer = _ui.PromptForNewPlayer();
                    if (newPlayer != null)
                    {
                        _playerService.AddPlayer(newPlayer);
                    }
                    break;
                case "3":
                    var players = _playerService.GetAllPlayers();
                    _ui.ShowPlayers(players);
                    _ui.ShowMessage("Press Enter to return to the menu...");
                    _ui.GetUserInput();
                    break;
                case "4":
                    var monsters = _monsterDao.GetAll();
                    _ui.ShowMonsters(monsters);
                    break;
                case "5":
                    Fight();
                    break;
                case "6":
                    _ui.ShowPlayerItems(_player);
                    break;
                case "0":
                    _ui.ShowMessage("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    _ui.ShowMessage("Invalid selection. Please choose 1, 2, 3, 4, 5, or 0.");
                    break;
            }
        }

    }

    private void Fight()
    {
        var monster = _monsterDao.GetByName("Clump");
        if (monster == null)
        {
            _ui.ShowMessage("No monsters available to fight.");
            return;
        }
        _ui.ShowMessage($"A wild {monster.Name} appears!");

        var damage = monster.DealDamage();
        _playerService.DamagePlayer(_player, damage);
    }
}
