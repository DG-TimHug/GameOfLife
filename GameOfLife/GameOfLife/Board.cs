namespace GameOfLife;
/*
 * MASTER TO-DO:
 * - Implement Rules -> DONE
 *      - Apply Rules and set cells to false -> let them die when rules aren't met -> DONE
 * - Check Neighbors for all cells not just alive -> WIP
 * -
 * --- CURRENT STATE ---
 * Rules have been added
 *     Unsure if they are operational as when code is run board isn't properly made
 * Might be working ????
 * sets majority to true -> might be a probelm with Rule 4 as it sets the dead cells to alive
 *  other than that Check neighbor is operational 
 */
public class Board
{
    public bool[,] PlayingField { get; private set; }

    public Board(int height, int width, int aliveCellsPercent)
    {
        ValidateBoard(height, width, aliveCellsPercent);
        PlayingField = GenerateRandomPlayingField(height, width, aliveCellsPercent);
        //AmountOfNeighbor();
        //ApplyRules();
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

    private int GetNeighborsCount(int row, int column)
    { 
        var amountNeighbors = 0;
        if (CheckNeighbor1(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor2(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor3(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor4(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor5(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor6(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor7(row,column ))
        {
            amountNeighbors++;
        }
        if (CheckNeighbor8(row,column ))
        {
            amountNeighbors++;
        }
            
        return amountNeighbors;
    }

    public void ApplyRules()
    {
        bool[,] updatedCell = new bool[PlayingField.GetLength(0), PlayingField.GetLength(1)];
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                int amountNeighbors = GetNeighborsCount(row, column);
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

    private bool CheckNeighbor1(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY - 1;
        var newPosX = currentPositionX;
        if (newPosY < 0)
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor2(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY - 1;
        var newPosX = currentPositionX + 1;
        if (newPosY < 0 || newPosX >= PlayingField.GetLength(1))
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor3(int currentPositionY, int currentPositionX )
    {
        var newPosX = currentPositionX + 1;
        var newPosY= currentPositionY;
        if (newPosX >= PlayingField.GetLength(1))
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor4(int currentPositionY, int currentPositionX )
    {
        var newPosX = currentPositionX + 1;
        var newPosY = currentPositionY + 1;
        if (newPosY >= PlayingField.GetLength(0) ||newPosX >= PlayingField.GetLength(1))
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor5(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY + 1;
        var newPosX = currentPositionX;
        if (newPosY >= PlayingField.GetLength(0))
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor6(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY + 1;
        var newPosX = currentPositionX - 1;
        if (newPosY >= PlayingField.GetLength(0) || newPosX < 0)
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor7(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY;
        var newPosX = currentPositionX -1;
        if (newPosX < 0 || newPosY < 0 || newPosY >= PlayingField.GetLength(0))
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
    }
    private bool CheckNeighbor8(int currentPositionY, int currentPositionX )
    {
        var newPosY = currentPositionY -1;
        var newPosX = currentPositionX -1;
        if (newPosX < 0 || newPosY < 0)
        {
            return false;
        }

        return PlayingField[newPosY, newPosX];
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
}