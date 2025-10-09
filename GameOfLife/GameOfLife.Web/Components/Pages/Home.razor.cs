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
    private int GameHeightSandbox;
    private int GameWidthSandbox;
    private int GameAliveCellsPercent;

    private void LaunchGame()
    {
        NavigationManager.NavigateTo($"/Game/{GameHeight}/{GameWidth}/{GameAliveCellsPercent}");
    }
    
    private void LaunchSandboxGame()
    {
        NavigationManager.NavigateTo($"/SandboxGame/{GameHeightSandbox}/{GameWidthSandbox}");
    }
}