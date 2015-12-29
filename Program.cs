/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * Program.cs
 * 
 * The main entry point for the game
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySudoku2_0
{
    class Program
    {
        /// <summary>
        /// The main entry point for the game
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SudokuConsoleGameLogic game = new SudokuConsoleGameLogic();
            game.Run();
        }
    }
}
