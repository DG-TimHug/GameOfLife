namespace GameOfLife;

public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int width, int height, int aliveCellsPrecent)
    {
        
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0");
        }

        if (aliveCellsPrecent is <= 0 or >= 100)
        {
            throw new ArgumentOutOfRangeException(nameof(aliveCellsPrecent), "Alive Cells must be greater than 0");
        }
        PlayingField = new bool[height, width];
        var rand = new Random(42);
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                PlayingField[row, column] = rand.Next(100) < aliveCellsPrecent;
            }
        }
    }
}