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
    public void CheckIfRulesWorkWhenThereAreFourOrMoreNeighbors()
    {
        //arrange
        var boardtemp = new Board(30, 30, 25);
        //act
        var result = boardtemp.ApplyRules(4, true);
        //Assert
        Assert.That(result, Is.EqualTo(false), "Should return false");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreThreeNeighbors()
    {
        //arrange
        var boardtemp = new Board(30, 30, 25);
        //act
        var result = boardtemp.ApplyRules(3, true);
        //Assert
        Assert.That(result, Is.EqualTo(true), "Should return true");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreTwoNeighbors()
    {
        //arrange
        var boardtemp = new Board(30, 30, 25);
        //act
        var result = boardtemp.ApplyRules(2, true);
        //Assert
        Assert.That(result, Is.EqualTo(true), "Should return true");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreTwoOrLessNeighbors()
    {
        //arrange
        var boardtemp = new Board(30, 30, 25);
        //act
        var result = boardtemp.ApplyRules(1, true);
        //Assert
        Assert.That(result, Is.EqualTo(false), "Should return false");
    }
}