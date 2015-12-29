/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * SudokuConsoleGame.cs
 * 
 * This class holds the game class instance properties and methods
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySudoku2_0
{
    /// <summary>
    /// This class holds the game class instance properties and methods
    /// </summary>
    [Serializable()]
    public class SudokuConsoleGame : ISerializable, IComparer<SudokuConsoleGame>
    {
        #region Difficulty Enumeration
        /// <summary>
        /// An enumeration of the difficulty level
        /// </summary>
        public enum Difficulty { EASY, MEDIUM, HARD };
        #endregion

        #region Properties
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User Number
        /// </summary>
        private int UserNumber { get; set; }

        /// <summary>
        /// Difficulty level
        /// </summary>
        public Difficulty GameDifficulty { get; set; }

        /// <summary>
        /// Date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Game Name
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// The sudoku matrix
        /// </summary>
        public List<int> SudokuSolution { get; set; }

        /// <summary>
        /// String that holds the list of integers
        /// </summary>
        public string SolutionString { get; set; }

        /// <summary>
        /// List of element objects
        /// </summary>
        public List<Element> ElementList { get; set; }

        /// <summary>
        /// StringBuilder to hold the element list for processing
        /// </summary>
        public StringBuilder ElementSB { get; set; }

        /// <summary>
        /// Integer that determines the amount of elements that will be displayed
        /// </summary>
        public int Display { get; set; }

        /// <summary>
        /// The user's score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The ticks that have elapsed since the game started
        /// </summary>
        public int Ticks { get; set; }

        /// <summary>
        /// Negative points assessed against the user
        /// </summary>
        public int Demerits { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor builds a new game
        /// </summary>
        /// <param name="level">Enumeration of the difficulty level</param>
        /// <param name="user">String that represents the users name</param>
        public SudokuConsoleGame(string user, Difficulty level)
        {
            UserName = user;
            GameDifficulty = level;
            DateCreated = DateTime.Now;
            UserNumber = SudokuUtilities._random.Next(100000);
            GameName = (UserName + UserNumber.ToString()).GetHashCode().ToString();
            SudokuSolution = SudokuUtilities.SudokuGenerator();
            ElementList = new List<Element>();
            ElementSB = new StringBuilder();

            // Load the solution string which will be used to test the users solution
            foreach (int _number in SudokuSolution)
            {
                SolutionString = SolutionString + _number + " ";
            }

            // Load the element list with elements based on the solution string
            foreach (int _element in SudokuSolution)
            {
                Element element = new Element(_element);
                ElementList.Add(element);
            }

            // Determine the amount of elements which will be displayed
            if (GameDifficulty == Difficulty.EASY)
                Display = 36;
            else if (GameDifficulty == Difficulty.MEDIUM)
                Display = 32;
            else if (GameDifficulty == Difficulty.HARD)
                Display = 27;

            // Set the amount of hints the user will receive
            for (int i = 0; i < Display; )
            {
                int j = SudokuUtilities._random.Next(0, ElementList.Count - 1);

                if (ElementList[j].DisplayHint == false)
                {
                    ElementList[j].DisplayHint = true;
                    i++;
                }
            }

            // Convert the element list into a StringBuilder
            // This StringBuilder is passed to the diplay to build the game board
            // This also records the users entries
            foreach (Element element in ElementList)
            {
                if (element.DisplayHint == true)
                {
                    ElementSB.Append(element.ToString() + " ");
                }
                else
                {
                    ElementSB.Append("_ ");
                }
            }

            // Initialize score to 0
            Score = 0;

            // Initialize the ticks to 0
            Ticks = 0;

            // Initialize demerits to 0
            Demerits = 0;
        }

        /// <summary>
        /// A parameterless constructor for building a game from memory
        /// </summary>
        public SudokuConsoleGame(SerializationInfo info, StreamingContext ctxt)
        {
            this.GameName = (string)info.GetValue("GameName", typeof(string));
            this.UserName = (string)info.GetValue("UserName", typeof(string));
            this.GameDifficulty = (Difficulty)info.GetValue("GameDifficulty", typeof(Difficulty));
            this.DateCreated = (DateTime)info.GetValue("DateCreated", typeof(DateTime));
            this.SudokuSolution = (List<int>)info.GetValue("SudokuSolution", typeof(List<int>));
            this.ElementList = (List<Element>)info.GetValue("ElementList", typeof(List<Element>));
            this.ElementSB = (StringBuilder)info.GetValue("ElementSB", typeof(StringBuilder));
            this.Display = (int)info.GetValue("Display", typeof(int));
            this.Score = (int)info.GetValue("Score", typeof(int));
            this.Ticks = (int)info.GetValue("Ticks", typeof(int));
            this.Demerits = (int)info.GetValue("Demerits", typeof(int));
        }

        /// <summary>
        /// A parameterless constructor
        /// </summary>
        public SudokuConsoleGame()
        {
            UserName = "Player";
            GameDifficulty = Difficulty.MEDIUM;
            DateCreated = DateTime.Now;
            UserNumber = SudokuUtilities._random.Next(100000);
            GameName = (UserName + UserNumber.ToString()).GetHashCode().ToString();
            SudokuSolution = SudokuUtilities.SudokuGenerator();
            ElementList = new List<Element>();
            ElementSB = new StringBuilder();

            // Load the solution string which will be used to test the users solution
            foreach (int _number in SudokuSolution)
            {
                SolutionString = SolutionString + _number + " ";
            }

            // Load the element list with elements based on the solution string
            foreach (int _element in SudokuSolution)
            {
                Element element = new Element(_element);
                ElementList.Add(element);
            }

            // Determine the amount of elements which will be displayed
            if (GameDifficulty == Difficulty.EASY || GameDifficulty == Difficulty.MEDIUM)
                Display = 36;
            else if (GameDifficulty == Difficulty.HARD)
                Display = 27;

            // Set the amount of hints the user will receive
            for (int i = 0; i < Display; )
            {
                int j = SudokuUtilities._random.Next(0, ElementList.Count - 1);

                if (ElementList[j].DisplayHint == false)
                {
                    ElementList[j].DisplayHint = true;
                    i++;
                }
            }

            // Convert the element list into a StringBuilder
            // This StringBuilder is passed to the diplay to build the game board
            // This also records the users entries
            foreach (Element element in ElementList)
            {
                if (element.DisplayHint == true)
                {
                    ElementSB.Append(element.ToString() + " ");
                }
                else
                {
                    ElementSB.Append("_ ");
                }
            }

            // Initialize score to 0
            Score = 0;

            // Initialize the ticks to 0
            Ticks = 0;

            // Initialize demerits to 0
            Demerits = 0;
        }
        #endregion

        #region Play(ref List<SudokuConsoleGame> savedGames)
        /// <summary>
        /// This method runs the game
        /// </summary>
        /// <param name="savedGames">Intakes the List of SudokuConsoleGames</param>
        public void Play(ref List<SudokuConsoleGame> savedGames)
        {
            #region Play Fields
            // Determines if the user keeps playing
            bool _continue = true;

            // This field stores the user's command
            string _command;
            #endregion

            // Instantiate a screen instance
            DisplayScreens screen = new DisplayScreens();

            // Instantiate a game stopwatch, this is used to calculate the score
            Stopwatch gameStopWatch = new Stopwatch();

            // Start the stopwatch
            gameStopWatch.Start();

            #region The Game Loop
            // The game loop
            do
            {
                // Load the game screen
                screen.GameScreen(ElementList, ElementSB);

                // Intake the users command
                _command = Console.ReadLine();

                // Convert user command to uppercase so its case insensitive
                _command = _command.ToUpper();

                // Remove starting and trailing empty spaces
                _command = _command.Trim();

                #region Enter or Delete Command
                // These commands allow the user to enter and delete a value
                // The code to select the x and y coordinate is the same for each value
                // The initial choice from the user determines if this is an update or delete
                if (_command.Equals("1") || _command.Equals("ENTER") || _command.Equals("2") || _command.Equals("DELETE")) // If user command equals 1 or ENTER
                {
                    // bool to test if the x coordinate is valid
                    bool _continueX = true;
                    do
                    {
                        Console.Write("\n\tEnter the X Coordinate> ");
                        string _xValue = Console.ReadLine();
                        if (_xValue.TryParse())
                        {
                            int _xInt = Convert.ToInt32(_xValue);

                            if (_xInt > 0 && _xInt < 10)
                            {
                                bool _continueY = true;
                                do
                                {
                                    Console.Write("\n\tEnter the Y Coordinate> ");
                                    string _yValue = Console.ReadLine();

                                    if (_yValue.TryParse())
                                    {
                                        int _yInt = Convert.ToInt32(_yValue);

                                        if (_yInt > 0 && _yInt < 10)
                                        {
                                            // The indexer to change the string
                                            int indexer;

                                            // The indexer to access the element from the element string
                                            int indexer2;

                                            // The x value will be transformed to a
                                            int a = 0;

                                            // The y value will be transformed to b
                                            int b = 0;

                                            // The b2 value is required to index the element
                                            int b2 = 0;

                                            // Transform x into a
                                            for (int i = 1; i < _xInt; i++)
                                            {
                                                a = a + 2;
                                            }

                                            // Transform y int b
                                            for (int i = 1; i < _yInt; i++)
                                            {
                                                b = b + 18;
                                            }

                                            // Transform y int b2
                                            for (int i = 1; i < _yInt; i++)
                                            {
                                                b2 = b2 + 9;
                                            }

                                            // Add a and b to ascertain the indexer
                                            indexer = a + b;

                                            // Add _xInt and b2 to ascertain indexer2
                                            indexer2 = _xInt + b2 - 1;

                                            if (ElementList[indexer2].DisplayHint == false)
                                            {
                                                bool _userEntryInvalid = true;

                                                do
                                                {
                                                    if (_command.Equals("1") || _command.Equals("ENTER"))
                                                    {
                                                        Console.Write("\n\tEnter a number from 1 through 9> ");
                                                        string _userEntry = Console.ReadLine();

                                                        if (_userEntry.TryParse())
                                                        {
                                                            int _userInt = Convert.ToInt32(_userEntry);

                                                            if (_userInt > 0 && _userInt < 10)
                                                            {
                                                                ElementSB.Remove(indexer, 1);
                                                                ElementSB.Insert(indexer, _userEntry);
                                                                Console.Clear();
                                                                _continueX = false;
                                                                _continueY = false;
                                                                _userEntryInvalid = false;
                                                            }
                                                            else
                                                            {
                                                                InvalidCoordinate();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            InvalidCoordinate();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ElementSB.Remove(indexer, 1);
                                                        ElementSB.Insert(indexer, "_");
                                                        Console.Clear();
                                                        _continueX = false;
                                                        _continueY = false;
                                                        _userEntryInvalid = false;

                                                    }
                                                }
                                                while (_userEntryInvalid);
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n\tThis value is a hint provided by the system and cannot be changed.");
                                                Console.WriteLine("\tPlease try again.\n\n\t\t         (Press Enter to Continue)");
                                                Console.ReadLine();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            InvalidCoordinate();
                                        }
                                    }
                                }
                                while (_continueY == true);
                            }
                            else
                            {
                                InvalidCoordinate();
                            }
                        }
                        else
                        {
                            InvalidCommand();
                        }
                    }
                    while (_continueX == true);
                }
                #endregion

                #region Reset Command
                // This command allows the user to reset the board
                else if (_command.Equals("3") || _command.Equals("RESET")) // If user command equals 3 or RESET
                {
                    ClearSolution(ElementSB, ElementList);
                    Console.Clear();
                }
                #endregion

                #region Check Command
                // This command allows the user to check his answer
                else if (_command.Equals("4") || _command.Equals("CHECK")) // If user command equals 4 or CHECK
                {
                    // Stop the gameStopWatch
                    gameStopWatch.Stop();

                    // Save the elapsed seconds to ticks
                    Ticks = Ticks + gameStopWatch.Elapsed.Seconds;

                    // Reset the gameStopWatch
                    gameStopWatch.Reset();

                    // Determine if the user wins!
                    if (SolutionString.Equals(ElementSB.ToString()))
                    {
                        // Calculate the score
                        Score = CalculateSolution();

                        // Save the score
                        if (savedGames.Contains(this))
                        {
                            // If the game was previously in the list, remove the old reference
                            savedGames.Remove(this);
                        }

                        // Add the game to the list and sort by DateCreated property
                        savedGames.Add(this);
                        //savedGames.Sort();

                        // Create the saved game repository
                        SavedGameRepository savedGameRepository = new SavedGameRepository();

                        // Set the saved game repository list equal to savedGames
                        savedGameRepository.SavedGames = savedGames;

                        // Save the game
                        Serializer serialize = new Serializer();
                        serialize.SerializeRepository("SavedGames.dat", savedGameRepository);

                        Console.Clear();
                        screen.VictoryScreen(this);
                        _continue = false;
                    }
                    else
                    {
                        // If the difficulty level is easy or medium the game provides hints
                        if (GameDifficulty == Difficulty.EASY || GameDifficulty == Difficulty.MEDIUM)
                        {
                            // If the solution is not correct the keeps the correct responses from the user
                            Console.WriteLine("\n\tClose but no cigar!\n\n\t\t         (Press Enter to Continue)");
                            Console.ReadLine();
                            Console.WriteLine("\tHere, I'll help you out and show you were you're right.\n\n\t\t         (Press Enter to Continue)");
                            Console.ReadLine();

                            if (GameDifficulty == Difficulty.EASY)
                            {
                                // Turns the claimant's solution to a string
                                string _assistanceString = ElementSB.ToString();

                                // Turns the solution to a char array
                                char[] _solutionArray = SolutionString.ToCharArray();

                                // Turns the user's solution to a char array
                                char[] _assistanceArray = _assistanceString.ToCharArray();

                                // If the value in the user's char array is incorrect its converted to "_"
                                for (int i = 0; i < _assistanceString.Length; i++)
                                {
                                    if (_solutionArray[i] != _assistanceArray[i])
                                    {
                                        _assistanceArray[i] = '_';
                                    }

                                }

                                // Clears the user's response
                                ElementSB.Clear();

                                // Refills the element string builder with the corrected array
                                foreach (char a in _assistanceArray)
                                {
                                    ElementSB.Append(a);
                                }

                                // Add 100 Demerits
                                Demerits = Demerits + 200;

                                Console.Clear();
                            }
                            else if (GameDifficulty == Difficulty.MEDIUM)
                            {
                                int _correctAnswers = 0;

                                for (int i = 0; i < SudokuSolution.Count; i++)
                                {
                                    int j = i * 2;

                                    if (ElementSB.ToString().TryParse())
                                    {
                                        if (Convert.ToInt32(ElementSB.ToString().ElementAt(j)) == SudokuSolution.ElementAt(i))
                                        {
                                            ++_correctAnswers;
                                        }
                                    }
                                }

                                Console.WriteLine("\n\t{0} of your answers are correct.\n\n\tPlease try again.\n\n\t\t         (Press Enter to Continue");

                                // Add 10 Demerits
                                Demerits = Demerits + 100;

                                Console.Clear();
                            }
                        }

                        // If the difficulty level is hard the game does not provide hints
                        else if (GameDifficulty == Difficulty.HARD)
                        {
                            Console.WriteLine("\n\tClose but no cigar!\n\tTry again!\n\n\t\t         (Press Enter to Continue)");
                            Console.ReadLine();

                            Console.Clear();
                        }

                        // Restart the gameStopWatch
                        gameStopWatch.Start();
                    }
                }
                #endregion

                #region Save Command
                // This command allows the user to save the game
                else if (_command.Equals("5") || _command.Equals("SAVE")) // If user command equals 5 or SAVE
                {
                    // Stop the gameStopWatch
                    gameStopWatch.Stop();

                    // Save the elapsed seconds to ticks
                    Ticks = Ticks + gameStopWatch.Elapsed.Seconds;

                    // Reset the gameStopWatch
                    gameStopWatch.Reset();

                    if (savedGames.Contains(this))
                    {
                        // If the game was previously in the list, remove the old reference
                        savedGames.Remove(this);
                    }

                    // Add the game to the list and sort by DateCreated property
                    savedGames.Add(this);
                    //savedGames.Sort();

                    // Create the saved game repository
                    SavedGameRepository savedGameRepository = new SavedGameRepository();

                    // Set the saved game repository list equal to savedGames
                    savedGameRepository.SavedGames = savedGames;

                    // Save the game
                    Serializer serialize = new Serializer();
                    serialize.SerializeRepository("SavedGames.dat", savedGameRepository);

                    Console.WriteLine("\n\tYour game has been saved.\n\n\t\t         (Press Enter to Continue)");
                    Console.ReadLine();
                    Console.Clear();

                    // Restart the gameStopWatch
                    gameStopWatch.Start();
                }
                #endregion

                #region Exit Command
                // This command allows the user to return to the main menu
                else if (_command.Equals("6") || _command.Equals("EXIT")) // If user command equals 6 of EXIT
                {
                    string exitGame = string.Empty;

                    Console.Write("\n\tPlease note that unsaved changes will be lost.\n\n\tDo you wish to return to the main menu?\n\n\tYes/No> ");

                    exitGame = Console.ReadLine();

                    // Ensure response is not case sensitive
                    exitGame = exitGame.ToUpper();

                    // Remove starting and trailing empty spaces
                    exitGame = exitGame.Trim();

                    if (exitGame.Equals("YES") || exitGame.Equals("Y"))
                    {
                        Console.WriteLine("\n\tReturning to main menu.\n\n\t\t   (Press Enter to Return to Main Menu)");
                        Console.ReadLine();
                        _continue = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                #endregion

                else
                {
                    // If the user fails to enter a valid command
                    Console.WriteLine("\n\tPlease enter a valid command.\n\n\t\t         (Press Enter to Continue)");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (_continue == true);
            #endregion
        }
        #endregion

        #region SudokuConsoleGame Methods
        #region InvalidCommand()
        /// <summary>
        /// This method is displayed if the user enters an invalid action
        /// </summary>
        private static void InvalidCommand()
        {
            Console.WriteLine("\n\tInvalid Command.");
            Console.WriteLine("\tPlease try again.\n\n\t\t         (Press Enter to Continue)");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion

        #region InvalidCoordinate()
        /// <summary>
        /// This method is displayed if user enters an invalid x value
        /// </summary>
        private static void InvalidCoordinate()
        {
            Console.WriteLine("\n\tYour response must be an integer 1 through 9.");
            Console.WriteLine("\tPlease try again.\n\n\t\t         (Press Enter to Continue)");
            Console.ReadLine();
        }
        #endregion

        #region ClearSolution(StringBuilder sb, List<Element> el)
        /// <summary>
        /// This method allows the game to clear the board
        /// </summary>
        /// <param name="sb">The StringBuilder which is reset</param>
        /// <param name="el">The list of elements is used to determine if a value is a hint or not</param>
        private static void ClearSolution(StringBuilder sb, List<Element> el)
        {
            sb.Clear();
            foreach (Element e in el)
            {
                if (e.DisplayHint == true)
                {
                    sb.Append(e.ToString() + " ");
                }
                else
                {
                    sb.Append("_ ");
                }
            }
            Console.Clear();
        }
        #endregion

        #region CalculateSolution()
        /// <summary>
        /// This method calculates the solution
        /// </summary>
        /// <returns>The Score property</returns>
        private int CalculateSolution()
        {
            int maxScore = 0;
            int result = 1;

            if (this.GameDifficulty == Difficulty.EASY)
                maxScore = 7200;
            else if (this.GameDifficulty == Difficulty.MEDIUM)
                maxScore = 14400;
            else if (this.GameDifficulty == Difficulty.HARD)
                maxScore = 28800;

            if ((Ticks + Demerits) > maxScore)
                result = 1;
            else
                result = maxScore - (Ticks + Demerits);

            return result;
        }
        #endregion
        #endregion

        #region Iseriablizable Members
        /// <summary>
        /// Implementation of the ISeriablizable Members
        /// </summary>
        /// <param name="info">SerializationInfo info</param>
        /// <param name="context">StreamingContext context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("GameName", this.GameName);
            info.AddValue("UserName", this.UserName);
            info.AddValue("GameDifficulty", this.GameDifficulty);
            info.AddValue("DateCreated", this.DateCreated);
            info.AddValue("SudokuSolution", this.SudokuSolution);
            info.AddValue("SolutionString", this.SolutionString);
            info.AddValue("ElementList", this.ElementList);
            info.AddValue("ElementSB", this.ElementSB);
            info.AddValue("Display", this.Display);
            info.AddValue("Score", this.Score);
            info.AddValue("Ticks", this.Ticks);
            info.AddValue("Demerits", this.Demerits);
        }
        #endregion

        #region IComparer Members
        /// <summary>
        /// A comparison method that compares games by the dates created
        /// </summary>
        /// <param name="x">SudokuConsoleGame one</param>
        /// <param name="y">SudokuConsoleGame two</param>
        /// <returns></returns>
        public int Compare(SudokuConsoleGame x, SudokuConsoleGame y)
        {
            return DateTime.Compare(x.DateCreated, y.DateCreated);
        }
        #endregion
    }
}
