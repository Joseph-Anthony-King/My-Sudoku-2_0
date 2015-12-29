/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * DisplayScreens.cs
 * 
 * This class describes the console screens
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MySudoku2_0
{
    /// <summary>
    /// This class describes the console screens
    /// </summary>
    public class DisplayScreens
    {
        #region SplashScreen()
        /// <summary>
        /// This is the splash screen for the game
        /// </summary>
        public void SplashScreen()
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);
            Console.MoveBufferArea(0, 0, 20, 80, 0, 0);
            Console.SetWindowPosition(0, 0);

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            sb1.Append("\n\n\t\t\t ╔═════════════════════════╗\n");
            sb1.Append("\t\t\t ║                         ║\n");
            sb1.Append("\t\t\t ║        MY SUDOKU        ║\n");
            sb1.Append("\t\t\t ║                         ║\n");
            sb1.Append("\t\t\t ╚═════════════════════════╝\n");

            sb2.Append("\n\n\t\t\t ╔═════════════════════════╗\n");
            sb2.Append("\t\t\t ║                         ║\n");
            sb2.Append("\t\t\t ║        MY SUDOKU        ║\n");
            sb2.Append("\t\t\t ║                         ║\n");
            sb2.Append("\t\t\t ╚═════════════════════════╝\n");
            sb2.Append("\n\t\t\t     By: Joseph King\n");
            sb2.Append("\t\t\t     Copyright 2013\n");
            sb2.Append("\t\t\t     Version 2.0\n");
            sb2.Append("\n\t\t          (Press Enter To Continue)\n\n");

            var defaultColor = Console.ForegroundColor;

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sb1);

                Thread.Sleep(100);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sb1);

                Thread.Sleep(100);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sb1);

                Thread.Sleep(100);
                Console.Clear();
            }

            Console.ForegroundColor = defaultColor;

            Console.WriteLine(sb2.ToString());

            Console.ReadLine();
        }
        #endregion

        #region MainMenuScreen()
        /// <summary>
        /// This is the main screen for the game
        /// </summary>
        public void MainMenuScreen()
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            StringBuilder sb = new StringBuilder();

            sb.Append("\n\t\t\t          Main Menu\n");
            sb.Append("\n\t\t         Commands:\n\n");
            sb.Append("\t\t         1) New Game (NEW)\n");
            sb.Append("\t\t         2) Load Saved Game (LOAD)\n");
            sb.Append("\t\t         3) Delete Saved Game (DELETE)\n");
            sb.Append("\t\t         4) Leaderboard (LEAD)\n");
            sb.Append("\t\t         5) Instructions (INSTRUCT)\n");
            sb.Append("\t\t         6) Exit Game (EXIT)\n\n\n");
            sb.Append("\t\t         Command> ");

            Console.Write(sb.ToString());
        }
        #endregion

        #region InstructionScreen()
        /// <summary>
        /// This is the instruction screen for the game
        /// </summary>
        public void InstructionScreen()
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            string sb201 = "\t\t\t       MY SUDOKU\n\n\t\t\t   1 2 3 4 5 6 7 8 9\n\n\t\t\t1  ";
            string sb202red = "2";
            string sb203 = " _ ";
            string sb204red = "3";
            string sb205 = " _ ";
            string sb206red = "5";
            string sb207 = " _ _ _ _\n\t\t\t2  ";
            string sb208red = "9";
            string sb209 = " _ _ _ ";
            string sb210red = "3";
            string sb211 = " _ _ _ _\n\t\t\t3  ";
            string sb212red = "6";
            string sb213 = " _ ";
            string sb214red = "7";
            string sb215 = " _ _ _ _ ";
            string sb216red = "3";
            string sb217 = " _\n\t\t\t4  ";
            string sb218red = "5 7 4";
            string sb219 = " _ ";
            string sb220red = "8 9";
            string sb221 = " _ _ ";
            string sb222red = "3";
            string sb223 = "\n\t\t\t5  _ _ ";
            string sb224red = "8";
            string sb225 = " _ _ _ ";
            string sb226red = "9";
            string sb227 = " _ _\n\t\t\t6  ";
            string sb228red = "1";
            string sb229 = " _ _ ";
            string sb230red = "3";
            string sb231 = " _ _ _ ";
            string sb232red = "5 7";
            string sb233 = "\n\t\t\t7  _ _ _ _ _ _ ";
            string sb234red = "1";
            string sb235 = " _ ";
            string sb236red = "5";
            string sb237 = "\n\t\t\t8  ";
            string sb238red = "4";
            string sb239 = " _ _ ";
            string sb240red = "9";
            string sb241 = " _ _ ";
            string sb242red = "7";
            string sb243 = " _ _\n\t\t\t9  _ ";
            string sb244red = "9 1";
            string sb245 = " _ _ _ _ _ _\n\n\t\t\tWould like to\n \n\t\t\t1) Enter a value (ENTER)\n\t\t\t2) Delete a value (DELETE) \n\t\t\t3) Reset the board (RESET)" +
                "\n\t\t\t4) Check your answer (CHECK) \n\t\t\t5) Save the Game (SAVE)\n\t\t\t6) Exit to Main Menu (EXIT)\n\n\tCommand> \n\t\t          (Press Enter to Continue)\n\n";

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
            StringBuilder sb4 = new StringBuilder();
            StringBuilder sb5 = new StringBuilder();

            sb1.Append("\n\t\t\t    Welcome to My Sudoku!\n\nMy Sudoku is a logic based, combinatorial number placement puzzle. The \n");
            sb1.Append("objective is to fill a 9×9 grid with digits so that each column, each row, ");
            sb1.Append("and \neach of the nine 3×3 sub-grids that compose the grid contain all of the digits \nfrom 1 through 9.\n\n");
            sb1.Append("This program uses a command-line interface. The interface will look like as \nfollows:\n\n");
            sb1.Append("\n\t\t         (Press Enter To Continue)\n\n");

            sb3.Append("\n\n\t\t             This is the X-Axis\n\t\tT\n\t\th\n\t\ti\n\t\ts\n\n\n\t\ti\n\t\ts\n\t\t\n\t\tt\n\t\th\n\t\te\n\t\t\n\t\tY\n\t\t\n\t\tA\n\t\tx\n\t\ti\n\t\ts\n");
            sb3.Append("\n\t\t          (Press Enter to Continue)\n\n");

            sb4.Append("At this point you can enter 1 or the command ENTER to enter a value. You will ");
            sb4.Append("\nbe asked to enter the x and y coordinates and the value. Please note that \nhints ");
            sb4.Append("are provided by the game and displayed in red. These values cannot be \nupdated or ");
            sb4.Append("deleted. For values which can be edited your entry will appear on \nthe board.\n\n");
            sb4.Append("If you enter 2 or the command DELETE you will be asked to enter the x and y \ncoordinate for the the value you would like to delete. ");
            sb4.Append("As noted above, values \nin red cannot be deleted. Once you have made a selection, the value will be \ndeleted.\n\n");
            sb4.Append("If you enter 3 or the command RESET you will remove ");
            sb4.Append("all answers you have \nsubmitted and return the board to its original state.\n");
            sb4.Append("\n\t\t          (Press Enter to Continue)\n\n");


            sb5.Append("Once you feel you have completed the puzzle you can enter 4 or the command \nCHECK and the game will ");
            sb5.Append("verify if your answer is correct. If so your score will be tabulated and ");
            sb5.Append("if not the game continues. Additionally, you may receive hints towards the right answer depending ");
            sb5.Append("on the difficulty level you have chosen.\n\n");
            sb5.Append("If you enter 5 or the command SAVE you can save your game.\n\n");
            sb5.Append("At anytime you may enter 6 or the command EXIT to return to the main menu.\n\nGood Luck!\n");
            sb5.Append("\n\t\t          (Press Enter to Continue)\n\n");

            Console.WriteLine(sb1.ToString());

            Console.ReadLine();
            Console.Clear();

            Console.SetWindowSize(80, 27);

            Console.Write(sb201);
            var _previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb202red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb203);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb204red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb205);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb206red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb207);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb208red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb209);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb210red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb211);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb212red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb213);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb214red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb215);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb216red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb217);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb218red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb219);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb220red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb221);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb222red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb223);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb224red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb225);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb226red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb227);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb228red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb229);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb230red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb231);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb232red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb233);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb234red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb235);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb236red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb237);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb238red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb239);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb240red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb241.ToString());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb242red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb243);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb244red);
            Console.ForegroundColor = _previousColor;
            Console.Write(sb245);

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine(sb3.ToString());

            Console.ReadLine();
            Console.Clear();

            Console.SetWindowSize(80, 20);

            Console.WriteLine(sb4.ToString());

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine(sb5.ToString());

            Console.ReadLine();
        }
        #endregion

        #region GameScreen()
        /// <summary>
        /// This is the gameboard to display the matrix
        /// </summary>
        /// <param name="elementList">The list of elements</param>
        /// <param name="sb">The users responses</param>
        public void GameScreen(List<Element> elementList, StringBuilder sb)
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 27);

            Console.Write("\t\t\t       MY SUDOKU");
            Console.Write("\n\n\t\t\t   1 2 3 4 5 6 7 8 9\n");
            Console.Write("\n\t\t\t1  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(0, 8).Select(e => e)), sb.ToString(0, 17));
            Console.Write("\n\t\t\t2  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(9, 17).Select(e => e)), sb.ToString(18, 17));
            Console.Write("\n\t\t\t3  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(18, 26).Select(e => e)), sb.ToString(36, 17));
            Console.Write("\n\t\t\t4  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(27, 35).Select(e => e)), sb.ToString(54, 17));
            Console.Write("\n\t\t\t5  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(36, 44).Select(e => e)), sb.ToString(72, 17));
            Console.Write("\n\t\t\t6  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(45, 53).Select(e => e)), sb.ToString(90, 17));
            Console.Write("\n\t\t\t7  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(54, 62).Select(e => e)), sb.ToString(108, 17));
            Console.Write("\n\t\t\t8  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(63, 71).Select(e => e)), sb.ToString(126, 17));
            Console.Write("\n\t\t\t9  ");
            DisplayRow(new List<Element>(elementList.ReturnSublist(72, 80).Select(e => e)), sb.ToString(144, 17));
            Console.Write("\n\n\t\t\tWould like to\n \n\t\t\t1) Enter a value (ENTER)");
            Console.Write("\n\t\t\t2) Delete a value (DELETE) \n\t\t\t3) Reset the board (RESET)");
            Console.Write("\n\t\t\t4) Check your answer (CHECK) \n\t\t\t5) Save the Game (SAVE)");
            Console.Write("\n\t\t\t6) Exit to Main Menu (EXIT)\n");
            Console.Write("\n\tCommand> ");
        }
        #endregion

        #region DisplayRow()
        /// <summary>
        /// Displays the string on the game screen
        /// </summary>
        /// <param name="elementList">Applicable subset of the elementList</param>
        /// <param name="s">Applicable subset of the StringBuilder</param>
        private static void DisplayRow(List<Element> elementList, String s)
        {
            for (int i = 0; i < elementList.Count; i++)
            {
                int i2 = i * 2;

                if (elementList[i].DisplayHint == true)
                {
                    var _previousColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(s.ElementAt(i2) + " ");
                    Console.ForegroundColor = _previousColor;
                }
                else
                {
                    Console.Write(s.ElementAt(i2) + " ");
                }
            }
        }
        #endregion

        #region CreateNewGameScreen(out string userName, out SudokuConsoleGame.Difficulty difficulty)
        /// <summary>
        /// This screen helps the user create a new game
        /// </summary>
        /// <param name="userName">Output user name</param>
        /// <param name="difficulty">Output user difficulty</param>
        public void CreateNewGameScreen(out string userName, out SudokuConsoleGame.Difficulty difficulty)
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            // Default game to medium
            difficulty = SudokuConsoleGame.Difficulty.MEDIUM;

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            sb1.Append("\n\t\t\t       Create New Game\n");
            sb1.Append("\nEnter Your Name: ");

            sb2.Append("\n\nYou must choose a valid difficulty level or number:");
            sb2.Append("\n\t1 or \"STEADY SLOTH\"\n\t2 or \"LEAPING LEMUR\"\n\t3 or \"MIGHTY MOUNTAIN LION\"");
            sb2.Append("\n\nEnter Your Difficulty Level: ");

            Console.Write(sb1);

            userName = Console.ReadLine();

            // Determine if the difficulty level is valid
            bool validDifficulty = false;

            do
            {
                Console.Write(sb2);

                string level = Console.ReadLine();

                // Ensure that level is case insensitive
                level = level.ToUpper();

                if (level == "1" || level == "STEADY SLOTH")
                {
                    difficulty = SudokuConsoleGame.Difficulty.EASY;
                    validDifficulty = true;
                }
                else if (level == "2" || level == "LEAPING LEMUR")
                {
                    difficulty = SudokuConsoleGame.Difficulty.MEDIUM;
                    validDifficulty = true;
                }
                else if (level == "3" || level == "MIGHTY MOUNTAIN LION")
                {
                    difficulty = SudokuConsoleGame.Difficulty.HARD;
                    validDifficulty = true;
                }
                else
                    Console.Write("\nPlease enter a valid difficulty level.");
            }
            while (validDifficulty == false);

            Console.WriteLine("\nGood Luck and Have Fun!\n\n\t\t          (Press Enter to Continue)");
            Console.ReadLine();
        }
        #endregion

        #region LoadGameScreen(SavedGameRepository savedGameRepository, ref SudokuConsoleGame game)
        /// <summary>
        /// This screen helps the user load a saved game
        /// </summary>
        /// <param name="savedGameRepository">Intakes the saved game repository</param>
        /// <param name="game">Outputs a saved game</param>
        public void LoadGameScreen(SavedGameRepository savedGameRepository, ref SudokuConsoleGame game)
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            // String that represents the user's choice
            string usersChoice;

            // Create a list of saved games from which to load the game
            List<SudokuConsoleGame> savedGames = new List<SudokuConsoleGame>();

            // Set the list equal to the saved games from the repository
            savedGames = savedGameRepository.SavedGames.Where(g => g.Score == 0).OrderBy(g => g.DateCreated).Select(g => g).ToList<SudokuConsoleGame>();

            // Loading Screen Header
            string loadingScreenHeader = "\n\t\t\t        Load Saved Game\n\n";

            // Determine if choice is valid
            bool validChoice = false;

            // If no games are saved display the following
            if (savedGames.Count == 0)
            {
                Console.Write(loadingScreenHeader);

                Console.WriteLine("\t\t\t      No Games Are Saved!\n\n\t\t      (Press Enter to Return to Main Menu)");
                game = null;

                Console.ReadLine();
            }
            // If there are ten or fewer games
            else if (savedGames.Count <= 10)
            {
                Console.Write(loadingScreenHeader);

                for (int i = 0; i < savedGames.Count; i++)
                {
                    if (i < 9)
                        Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", i + 1, savedGames[i].UserName, savedGames[i].DateCreated, savedGames[i].GameDifficulty);
                    else
                        Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", i + 1, savedGames[i].UserName, savedGames[i].DateCreated, savedGames[i].GameDifficulty);
                }

                Console.Write("\nPlease enter " + (savedGames.Count == 1 ? "1 to load the game. Enter 2 for the main menu.\n\n" : "a valid number of 1 through {0} to load a game.  Enter {1} for the \n"),
                            savedGames.Count, savedGames.Count + 1);

                if (savedGames.Count > 1)
                {
                    Console.Write("main menu.\n\n");
                }

                do
                {
                    Console.Write("Command> ");
                    usersChoice = Console.ReadLine();

                    if (usersChoice.TryParse())
                    {
                        if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= savedGames.Count + 1)
                        {
                            if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= savedGames.Count)
                            {
                                game = savedGames[Convert.ToInt32(usersChoice) - 1];
                                Console.WriteLine("\nGood Luck and Have Fun!\n\n\t\t         (Press Enter to Continue)");
                                Console.ReadLine();
                                validChoice = true;
                            }
                            else if (Convert.ToInt32(usersChoice) == savedGames.Count + 1)
                            {
                                validChoice = true;
                                game = null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                        Console.ReadLine();
                    }
                }
                while (validChoice == false);
            }
            // If there are more than ten saved games
            if (savedGames.Count > 10)
            {
                // If more than 10 game are available this int will allow them to be displayed
                int moreThanTen = savedGames.Count / 10;

                // The final saved games
                int lessThanTen = savedGames.Count - (moreThanTen * 10);

                do
                {
                    for (int i = 0; i < (moreThanTen * 10); i = i + 10)
                    {
                        List<SudokuConsoleGame> sublist = savedGames.OrderBy(g => g.DateCreated).Skip(i).Take(10).ToList<SudokuConsoleGame>();
                        Console.Write(loadingScreenHeader);

                        for (int j = 0; j < sublist.Count; j++)
                        {
                            if (j < 9)
                                Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", j + 1, sublist[j].UserName, sublist[j].DateCreated, sublist[j].GameDifficulty);
                            else
                                Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", j + 1, sublist[j].UserName, sublist[j].DateCreated, sublist[j].GameDifficulty);
                        }

                        Console.Write("\nPlease enter a valid number of 1 through 10 to load a game.  Enter 11 for the \nnext page of saved games and 12 for the main menu.\n\n");

                        // Cycle through the first list of choices
                        bool subValidChoice = false;

                        do
                        {
                            Console.Write("Command> ");

                            usersChoice = Console.ReadLine();

                            if (usersChoice.TryParse())
                            {
                                if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) < 13)
                                {
                                    if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) < 11)
                                    {
                                        game = sublist[Convert.ToInt32(usersChoice) - 1];
                                        Console.WriteLine("\nGood Luck and Have Fun!\n\n\t\t         (Press Enter to Continue)");
                                        Console.ReadLine();
                                        subValidChoice = true;
                                        validChoice = true;
                                    }
                                    else if (Convert.ToInt32(usersChoice) == 11)
                                    {
                                        subValidChoice = true;
                                    }
                                    else if (Convert.ToInt32(usersChoice) == 12)
                                    {
                                        subValidChoice = true;
                                        validChoice = true;
                                        game = null;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid number from 1 through 12.\n\n\t\t         (Press Enter to Continue)");

                                }
                            }
                            else
                            {
                                Console.WriteLine("\nPlease enter a valid number from 1 through 12.\n\n\t\t         (Press Enter to Continue)");
                            }
                        }
                        while (subValidChoice == false);
                        Console.Clear();
                    }
                    if (validChoice == false)
                    {
                        // Cycle through the last list of games
                        bool finalChoice = false;

                        // For the remaining games
                        List<SudokuConsoleGame> finalList = savedGames.OrderBy(g => g.DateCreated).Skip(moreThanTen * 10).Take(lessThanTen).ToList<SudokuConsoleGame>();

                        Console.Write(loadingScreenHeader);

                        if (finalList.Count == 0)
                        {
                            Console.WriteLine("\t\t\t No More Games Are On The List!\n\n\t\t      (Press Enter to Return to Main Menu)");

                            Console.ReadLine();

                            game = null;
                            validChoice = true;
                        }
                        else
                        {
                            for (int i = 0; i < finalList.Count; i++)
                            {
                                if (i < 9)
                                    Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", i + 1, finalList[i].UserName, finalList[i].DateCreated, finalList[i].GameDifficulty);
                                else
                                    Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", i + 1, finalList[i].UserName, finalList[i].DateCreated, finalList[i].GameDifficulty);
                            }

                            Console.Write("\nPlease enter " + (finalList.Count == 1 ? "1 to load the game. Enter 2 for the main menu.\n\n" : "a valid number of 1 through {0} to load a game.  Enter {1} for the \n"),
                                        finalList.Count, finalList.Count + 1);

                            if (finalList.Count > 1)
                            {
                                Console.Write("main menu.\n\n");
                            }

                            do
                            {
                                Console.Write("Command> ");
                                usersChoice = Console.ReadLine();

                                if (usersChoice.TryParse())
                                {
                                    if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= finalList.Count + 1)
                                    {
                                        if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= finalList.Count)
                                        {
                                            game = savedGames[Convert.ToInt32(usersChoice) - 1];
                                            Console.WriteLine("\nGood Luck and Have Fun!\n\n\t\t         (Press Enter to Continue)");
                                            Console.ReadLine();
                                            finalChoice = true;
                                            validChoice = true;
                                        }
                                        else if (Convert.ToInt32(usersChoice) == finalList.Count + 1)
                                        {
                                            finalChoice = true;
                                            validChoice = true;
                                            game = null;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                                    Console.ReadLine();
                                }
                            }
                            while (finalChoice == false);
                        }
                    }
                }
                while (validChoice == false);
            }
        }
        #endregion

        #region DeleteGameScreen(SavedGameRepository savedGameRepository)
        /// <summary>
        /// The screen helps the user delete a saved game
        /// </summary>
        /// <param name="savedGameRepository">Intakes the saved game repository</param>
        public void DeleteGameScreen(SavedGameRepository savedGameRepository)
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            // Create a serializer
            Serializer serializer = new Serializer();

            // String that represents the user's choice
            string usersChoice;

            // Create a list of saved games from which to load the game
            List<SudokuConsoleGame> savedGames = new List<SudokuConsoleGame>();

            // Set the list equal to the saved games from the repository
            savedGames = savedGameRepository.SavedGames.OrderBy(g => g.DateCreated).ToList<SudokuConsoleGame>();

            // Deleting Screen Header
            string deletingScreenHeader = "\n\t\t\t       Delete Saved Game\n\n";

            // Determine if choice is valid
            bool validChoice = false;

            // If no games are saved display the following
            if (savedGames.Count == 0)
            {
                Console.Write(deletingScreenHeader);

                Console.WriteLine("\t\t\t      No Games Are Saved!\n\n\t\t      (Press Enter to Return to Main Menu)");

                Console.ReadLine();
            }
            // If there are ten or fewer games
            else if (savedGames.Count <= 10)
            {
                Console.Write(deletingScreenHeader);

                for (int i = 0; i < savedGames.Count; i++)
                {
                    if (i < 9)
                        Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", i + 1, savedGames[i].UserName, savedGames[i].DateCreated, savedGames[i].GameDifficulty);
                    else
                        Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", i + 1, savedGames[i].UserName, savedGames[i].DateCreated, savedGames[i].GameDifficulty);
                }

                Console.Write("\nPlease enter " + (savedGames.Count == 1 ? "1 to delete the game. Enter 2 for the main menu.\n\n" : "a valid number of 1 through {0} to delete a game.  Enter {1} for the \n"),
                            savedGames.Count, savedGames.Count + 1);

                if (savedGames.Count > 1)
                {
                    Console.Write("main menu.\n\n");
                }

                do
                {
                    Console.Write("Command> ");
                    usersChoice = Console.ReadLine();

                    if (usersChoice.TryParse())
                    {
                        if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= savedGames.Count + 1)
                        {
                            if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= savedGames.Count)
                            {
                                Console.Write("\n\t\t  Are you sure you want to delete this game?\n\nYes/No> ");

                                string confirmDelete = Console.ReadLine();

                                // Ensure response is case insensitive
                                confirmDelete = confirmDelete.ToUpper();

                                // Remove starting and trailing empty spaces
                                confirmDelete = confirmDelete.Trim();

                                if (confirmDelete == "YES" || confirmDelete == "Y")
                                {
                                    savedGames.RemoveAt(Convert.ToInt32(usersChoice) - 1);
                                    savedGameRepository.SavedGames = savedGames;
                                    serializer.SerializeRepository("SavedGames.dat", savedGameRepository);
                                    Console.WriteLine("\n\t\t        The game has been deleted.\n\n\t\t         (Press Enter to Continue)");
                                    Console.ReadLine();
                                    validChoice = true;
                                }
                                else
                                {
                                    Console.WriteLine();
                                }
                            }
                            else if (Convert.ToInt32(usersChoice) == savedGames.Count + 1)
                            {
                                validChoice = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                        Console.ReadLine();
                    }
                }
                while (validChoice == false);
            }
            // If there are more than ten saved games
            if (savedGames.Count > 10)
            {
                // If more than 10 game are available this int will allow them to be displayed
                int moreThanTen = savedGames.Count / 10;

                // The final saved games
                int lessThanTen = savedGames.Count - (moreThanTen * 10);

                do
                {
                    for (int i = 0; i < (moreThanTen * 10); i = i + 10)
                    {
                        List<SudokuConsoleGame> sublist = savedGames.OrderBy(g => g.DateCreated).Skip(i).Take(10).ToList<SudokuConsoleGame>();
                        Console.Write(deletingScreenHeader);

                        for (int j = 0; j < sublist.Count; j++)
                        {
                            if (j < 9)
                                Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", j + 1, sublist[j].UserName, sublist[j].DateCreated, sublist[j].GameDifficulty);
                            else
                                Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", j + 1, sublist[j].UserName, sublist[j].DateCreated, sublist[j].GameDifficulty);
                        }

                        Console.Write("\nPlease enter a valid number of 1 through 10 to delete a game.  Enter 11 for the next page of saved games and 12 for the main menu.\n\n");

                        // Cycle through the first list of choices
                        bool subValidChoice = false;

                        do
                        {
                            Console.Write("Command> ");

                            usersChoice = Console.ReadLine();

                            if (usersChoice.TryParse())
                            {
                                if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) < 13)
                                {
                                    if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) < 11)
                                    {
                                        Console.Write("\n\t\t  Are you sure you want to delete this game?\n\nYes/No> ");

                                        string confirmDelete = Console.ReadLine();

                                        // Ensure response is case insensitive
                                        confirmDelete = confirmDelete.ToUpper();

                                        // Remove starting and trailing empty spaces
                                        confirmDelete = confirmDelete.Trim();

                                        if (confirmDelete == "YES" || confirmDelete == "Y")
                                        {
                                            SudokuConsoleGame removeThis = sublist[Convert.ToInt32(usersChoice) - 1];
                                            savedGames.Remove(removeThis);
                                            savedGameRepository.SavedGames = savedGames;
                                            serializer.SerializeRepository("SavedGames.dat", savedGameRepository);
                                            Console.WriteLine("\n\t\t        The game has been deleted.\n\n\t\t         (Press Enter to Continue)");
                                            Console.ReadLine();
                                            subValidChoice = true;
                                            validChoice = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                        }
                                    }
                                    else if (Convert.ToInt32(usersChoice) == 11)
                                    {
                                        subValidChoice = true;
                                    }
                                    else if (Convert.ToInt32(usersChoice) == 12)
                                    {
                                        subValidChoice = true;
                                        validChoice = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid number from 1 through 12.\n\n\t\t         (Press Enter to Continue)");

                                }
                            }
                            else
                            {
                                Console.WriteLine("\nPlease enter a valid number from 1 through 12.\n\n\t\t         (Press Enter to Continue)");
                            }
                        }
                        while (subValidChoice == false);
                        Console.Clear();
                    }
                    if (validChoice == false)
                    {
                        // Cycle through the last list of games
                        bool finalChoice = false;

                        // For the remaining games
                        List<SudokuConsoleGame> finalList = savedGames.OrderBy(g => g.DateCreated).Skip(moreThanTen * 10).Take(lessThanTen).ToList<SudokuConsoleGame>();

                        Console.Write(deletingScreenHeader);

                        if (finalList.Count == 0)
                        {
                            Console.WriteLine("\t\t\t No More Games Are On The List!\n\n\t\t      (Press Enter to Return to Main Menu)");

                            Console.ReadLine();

                            validChoice = true;
                        }
                        else
                        {
                            for (int i = 0; i < finalList.Count; i++)
                            {
                                if (i < 9)
                                    Console.WriteLine("\t   {0})  {1}, Created: {2}, Difficulty: {3}", i + 1, finalList[i].UserName, finalList[i].DateCreated, finalList[i].GameDifficulty);
                                else
                                    Console.WriteLine("\t   {0}) {1}, Created: {2}, Difficulty: {3}", i + 1, finalList[i].UserName, finalList[i].DateCreated, finalList[i].GameDifficulty);
                            }

                            Console.Write("\nPlease enter " + (finalList.Count == 1 ? "1 to delete the game. Enter 2 for the main menu.\n\n" : "a valid number of 1 through {0} to delete a game.  Enter {1} for the \n"),
                                        finalList.Count, finalList.Count + 1);

                            if (finalList.Count != 1)
                            {
                                Console.Write("main menu.\n\n");
                            }

                            do
                            {
                                Console.Write("Command> ");
                                usersChoice = Console.ReadLine();

                                if (usersChoice.TryParse())
                                {
                                    if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= finalList.Count + 1)
                                    {
                                        if (Convert.ToInt32(usersChoice) > 0 && Convert.ToInt32(usersChoice) <= finalList.Count)
                                        {
                                            Console.Write("\n\t\t  Are you sure you want to delete this game?\n\nYes/No> ");

                                            string confirmDelete = Console.ReadLine();

                                            // Ensure response is case insensitive
                                            confirmDelete = confirmDelete.ToUpper();

                                            // Remove starting and trailing empty spaces
                                            confirmDelete = confirmDelete.Trim();

                                            if (confirmDelete == "YES" || confirmDelete == "Y")
                                            {
                                                SudokuConsoleGame removeThis = finalList[Convert.ToInt32(usersChoice) - 1];
                                                savedGames.Remove(removeThis);
                                                savedGameRepository.SavedGames = savedGames;
                                                serializer.SerializeRepository("SavedGames.dat", savedGameRepository);
                                                Console.WriteLine("\n\t\t        The game has been deleted.\n\n\t\t         (Press Enter to Continue)");
                                                Console.ReadLine();
                                                finalChoice = true;
                                                validChoice = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                            }
                                        }
                                        else if (Convert.ToInt32(usersChoice) == finalList.Count + 1)
                                        {
                                            finalChoice = true;
                                            validChoice = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter a valid number from 1 through {0}.\n\n\t\t         (Press Enter to Continue)", savedGames.Count + 1);
                                    Console.ReadLine();
                                }
                            }
                            while (finalChoice == false);
                        }
                    }
                }
                while (validChoice == false);
            }
        }
        #endregion

        #region LeaderboardScreen(SavedGameRepository savedGameRepository)
        /// <summary>
        /// This screen displays the top ten completed games
        /// </summary>
        /// <param name="savedGameRepository">Intakes the saved game repository</param>
        public void LeaderboardScreen(SavedGameRepository savedGameRepository)
        {
            Console.Title = "My Sudoku";
            Console.SetWindowSize(80, 20);

            // Create a list of saved games from which to load the game
            List<SudokuConsoleGame> savedGames = new List<SudokuConsoleGame>();

            // Set the list equal to the saved games from the repository
            savedGames = savedGameRepository.SavedGames.ToList<SudokuConsoleGame>();

            // Sort and pull the ten highest scoring games
            List<SudokuConsoleGame> topTenGames = savedGames.Where(g => g.Score > 0).OrderBy(g => g.Score).ToList<SudokuConsoleGame>();

            // Leaderboard Screen Header
            string leaderboardScreenHeader = "\n\t\t\t        Top Ten Games\n\n";

            // Leaderboard Closing Command
            string leaderboardClosing = "\n\t\t         (Press Enter to Continue)";

            Console.Write(leaderboardScreenHeader);

            if (topTenGames.Count > 0)
            {
                foreach (SudokuConsoleGame game in topTenGames)
                {
                    int i = 1;
                    Console.WriteLine("\t     {0})  {1}, Created: {2}, Score: {3}", i, game.UserName, game.DateCreated, game.Score);
                    ++i;
                }
            }
            else
            {
                Console.WriteLine("\t     There no games to review, get to work and have fun!");
            }

            Console.WriteLine(leaderboardClosing);
            Console.ReadLine();
        }
        #endregion

        #region VictoryScreen(SudokuConsoleGame game)
        /// <summary>
        /// This method displays the victory screen when the player wins!
        /// </summary>
        /// <param name="game">Takes the game as a parameter</param>
        public void VictoryScreen(SudokuConsoleGame game)
        {
            Console.Title = "YOU WIN!";
            Console.SetWindowSize(80, 27);

            string victoryString = "\n\n\n\n\n\n\n\n\n\t\t\t\t    ╔══════╗\n\t\t\t\t    ║ YOU  ║\n\t\t\t\t    ║ WIN! ║\n\t\t\t\t    ╚══════╝";

            var defaultColor = Console.ForegroundColor;

            for (int i = 0; i < 20; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(victoryString);

                Thread.Sleep(100);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(victoryString);

                Thread.Sleep(100);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(victoryString);

                Thread.Sleep(100);
                Console.Clear();
            }

            Console.ForegroundColor = defaultColor;

            Console.Write(victoryString);
            Console.WriteLine("\n\n\t\t\t   (Press Enter to Continue)");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\n\t\t\t  Congragulations {0},\n", game.UserName);
            Console.WriteLine("\n\t\t\t        You Won!\n");
            Console.WriteLine("\n\n\t\t\t    The solution was:\n");
            Console.Write("\n\t\t\t    " + game.SolutionString.Substring(0, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(17, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(35, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(53, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(71, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(89, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(107, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(125, 18));
            Console.Write("\n\t\t\t   " + game.SolutionString.Substring(143, 18));
            Console.Write("\n\n\t\t\t   Your score is {0}.", game.Score);
            Console.WriteLine("\n\n\t\t   (Press Enter to Return to Main Menu)");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }
}