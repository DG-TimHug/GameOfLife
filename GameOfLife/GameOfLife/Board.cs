namespace GameOfLife;

public class Board
{
    public bool[,] PlayingField;
    public Board(int windowWidth, int windowHeight)
    {
        PlayingField = new bool[windowHeight, windowWidth];
    }
    
}