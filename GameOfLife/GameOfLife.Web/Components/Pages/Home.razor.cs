using Microsoft.AspNetCore.Components;
namespace GameOfLife.Web.Components.Pages;

public partial class Home
{
    protected override void OnInitialized()
    {
        Console.WriteLine("Homepage loaded");
    }
    
    [Inject] public required NavigationManager NavigationManager { get; set; }
    private int GameHeight;
    private int GameWidth;
    private int GameAliveCellsPercent;

    private void PrintGameInputs()
    {
        Console.WriteLine(GameHeight);
        Console.WriteLine(GameWidth);
        Console.WriteLine(GameAliveCellsPercent);
        NavigationManager.NavigateTo($"/Game/{GameHeight}/{GameWidth}/{GameAliveCellsPercent}");
    }
    
}