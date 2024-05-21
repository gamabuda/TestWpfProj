using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<GameType> GameTypes = new List<GameType>()
        {
            new GameType("Platformer"),
            new GameType("Shooter"),
            new GameType("Puzzle"),
            new GameType("Board Game"),
            new GameType("Card Game")
        };

        public static List<RetroGame> RetroGames = new List<RetroGame>()
        {
            new RetroGame("Super Mario", GameTypes[0], 49.99m),
            new RetroGame("Contra", GameTypes[1], 29.99m),
            new RetroGame("Tetris", GameTypes[2], 19.99m),
            new RetroGame("Chess", GameTypes[3], 10.99m),
            new RetroGame("Battleship", GameTypes[1], 8.99m),
            new RetroGame("Tic-Tac-Toe", GameTypes[3], 9.99m),
            new RetroGame("Checkers", GameTypes[3], 15.99m),
            new RetroGame("Go", GameTypes[0], 39.99m),
            new RetroGame("Solitaire", GameTypes[4], 17.99m)
        };

        public static List<User> Users = new List<User>()
        {
            new User() {Login = "user", Password = "user"},
            new User() {Login = "admin", Password = "admin", Role = 0}
        };
    }
}