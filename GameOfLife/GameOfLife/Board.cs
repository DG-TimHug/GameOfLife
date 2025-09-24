namespace GameOfLife;
/*
 * MASTER TO-DO:
 * 
 */
public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int height, int width, int aliveCellsPercent)
    {
        //ValidateBoard(height, width, aliveCellsPercent);
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
    /*
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
    } */
    
    public void AdvanceGeneration()
    {
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                PlayingField[row, column] = ApplyRules(GetNeighborCount(row, column), PlayingField[row, column]);
            }
        }
    }

    public static bool ApplyRules(int amountNeighbors, bool cellState)
    {
        if (cellState)
        {
            if (amountNeighbors < 2)
            {
                return false;
            }

            if (amountNeighbors is 2 or 3)
            {
                return true;
            }
        }
        else
        {
            if (amountNeighbors > 3)
            {
                return false;
            }
        }
        if (amountNeighbors == 3)
        {
            return true;
        }
        return false;
    }
    
    public bool IsGameAlive()
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
    }

    public int GetNeighborCount(int row, int column)
    {
        var amountNeighbors = 0;
        for (var rowoffset= -1; rowoffset <= 1 ; rowoffset++)
        {
            for (var columnOffSet = -1; columnOffSet <= 1 ; columnOffSet++)
            {
                if (rowoffset == 0 && columnOffSet == 0) continue;
                var newRow = row + rowoffset;
                var newColumn = column + columnOffSet;
                if (newRow < PlayingField.GetLength(0) && newColumn < PlayingField.GetLength(1) && newRow >= 0 && newColumn >= 0 && PlayingField[newRow, newColumn])
                {
                    amountNeighbors++;
                }
            }
        }

        return amountNeighbors;
    }
}