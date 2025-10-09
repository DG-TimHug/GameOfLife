namespace GameOfLife;
public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int height, int width, int aliveCellsPercent)
    {
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
                playingField[row, column] = rand.Next(100 + 1) < aliveCellsPrecent;
            }
        }
        
        return playingField;
    }
    
    public void AdvanceGeneration()
    {
        bool[,] updatedCells = new bool[PlayingField.GetLength(0), PlayingField.GetLength(1)];
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                updatedCells[row, column] = ApplyRules(GetNeighborCount(row, column), PlayingField[row, column]);
            }
        }

        PlayingField = updatedCells;
    }

    public static bool ApplyRules(int amountNeighbors, bool cellState)
    {
        if (cellState)
        {
            if (amountNeighbors is 2 or 3)
            {
                return true;
            }
        }
        else
        {
            if (amountNeighbors == 3)
            {
                return true;
            }
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
        
        for (var rowOffSet= -1; rowOffSet <= 1 ; rowOffSet++)
        {
            for (var columnOffSet = -1; columnOffSet <= 1 ; columnOffSet++)
            {
                if (rowOffSet == 0 && columnOffSet == 0)
                {
                    continue;
                }
                
                var currentRow = row + rowOffSet;
                var currentColumn = column + columnOffSet;

                if (currentRow >= 0 && currentRow < PlayingField.GetLength(0) && currentColumn >= 0 && currentColumn < PlayingField.GetLength(1))
                {
                    if (PlayingField[currentRow, currentColumn])
                    {
                        amountNeighbors++;
                    }
                }
            }
        }

        return amountNeighbors;
    }
    public void ToggleCell(int row, int column)
    {
        if (row >= 0 && row < PlayingField.GetLength(0) && 
            column >= 0 && column < PlayingField.GetLength(1))
        {
            PlayingField[row, column] = !PlayingField[row, column];
        }
    }
}