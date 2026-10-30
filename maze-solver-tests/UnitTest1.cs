using MazeSolver;

namespace maze_solver_tests
{
    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        public void ReadMazeFile_ReadMaze1_Returns2dArray()
        {
            string maze1Path = "/home/timon/_/work/coding/maze-solver/mazes/maze1.txt";

            char[,] should_MazeArray = new char[5, 9]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', '.', '.', '#', '.', '.', '.', '#' },
                { '#', '.', '#', '.', '#', '.', '#', '.', '#' },
                { '#', '.', '#', '.', '.', '.', '#', 'E', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            char[,] is_mazeArray = Program.ReadMazeFile(maze1Path);

            Assert.AreSequenceEqual(should_MazeArray, is_mazeArray);
        }
    }
}
