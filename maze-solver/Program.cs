using System.IO;

namespace MazeSolver
{
    public class Program
    {
        /// <summary>
        ///     Reads a text file, expecting a Maze in it and returning it in a 2D-Array.
        ///     The outer walls are removed, so the returned array is 2 smaller in each dimension than the file
        ///     and position (0,0) is the first cell inside the border.
        ///     Syntax:
        ///         # -> Wall
        ///         . -> Floor
        ///         S -> Start
        ///         E -> End
        /// </summary>
        /// <param name="path">Path to file of the input file</param>
        /// <returns>Maze from the text file as 2D-Array, without the outer walls</returns>
        public static char[,] ReadMazeFile(string path)
        {
            if (!Path.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] fileLines = File.ReadAllLines(path);

            if (fileLines.Length < 3 || fileLines[0].Length < 3)
            {
                throw new ArgumentException("Maze must be at least 3x3 (walls around at least one cell).", nameof(path));
            }

            int rows = fileLines.Length - 2;
            int cols = fileLines[0].Length - 2;
            char[,] outputArray = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    outputArray[i, j] = fileLines[i + 1][j + 1];
                }
            }

            return outputArray;
        }

        /// <summary>
        ///     Finds the coordinates of a specific char in a maze.
        ///     This will only work for a single char. If the char searched for exists more than once it will return the position of the one closest to (0,0).
        /// </summary>
        /// <param name="maze">2D-Array of the maze</param>
        /// <param name="target">The char that is searched for</param>
        /// <returns>Tuple with position of found target, null if not found.</returns>
        public static Tuple<int, int>? FindChar(char[,] maze, char target)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (maze[row, col] == target)
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }

            return null;
        }

        static void Main()
        {
            string maze1Path = "/home/timon/_/work/coding/maze-solver/mazes/maze1.txt";
            Console.WriteLine(ReadMazeFile(maze1Path));

        }

    }
}