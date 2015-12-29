/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * SudokuConsoleGameLogic.cs
 * 
 * The game logic class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySudoku2_0
{
    /// <summary>
    /// The game logic class
    /// </summary>
    public class SudokuConsoleGameLogic
    {
        // Constructor to instantiate the game logic
        public SudokuConsoleGameLogic()
        {

        }

        #region Run()
        /// <summary>
        /// This method runs the game logic
        /// </summary>
        public void Run()
        {
            // Create an instance of the DisplayScreens class
            DisplayScreens screens = new DisplayScreens();

            // Create an instance of the SavedGameRepository
            SavedGameRepository savedGameRepository = new SavedGameRepository();

            // Create an instance of the serializer to pull and save the list of games
            Serializer serializer = new Serializer();

            // Download the saved games into the repository
            savedGameRepository = serializer.DeserializeRepository("SavedGames.dat");

            // Run the splash screen
            screens.SplashScreen();

            Console.Clear();

            // This boolean determines if the main loop continues
            bool continueGame = true;

            // This string records the user's command
            string command = "";

            do
            {
                // Display the main menu
                screens.MainMenuScreen();

                // Wait for the user's command
                command = Console.ReadLine();

                // Ensure case insensitivity
                command = command.ToUpper();

                // Remove starting and trailing empty spaces
                command = command.Trim();

                #region New or Load Command
                if (command == "1" || command == "NEW" || command == "2" || command == "LOAD")
                {
                    // Create the list of saved games for passing to the play method
                    List<SudokuConsoleGame> savedGames = new List<SudokuConsoleGame>();
                    savedGames = savedGameRepository.SavedGames;

                    Console.Clear();

                    // The users game
                    SudokuConsoleGame game = new SudokuConsoleGame();

                    if (command == "1" || command == "NEW")
                    {
                        string userName;
                        SudokuConsoleGame.Difficulty difficulty = new SudokuConsoleGame.Difficulty();

                        screens.CreateNewGameScreen(out userName, out difficulty);
                        Console.Clear();

                        // Create the game
                        game = new SudokuConsoleGame(userName, difficulty);
                    }
                    else if (command == "2" || command == "LOAD")
                    {
                        screens.LoadGameScreen(savedGameRepository, ref game);
                        Console.Clear();
                    }

                    if (game != null)
                    {
                        game.Play(ref savedGames);
                    }
                    Console.Clear();
                }
                #endregion

                #region Delete Command
                else if (command == "3" || command == "DELETE")
                {
                    Console.Clear();
                    screens.DeleteGameScreen(savedGameRepository);
                    Console.Clear();
                }
                #endregion

                #region Lead Command
                else if (command == "4" || command == "LEAD")
                {
                    Console.Clear();
                    screens.LeaderboardScreen(savedGameRepository);
                    Console.Clear();
                }
                #endregion

                #region Instruct Command
                else if (command == "5" || command == "INSTRUCT")
                {
                    Console.Clear();
                    screens.InstructionScreen();
                    Console.Clear();
                }
                #endregion

                #region Exit Command
                else if (command == "6" || command == "EXIT")
                {
                    Console.WriteLine("\n\t\t         Thanks for playing!\n\n\t\t         (Press Enter to Exit)");
                    Console.ReadLine();
                    continueGame = false;
                }
                #endregion

                else
                {
                    // If the user fails to enter a valid command
                    Console.WriteLine("\n\t\t         Please enter a valid command.\n\n\t\t         (Press Enter to Continue)");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (continueGame == true);
        }
        #endregion
    }
}