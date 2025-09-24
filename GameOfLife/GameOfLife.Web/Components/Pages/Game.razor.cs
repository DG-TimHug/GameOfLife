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
    
    private Board? board;
    
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        var amountgenerations = 0;
        if (firstRender)
        {
            Console.WriteLine("GamePage loaded");
            board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);

            
            while (board.IsGameAlive())
            {
                Thread.Sleep(250);
                board.AdvanceGeneration();
                StateHasChanged();
                amountgenerations++;
                Console.WriteLine($"Current generation {amountgenerations}");
            }
        }

        Console.WriteLine("Finished 🔮");
        Console.WriteLine($"Total Generations {amountgenerations}");
        return Task.CompletedTask;
    }
}