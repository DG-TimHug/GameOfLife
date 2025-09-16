namespace GameOfLife.Test;
/*
 * Master TO-DO:
 * Split applyRules and rename applyRules
 * Check each rule individually and test
 */
public class Tests
{
    [Test]
    public void CheckAmountOfNeighborsCell1()
    {
        // Arrange
        var boardtemp = new Board(30, 30, 25);
        
        //Act
        var result = boardtemp.MasterNeighborCount(0, 0);

        //Assert
        Assert.That(result, Is.EqualTo(1), "1 should be the amount of neighbors");

    }

    [Test]
    public void CheckRules()
    {
        //Arrange
        var boardtemp = new Board(5, 5, 50);
        //Act
        boardtemp.ApplyRules();
        //Assert
        Assert.That(boardtemp.PlayingField[4,1], Is.False, "should be false");
    }
}