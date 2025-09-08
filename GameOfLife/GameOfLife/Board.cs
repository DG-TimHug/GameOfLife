namespace GameOfLife;

public class Board(int windowWidth, int windowHeight)
{
    public bool[,] PlayingField { get; private set; } = new bool[windowHeight, windowWidth];
}