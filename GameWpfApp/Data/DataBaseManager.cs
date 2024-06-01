using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameWpfApp.DbConnection;

namespace GameWpfApp.Data
{
    internal static class DataBaseManager
    {
        private static GamesdbEntities _dbConnection = new GamesdbEntities();

        public static bool UpdateDatabase()
        {
            try
            {
                _dbConnection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Game> GetGames()
        {
            return _dbConnection.Game.ToList();
        }

        public static bool UpdateGame(Game m)
        {
            try
            {
                var game = _dbConnection.Game.FirstOrDefault(g => g.Id == m.Id);
                if (game != null)
                {
                    _dbConnection.Entry(game).CurrentValues.SetValues(m);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddGame(Game game)
        {
            try
            {
                _dbConnection.Game.Add(game);
                _dbConnection.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool RemoveGame(Game game)
        {
            try
            {
                var gameToRemove = _dbConnection.Game.FirstOrDefault(g => g.Id == game.Id);
                if (gameToRemove != null)
                {
                    _dbConnection.Game.Remove(gameToRemove);
                    _dbConnection.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static List<GameType> GetGameTypes()
        {
            return _dbConnection.GameType.ToList();
        }

        public static bool AddGameType(GameType gameType)
        {
            try
            {
                _dbConnection.GameType.Add(gameType);
                _dbConnection.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool UpdateGameType(GameType gameType)
        {
            try
            {
                var existingGameType = _dbConnection.GameType.FirstOrDefault(gt => gt.Id == gameType.Id);
                if (existingGameType != null)
                {
                    _dbConnection.Entry(existingGameType).CurrentValues.SetValues(gameType);
                    _dbConnection.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool RemoveGameType(GameType gameType)
        {
            try
            {
                var gameTypeToRemove = _dbConnection.GameType.FirstOrDefault(gt => gt.Id == gameType.Id);
                if (gameTypeToRemove != null)
                {
                    _dbConnection.GameType.Remove(gameTypeToRemove);
                    _dbConnection.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static List<User> GetUsers()
        {
            return _dbConnection.User.ToList();
        }

        public static void SaveChanges()
        {
            _dbConnection.SaveChanges();
        }

        public static bool AddUser(User u)
        {
            try
            {
                _dbConnection.User.Add(u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Role> GetRoles()
        {
            return _dbConnection.Role.ToList();
        }
    }
}