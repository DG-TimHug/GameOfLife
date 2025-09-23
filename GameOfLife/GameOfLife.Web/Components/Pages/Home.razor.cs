using Microsoft.AspNetCore.Components;
namespace GameOfLife.Web.Components.Pages;

public partial class Home : ComponentBase
{
    private int getGameHeight;
    private int getGameWidth;
    private int getGameAliveCellsPercent;
    protected override void OnInitialized()
    {
        var board = new Board(getGameHeight, getGameWidth, getGameAliveCellsPercent);
    }

    public void PrintGameInputs()
    {
        Console.WriteLine(getGameHeight);
        Console.WriteLine(getGameWidth);
        Console.WriteLine(getGameAliveCellsPercent);
    }
}