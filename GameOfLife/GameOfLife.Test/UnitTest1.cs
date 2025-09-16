namespace GameOfLife.Test;

public class Tests
{
    [Test]
    public void CheckAmountOfNeighborsCell1()
    {
        // Arrange
        var boardtemp = new Board(30, 30, 25);
        
        //Act
        var result = boardtemp.GetNeighborsCount(0, 0);

        //Assert
        Assert.That(result, Is.EqualTo(1), "1 should be the amount of neighbors");

    }

    [Test]
    public void CheckBoardGeneration()
    {
        // Arrange
        
        
        //Act
        var result = Board.GenerateRandomPlayingField(30,30,25);
        

        //Assert
       //Assert.That(result,)
    }

    [Test]
    public void CheckRules()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
}