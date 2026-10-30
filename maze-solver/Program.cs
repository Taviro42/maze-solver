using System.IO;

namespace MazeSolver
{
    public class Program
    {
        /// <summary>
        ///     Reads a text file, expecting a Maze in it and returning it in a 2D-Array.
        ///     Syntax:
        ///         # -> Wall
        ///         . -> Floor
        ///         S -> Start
        ///         E -> End
        /// </summary>
        /// <param name="path">Path to file of the input file</param>
        /// <returns>Maze from the text file as 2D-Array</returns>
        public static char[,] ReadMazeFile(string path)
        {
            if (!Path.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] fileLines = File.ReadAllLines(path);
            char[,] outputArray = new char[fileLines.Length,fileLines[0].Length];

            for (int i = 0; i < fileLines.Length; i++)
            {
                for (int j = 0; j < fileLines[0].Length; j++)
                {
                    outputArray[i, j] = fileLines[i][j];
                }
            }

            return outputArray;
        }

        static void Main()
        {
            string maze1Path = "/home/timon/_/work/coding/maze-solver/mazes/maze1.txt";
            Console.WriteLine(ReadMazeFile(maze1Path));

        }

    }
}