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

        public static List<Game> RetroGames = new List<Game>()
        {
            new Game("Super Mario", GameTypes[0], 49.99m),
            new Game("Contra", GameTypes[1], 29.99m),
            new Game("Tetris", GameTypes[2], 19.99m),
            new Game("Chess", GameTypes[3], 10.99m),
            new Game("Battleship", GameTypes[1], 8.99m),
            new Game("Tic-Tac-Toe", GameTypes[3], 9.99m),
            new Game("Checkers", GameTypes[3], 15.99m),
            new Game("Go", GameTypes[0], 39.99m),
            new Game("Solitaire", GameTypes[4], 17.99m)
        };

        public static List<User> Users = new List<User>()
        {
            new User() {Login = "user", Password = "user"},
            new User() {Login = "admin", Password = "admin", Role = 0}
        };
    }
}