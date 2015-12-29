/**
 *
 * My Sudoku 2.0
 * By Joseph King
 * July 1, 2013
 *
 * Seralizer.cs
 *
 * A class to serialize and deserialize the saved game repository
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySudoku2_0
{
    /// <summary>
    /// A class to serialize and deserialize the saved game repository
    /// </summary>
    public class Serializer
    {
        #region Constructor
        /// <summary>
        /// A constructor used to access the class
        /// </summary>
        public Serializer()
        {

        }
        #endregion

        #region SerializeRepository(string fileName, SavedGameRepository savedGameRepository)
        /// <summary>
        /// A method to serialize the game repository
        /// </summary>
        /// <param name="filename">A string representation of the output file name</param>
        /// <param name="savedGameRepository">The saved game repository</param>
        public void SerializeRepository(string fileName, SavedGameRepository savedGameRepository)
        {
            string filePath = ObtainPathToDatFile(fileName);

            using (Stream stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (DeflateStream compressedStream = new DeflateStream(stream, CompressionMode.Compress))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    bFormatter.Serialize(compressedStream, savedGameRepository);
                }
            }
        }
        #endregion

        #region DeserializeRepository(string fileName)
        /// <summary>
        /// A method to deserialize the game repository
        /// </summary>
        /// <param name="filename">A string representation of the input file name</param>
        /// <returns>A SavedGameRepository object</returns>
        public SavedGameRepository DeserializeRepository(string fileName)
        {
            SavedGameRepository savedGameRepository = new SavedGameRepository();

            string filePath = ObtainPathToDatFile(fileName);

            using (Stream stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (DeflateStream decompressStream = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    if (stream.Length > 0)
                    {
                        savedGameRepository = (SavedGameRepository)bFormatter.Deserialize(decompressStream);
                    }
                }
            }

            return savedGameRepository;
        }
        #endregion

        #region ObtainPathToDatFile(string fileName)
        /// <summary>
        /// Private method to obtain the path to the local SaveGames file
        /// </summary>
        /// <param name="fileName">The name of the saved games file</param>
        /// <returns>The path to the saved games.</returns>
        private static string ObtainPathToDatFile(string fileName)
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string appPath = Path.Combine(localPath, "MySudoku2\\");

            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }

            string filePath = Path.Combine(appPath, fileName);
            return filePath;
        }
        #endregion
    }
}
