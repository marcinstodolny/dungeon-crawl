﻿using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;

namespace RoguelikeGame
{
    internal class Game
    {
        public List<Score> highScores;
        public Dungeon dungeon;
        public Player player;

        public Game()
        {
            highScores = new List<Score>();
            dungeon = new Dungeon();
            dungeon = new Dungeon(10, 10);
            player = new Player(dungeon.Board[5, 5], 10, 10, 10);
        }

        public static void Menu()
        {
            Game game = new();
            ushort optionsCount = 3;
            bool exit = false;
            while (!exit)
            {
                Display.PrintMainMenu();
                ushort choice = Input.GetChoice(optionsCount);

                switch ((GameMenu)choice)
                {
                    case GameMenu.NewGame:
                        Display.Clear();
                        game.dungeon = new Dungeon();
                        Display.PrintDungeon(game.dungeon);
                        break;
                    case GameMenu.HighScores:
                        Display.PrintHighScores(game.highScores);
                        break;
                    case GameMenu.Exit:
                        Display.PrintExitGame();
                        exit = true;
                        break;
                    default:
                        // invalid input
                        Display.PrintInvalidInputError();
                        break;
                }
                Display.PressAnyKey();
                Input.WaitForInput();
                Display.Clear();
            }
                
        }
    }
}
