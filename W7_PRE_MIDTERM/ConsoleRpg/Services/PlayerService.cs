using ConsoleRpgEntities.Models;
using ConsoleRpgEntities.Data;

namespace ConsoleRpg.Services
{
    /// <summary>
    /// PlayerService contains business logic for Player operations.
    /// It should not perform data access directly or handle persistence.
    /// 
    /// SRP: Only business logic for Player.
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private readonly IEntityDao<Player> _playerDao;

        public PlayerService(IEntityDao<Player> playerDao)
        {
            _playerDao = playerDao;
        }

        public void DamagePlayer(Player player, int damage)
        {
            // reduce the damage by the defense items the player has equipped
            player.AbilityScores.HitPoints -= damage;
            if (player.AbilityScores.HitPoints < 0)
                player.AbilityScores.HitPoints = 0;
            Console.WriteLine($"Player {player.Name} took {damage} damage and now has {player.AbilityScores.HitPoints} hit points.");
        }
        public void LevelUpPlayer(Player player)
        {
            player.Level++;
            player.AbilityScores.HitPoints += 5;
            Console.WriteLine($"Player {player.Name} leveled up to level {player.Level} with {player.AbilityScores.HitPoints} hit points.");
        }

        public void AddPlayer(Player player)
        {
            _playerDao.Add(player);
            Console.WriteLine($"Player {player.Name} was added.");
        }

        public List<Player> GetAllPlayers()
        {
            return _playerDao.GetAll();
        }
    }
}
