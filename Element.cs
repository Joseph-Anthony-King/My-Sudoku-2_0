/**
 * 
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 * 
 * Element.cs
 * 
 * This class defines the elements of the sudoku matrix
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
    /// This class defines the elements of the sudoku matrix
    /// </summary>
    [Serializable()]
    public class Element : ISerializable
    {
        #region Properties
        // This property gets and sets the element's value
        public int Number { get; set; }

        // This property gets and sets the element's display hint
        public bool DisplayHint { get; set; }
        #endregion

        #region Constructors
        // The constructors
        public Element(int x, bool hint)
        {
            Number = x;
            DisplayHint = hint;
        }

        public Element(int x)
        {
            Number = x;
            DisplayHint = false;
        }

        // ISeriazable Constructor
        public Element(SerializationInfo info, StreamingContext context)
        {
            this.Number = (int)info.GetValue("Number", typeof(int));
            this.DisplayHint = (bool)info.GetValue("DisplayHint", typeof(bool));
        }

        public Element()
        {
            Number = 0;
            DisplayHint = false;
        }
        #endregion

        #region Element Methods
        // Override the ToString() method
        public override string ToString()
        {
            string s = Number.ToString();
            return s;
        }

        // A method to save the element in memory
        public string ToMemory()
        {
            string s = Number.ToString() + "|" + DisplayHint.ToString();
            return s;
        }
        #endregion

        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Number", this.Number);
            info.AddValue("DisplayHint", this.DisplayHint);
        }
        #endregion
    }
}
