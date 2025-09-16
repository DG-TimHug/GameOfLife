namespace GameOfLife;
public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int height, int width, int aliveCellsPercent)
    {
        ValidateBoard(height, width, aliveCellsPercent);
        PlayingField = GenerateRandomPlayingField(height, width, aliveCellsPercent);
    }

    public static bool[,] GenerateRandomPlayingField(int height, int width, int aliveCellsPrecent)
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
    
    public void ApplyRules()
    {
        bool[,] updatedCell = new bool[PlayingField.GetLength(0), PlayingField.GetLength(1)];
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                int amountNeighbors = MasterNeighborCount(row, column);
                bool cellState = PlayingField[row, column];
                if (cellState)
                {
                    if (amountNeighbors < 2)
                    {
                        updatedCell[row, column] = false;
                    }
                    
                    if (amountNeighbors is 2 or 3)
                    {
                        updatedCell[row, column] = true;
                    }
                    
                    if (amountNeighbors > 3)
                    {
                        updatedCell[row, column] = false;
                    }
                }
                else
                {
                    if (amountNeighbors == 3)
                    {
                        updatedCell[row, column] = true;
                    }
                }
            }
        }

        PlayingField = updatedCell;
    }
    
    public bool Alive()
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

    public int MasterNeighborCount(int row, int column)
    {
        var amountNeighbors = 0;
        for (int rowoffset= -1; rowoffset <= 1 ; rowoffset++)
        {
            for (int columnOffSet = -1; columnOffSet <= 1 ; columnOffSet++)
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