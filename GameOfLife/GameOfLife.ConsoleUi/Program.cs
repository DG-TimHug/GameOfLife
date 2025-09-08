namespace GameOfLife.ConsoleUi;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to Conways Game of Life!");
        Console.WriteLine("Before starting lets set the playing field size");
        var windowWidth = GetWindowWidth();
        var windowHeight = GetWindowHeight();
        var board = new Board(windowWidth, windowHeight);
        for (var row = 0; row < board.PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < board.PlayingField.GetLength(1); column++)
            {
                Console.Write(board.PlayingField[row, column] ? "X  " : " X ");
            }
            Console.WriteLine();
        }
    }

    private static int GetWindowHeight()
    {
        while (true)
        {
            Console.WriteLine("How tall should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldHeight) && playingFieldHeight > 0)
            {
                return playingFieldHeight;
            }
            Console.WriteLine("Please enter a positive and full number.");
        }
    }

    private static int GetWindowWidth()
    {
        while (true)
        {
            Console.WriteLine("How wide should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldWidth) && playingFieldWidth > 0)
            {
                return playingFieldWidth;
            }
            Console.WriteLine("Please enter a positive and full number.");
        }
    }
}