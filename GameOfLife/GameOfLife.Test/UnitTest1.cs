namespace GameOfLife.Test;
public class Tests
{
    [Test]
    public void CheckAmountOfNeighborsCell1()
    {
        // Arrange
        var boardtemp = new Board(30, 30, 25);

        //Act
        var result = boardtemp.GetNeighborCount(0, 0);

        //Assert
        Assert.That(result, Is.EqualTo(1), "1 should be the amount of neighbors");

    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreFourOrMoreNeighbors()
    {
        //act
        var result = Board.ApplyRules(4, true);
        //Assert
        Assert.That(result, Is.EqualTo(false), "Should return false");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreThreeNeighbors()
    {
        //act
        var result = Board.ApplyRules(3, true);
        //Assert
        Assert.That(result, Is.EqualTo(true), "Should return true");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreTwoNeighbors()
    {
        //act
        var result = Board.ApplyRules(2, true);
        //Assert
        Assert.That(result, Is.EqualTo(true), "Should return true");
    }

    [Test]
    public void CheckIfRulesWorkWhenThereAreTwoOrLessNeighbors()
    {
        //act
        var result = Board.ApplyRules(1, true);
        //Assert
        Assert.That(result, Is.EqualTo(false), "Should return false");
    }
}