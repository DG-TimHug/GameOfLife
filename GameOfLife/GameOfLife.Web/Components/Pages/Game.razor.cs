using Microsoft.AspNetCore.Components;

namespace GameOfLife.Web.Components.Pages;

public partial class Game
{
    [Parameter]
    public int GameHeight { get; set; }
    
    [Parameter]
    public int GameWidth { get; set; }
    
    [Parameter]
    public int GameAliveCellsPercent { get; set; }
}