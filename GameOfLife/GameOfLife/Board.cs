namespace GameOfLife;

public class Board
{
    public Board(int width, int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0");
        }
        PlayingField = new bool[height, width];
    }
    public bool[,] PlayingField { get; private set; }
}