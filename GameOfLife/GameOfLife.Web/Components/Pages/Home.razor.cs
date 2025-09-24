using Microsoft.AspNetCore.Components;
namespace GameOfLife.Web.Components.Pages;

public partial class Home
{
    [Inject] public required NavigationManager NavigationManager { get; set; }
    public int GameHeight;
    public int GameWidth;
    public int GameAliveCellsPercent;
    protected override void OnInitialized()
    {
        var board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);
    }

    public void PrintGameInputs()
    {
        Console.WriteLine(GameHeight);
        Console.WriteLine(GameWidth);
        Console.WriteLine(GameAliveCellsPercent);
        NavigationManager.NavigateTo($"/Game/{GameHeight}/{GameWidth}/{GameAliveCellsPercent}");
    }
}