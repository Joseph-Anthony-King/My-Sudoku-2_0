/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * SavedGameRepository.cs
 * 
 * This holds a reference to the games we want to serialize
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySudoku2_0
{
    /// <summary>
    /// This holds a reference to the games we want to serialize
    /// </summary>
    [Serializable()]
    public class SavedGameRepository : ISerializable
    {
        #region Fields and Properties
        // A private Field to hold the games
        private List<SudokuConsoleGame> _savedGames;

        // A public property to hold the games
        public List<SudokuConsoleGame> SavedGames
        {
            get { return this._savedGames; }
            set { this._savedGames = value; }
        }
        #endregion

        #region Constructors
        // A constructor used to access the class
        public SavedGameRepository()
        {
            _savedGames = new List<SudokuConsoleGame>();
        }

        // A constructor used to build the list from memory
        public SavedGameRepository(SerializationInfo info, StreamingContext context)
        {
            this._savedGames = (List<SudokuConsoleGame>)info.GetValue("SavedGames.dat", typeof(List<SudokuConsoleGame>));
        }
        #endregion

        #region ISerializable Member
        // The ISerializable Member
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SavedGames.dat", this._savedGames);
        }
        #endregion
    }
}