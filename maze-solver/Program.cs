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

        /// <summary>
        ///     Finds the coordinates of a specific char in a maze.
        ///     This will only work for a single char. If the char searched for exists more than once it will return the position of the one closest to (0,0).
        /// </summary>
        /// <param name="maze">2D-Array of the maze</param>
        /// <param name="target">The char that is searched for</param>
        /// <returns>Tuple with position of found target, (-1,-1) if not found.</returns>
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