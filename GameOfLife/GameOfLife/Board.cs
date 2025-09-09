namespace GameOfLife;

public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int height, int width, int aliveCellsPercent)
    {
        ValidateBoard(height, width, aliveCellsPercent);
        var height1 = height;
        PlayingField = GenerateRandomPlayingField(height, width, aliveCellsPercent);
    }

    private static bool[,] GenerateRandomPlayingField(int height, int width, int aliveCellsPrecent)
    {
        var playingField = new bool[height, width];
        var rand = new Random(42);
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                playingField[row, column] = rand.Next(100) < aliveCellsPrecent;
            }
        }
        
        return playingField;
    }

    private static void ValidateBoard(int height, int width, int aliveCellsPercent)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0");
        }

        if (aliveCellsPercent is <= 0 or >= 100)
        {
            throw new ArgumentOutOfRangeException(nameof(aliveCellsPercent), "Alive Cells must be between greater or equal to 0 and less or equal to 100.");
        }
    }

    private static void AmountOfNeighbor(bool[,] playingField)
    {
        var rows = playingField.GetLength(0);
        var columns = playingField.GetLength(1);
        
    }
    /*
    public static bool Alive()
    {
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                if (PlayingField[row, column])
                {
                   return true;
                }
            }
        }

        return false;
    }  */
}