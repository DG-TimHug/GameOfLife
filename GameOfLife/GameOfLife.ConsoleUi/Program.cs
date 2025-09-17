namespace GameOfLife.ConsoleUi;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to Conways Game of Life!");
        Console.WriteLine("Before starting lets set the playing field size");
        var boardWidth = GetWindowWidth();
        var boardHeight = GetWindowHeight();
        var aliveCellsPrecent = GetAliveCellsPercent();
        var board = new Board(boardHeight, boardWidth, aliveCellsPrecent);
        Console.Clear();
        Console.CursorVisible = false;
        do
        {
            for (var row = 0; row < board.PlayingField.GetLength(0); row++)
            {
                for (var column = 0; column < board.PlayingField.GetLength(1); column++)
                {
                    if (board.PlayingField[row, column])
                    {
                        PrintCellTrue();
                    }
                    else
                    {
                        PrintCellFalse();
                    }
                }

                Console.WriteLine();
            }
            //Thread.Sleep(10000);
            board.PrepareRules();
            Console.SetCursorPosition(0,0);
        } while (board.Alive());
        
        Console.WriteLine("Game over");
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
            Console.WriteLine("Please enter a number between 0 and 100..");
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
            Console.WriteLine("Please enter a number between 0 and 100..");
        }
    }

    private static int GetAliveCellsPercent()
    {
        while (true)
        {
            Console.WriteLine("How many Percent of cells should be alive (0% - 100%)?");
            if (int.TryParse(Console.ReadLine(), out var aliveCellsPercent) && aliveCellsPercent is >= 0 and <= 100)
            {
                return aliveCellsPercent;
            }
            Console.WriteLine("Please enter a number between 0 and 100..");
        }
    }

    private static void PrintCellTrue()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" ■ ");
        Console.ResetColor();
    }
    
    private static void PrintCellFalse()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" X ");
        Console.ResetColor();
    }
}