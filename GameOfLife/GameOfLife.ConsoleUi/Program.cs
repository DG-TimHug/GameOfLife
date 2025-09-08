namespace GameOfLife.ConsoleUi;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Conways Game of Life!");
        Console.WriteLine("Before starting lets set the playing field size");
        var windowWidth = GetWindowWidth();
        var windowHeight = GetWindowHeight();
        var board = new Board(windowWidth, windowHeight);
        for (var row1 = 0; row1 < board.PlayingField.GetLength(0); row1++)
        {
            for (var column = 0; column < board.PlayingField.GetLength(1); column++)
            {
                Console.Write(board.PlayingField[row1, column] ? "X  " : " X ");
            }
            Console.WriteLine();
        }
    }

    public static int GetWindowHeight()
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

    public static int GetWindowWidth()
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