/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * SudokuUtilities.cs
 * 
 * The utilities class for the game
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySudoku2_0
{
    /// <summary>
    /// The utilities class for the game
    /// </summary>
    public static class SudokuUtilities
    {
        #region Random Number Generator
        /// <summary>
        /// Initiate a static random number generator
        /// </summary>
        public static Random _random = new Random();
        #endregion

        #region Shuffle<T>()
        /// <summary>
        /// This method shuffles elements in a list
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="list">Generic Type List</param>
        public static void Shuffle<T>(List<T> list)
        {
            var _randomShuffle = _random;

            for (int i = list.Count; i > 1; i--)
            {
                // Pick a random element to swap
                int j = _randomShuffle.Next(9);
                int k = _randomShuffle.Next(9);
                // Swap
                T tmp = list[j];
                list[j] = list[k];
                list[k] = tmp;
            }
        }
        #endregion

        #region ConvertStringArrayToString()
        /// <summary>
        /// Convert string arrays to strings
        /// </summary>
        /// <param name="array">String Array</param>
        /// <returns>String</returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
        #endregion

        #region SudokuGenerator()
        /// <summary>
        /// Generates a random sudoku matrix
        /// </summary>
        /// <returns>List of Integers</returns>
        public static List<int> SudokuGenerator()
        {
            // The maximum number of iterations before the generator resets
            const int MAX_ITERATIONS = 3265920;

            // This int keeps track of the iterations
            int iterations = 0;

            // The list of int that is returned by the method
            List<int> result = new List<int>();

            // The list of lists of int that is used for processing
            List<List<int>> sudokuMatrix = new List<List<int>>();

            // Create a list to hold a sequence of nine numbers
            List<int> _rangeOfNineNumbers = new List<int>();

            // Bool to determine if the matrix has been completed
            bool completed = false;

            // load the numbers
            for (int i = 1; i < 10; i++)
            {
                _rangeOfNineNumbers.Add(i);
            }

            do
            {
                // Reset iterations
                iterations = 0;

                // create the first row
                List<int> _firstRow = _rangeOfNineNumbers.ToList();

                Shuffle(_firstRow);

                // Create the second row
                List<int> _secondRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_secondRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Take(3).OrderBy(n => n))) ||
                    (_firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                // Create the third row
                List<int> _thirdRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_thirdRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Take(3).OrderBy(n => n))) ||
                    (_secondRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Take(3).OrderBy(n => n))) ||
                    (_firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_secondRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(6).Take(3).OrderBy(n => n))) ||
                    (_secondRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_thirdRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                // Rows four through nine require references to the columns

                // Create the first column
                List<int> _firstColumn = new List<int>();

                _firstColumn.Add(_firstRow[0]);
                _firstColumn.Add(_secondRow[0]);
                _firstColumn.Add(_thirdRow[0]);

                // Create the second column
                List<int> _secondColumn = new List<int>();

                _secondColumn.Add(_firstRow[1]);
                _secondColumn.Add(_secondRow[1]);
                _secondColumn.Add(_thirdRow[1]);

                // Create the third column
                List<int> _thirdColumn = new List<int>();

                _thirdColumn.Add(_firstRow[2]);
                _thirdColumn.Add(_secondRow[2]);
                _thirdColumn.Add(_thirdRow[2]);

                // Create the fourth column
                List<int> _fourthColumn = new List<int>();

                _fourthColumn.Add(_firstRow[3]);
                _fourthColumn.Add(_secondRow[3]);
                _fourthColumn.Add(_thirdRow[3]);

                // Create the fifth column
                List<int> _fifthColumn = new List<int>();

                _fifthColumn.Add(_firstRow[4]);
                _fifthColumn.Add(_secondRow[4]);
                _fifthColumn.Add(_thirdRow[4]);

                // Create the sixth column
                List<int> _sixthColumn = new List<int>();

                _sixthColumn.Add(_firstRow[5]);
                _sixthColumn.Add(_secondRow[5]);
                _sixthColumn.Add(_thirdRow[5]);

                // Create the seventh column
                List<int> _seventhColumn = new List<int>();

                _seventhColumn.Add(_firstRow[6]);
                _seventhColumn.Add(_secondRow[6]);
                _seventhColumn.Add(_thirdRow[6]);

                // Create the eighth column
                List<int> _eighthColumn = new List<int>();

                _eighthColumn.Add(_firstRow[7]);
                _eighthColumn.Add(_secondRow[7]);
                _eighthColumn.Add(_thirdRow[7]);

                // Create the ninth column
                List<int> _ninthColumn = new List<int>();

                _ninthColumn.Add(_firstRow[8]);
                _ninthColumn.Add(_secondRow[8]);
                _ninthColumn.Add(_thirdRow[8]);

                // Create the fourth row
                List<int> _fourthRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_fourthRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_fourthRow[0])) ||
                    (_secondColumn.Contains(_fourthRow[1])) ||
                    (_thirdColumn.Contains(_fourthRow[2])) ||
                    (_fourthColumn.Contains(_fourthRow[3])) ||
                    (_fifthColumn.Contains(_fourthRow[4])) ||
                    (_sixthColumn.Contains(_fourthRow[5])) ||
                    (_seventhColumn.Contains(_fourthRow[6])) ||
                    (_eighthColumn.Contains(_fourthRow[7])) ||
                    (_ninthColumn.Contains(_fourthRow[8]))
                    );

                _firstColumn.Add(_fourthRow[0]);
                _secondColumn.Add(_fourthRow[1]);
                _thirdColumn.Add(_fourthRow[2]);
                _fourthColumn.Add(_fourthRow[3]);
                _fifthColumn.Add(_fourthRow[4]);
                _sixthColumn.Add(_fourthRow[5]);
                _seventhColumn.Add(_fourthRow[6]);
                _eighthColumn.Add(_fourthRow[7]);
                _ninthColumn.Add(_fourthRow[8]);

                // Create the fifth row
                List<int> _fifthRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_fifthRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_fifthRow[0])) ||
                    (_secondColumn.Contains(_fifthRow[1])) ||
                    (_thirdColumn.Contains(_fifthRow[2])) ||
                    (_fourthColumn.Contains(_fifthRow[3])) ||
                    (_fifthColumn.Contains(_fifthRow[4])) ||
                    (_sixthColumn.Contains(_fifthRow[5])) ||
                    (_seventhColumn.Contains(_fifthRow[6])) ||
                    (_eighthColumn.Contains(_fifthRow[7])) ||
                    (_ninthColumn.Contains(_fifthRow[8])) ||
                    (_fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Take(3).OrderBy(n => n))) ||
                    (_fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_fifthRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                _firstColumn.Add(_fifthRow[0]);
                _secondColumn.Add(_fifthRow[1]);
                _thirdColumn.Add(_fifthRow[2]);
                _fourthColumn.Add(_fifthRow[3]);
                _fifthColumn.Add(_fifthRow[4]);
                _sixthColumn.Add(_fifthRow[5]);
                _seventhColumn.Add(_fifthRow[6]);
                _eighthColumn.Add(_fifthRow[7]);
                _ninthColumn.Add(_fifthRow[8]);

                // Create the sixth row
                List<int> _sixthRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_sixthRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_sixthRow[0])) ||
                    (_secondColumn.Contains(_sixthRow[1])) ||
                    (_thirdColumn.Contains(_sixthRow[2])) ||
                    (_fourthColumn.Contains(_sixthRow[3])) ||
                    (_fifthColumn.Contains(_sixthRow[4])) ||
                    (_sixthColumn.Contains(_sixthRow[5])) ||
                    (_seventhColumn.Contains(_sixthRow[6])) ||
                    (_eighthColumn.Contains(_sixthRow[7])) ||
                    (_ninthColumn.Contains(_sixthRow[8])) ||
                    (_fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Take(3).OrderBy(n => n))) ||
                    (_fifthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Take(3).OrderBy(n => n))) ||
                    (_fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_fifthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                    (_fifthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_sixthRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                _firstColumn.Add(_sixthRow[0]);
                _secondColumn.Add(_sixthRow[1]);
                _thirdColumn.Add(_sixthRow[2]);
                _fourthColumn.Add(_sixthRow[3]);
                _fifthColumn.Add(_sixthRow[4]);
                _sixthColumn.Add(_sixthRow[5]);
                _seventhColumn.Add(_sixthRow[6]);
                _eighthColumn.Add(_sixthRow[7]);
                _ninthColumn.Add(_sixthRow[8]);

                // Create the seventh row
                List<int> _seventhRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_seventhRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_seventhRow[0])) ||
                    (_secondColumn.Contains(_seventhRow[1])) ||
                    (_thirdColumn.Contains(_seventhRow[2])) ||
                    (_fourthColumn.Contains(_seventhRow[3])) ||
                    (_fifthColumn.Contains(_seventhRow[4])) ||
                    (_sixthColumn.Contains(_seventhRow[5])) ||
                    (_seventhColumn.Contains(_seventhRow[6])) ||
                    (_eighthColumn.Contains(_seventhRow[7])) ||
                    (_ninthColumn.Contains(_seventhRow[8]))
                    );

                _firstColumn.Add(_seventhRow[0]);
                _secondColumn.Add(_seventhRow[1]);
                _thirdColumn.Add(_seventhRow[2]);
                _fourthColumn.Add(_seventhRow[3]);
                _fifthColumn.Add(_seventhRow[4]);
                _sixthColumn.Add(_seventhRow[5]);
                _seventhColumn.Add(_seventhRow[6]);
                _eighthColumn.Add(_seventhRow[7]);
                _ninthColumn.Add(_seventhRow[8]);

                // Create the eighth row
                List<int> _eighthRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_eighthRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_eighthRow[0])) ||
                    (_secondColumn.Contains(_eighthRow[1])) ||
                    (_thirdColumn.Contains(_eighthRow[2])) ||
                    (_fourthColumn.Contains(_eighthRow[3])) ||
                    (_fifthColumn.Contains(_eighthRow[4])) ||
                    (_sixthColumn.Contains(_eighthRow[5])) ||
                    (_seventhColumn.Contains(_eighthRow[6])) ||
                    (_eighthColumn.Contains(_eighthRow[7])) ||
                    (_ninthColumn.Contains(_eighthRow[8])) ||
                    (_seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Take(3).OrderBy(n => n))) ||
                    (_seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_eighthRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                _firstColumn.Add(_eighthRow[0]);
                _secondColumn.Add(_eighthRow[1]);
                _thirdColumn.Add(_eighthRow[2]);
                _fourthColumn.Add(_eighthRow[3]);
                _fifthColumn.Add(_eighthRow[4]);
                _sixthColumn.Add(_eighthRow[5]);
                _seventhColumn.Add(_eighthRow[6]);
                _eighthColumn.Add(_eighthRow[7]);
                _ninthColumn.Add(_eighthRow[8]);

                // Create the nineth row
                List<int> _ninthRow = _rangeOfNineNumbers.ToList();

                do
                {
                    Shuffle(_ninthRow);
                    ++iterations;

                    if (iterations == MAX_ITERATIONS)
                        goto NEXT;
                }
                while (
                    (_firstColumn.Contains(_ninthRow[0])) ||
                    (_secondColumn.Contains(_ninthRow[1])) ||
                    (_thirdColumn.Contains(_ninthRow[2])) ||
                    (_fourthColumn.Contains(_ninthRow[3])) ||
                    (_fifthColumn.Contains(_ninthRow[4])) ||
                    (_sixthColumn.Contains(_ninthRow[5])) ||
                    (_seventhColumn.Contains(_ninthRow[6])) ||
                    (_eighthColumn.Contains(_ninthRow[7])) ||
                    (_ninthColumn.Contains(_ninthRow[8])) ||
                    (_seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Take(3).OrderBy(n => n))) ||
                    (_eighthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Take(3).OrderBy(n => n))) ||
                    (_seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_eighthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                    (_seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                    (_eighthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_ninthRow.Skip(6).Take(3).OrderBy(n => n)))
                    );

                _firstColumn.Add(_ninthRow[0]);
                _secondColumn.Add(_ninthRow[1]);
                _thirdColumn.Add(_ninthRow[2]);
                _fourthColumn.Add(_ninthRow[3]);
                _fifthColumn.Add(_ninthRow[4]);
                _sixthColumn.Add(_ninthRow[5]);
                _seventhColumn.Add(_ninthRow[6]);
                _eighthColumn.Add(_ninthRow[7]);
                _ninthColumn.Add(_ninthRow[8]);

                // Add the rows to result
                sudokuMatrix.Add(_firstRow);
                sudokuMatrix.Add(_secondRow);
                sudokuMatrix.Add(_thirdRow);
                sudokuMatrix.Add(_fourthRow);
                sudokuMatrix.Add(_fifthRow);
                sudokuMatrix.Add(_sixthRow);
                sudokuMatrix.Add(_seventhRow);
                sudokuMatrix.Add(_eighthRow);
                sudokuMatrix.Add(_ninthRow);

                if (iterations < MAX_ITERATIONS)
                {
                    completed = true;
                }
            NEXT: ;
            }
            while (completed == false);

            // Return the list of int lists
            return result = sudokuMatrix.SelectMany(row => row).ToList();
        }
        #endregion
    }
}
