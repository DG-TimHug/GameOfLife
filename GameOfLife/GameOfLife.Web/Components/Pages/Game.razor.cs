using Microsoft.AspNetCore.Components;
using Timer = System.Timers.Timer;

namespace GameOfLife.Web.Components.Pages;

public partial class Game : IDisposable
{
    [Parameter] public int GameHeight { get; set; }

    [Parameter] public int GameWidth { get; set; }

    [Parameter] public int GameAliveCellsPercent { get; set; }

    private Board board = null!;
    private Timer gameTimer = null!;

    protected override void OnParametersSet()
    {
        board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            gameTimer = new Timer(500);
            gameTimer.Elapsed += (s,e) =>
            {
                InvokeAsync(() =>
                {
                    if (!board.IsGameAlive())
                    {
                        gameTimer.Stop();
                        gameTimer.Dispose();
                        Console.WriteLine("Game Over!");
                        return;
                    }

                    board.AdvanceGeneration();
                    StateHasChanged();
                });
            };
            gameTimer.Start();
        }
    }

    public void Dispose()
    {
        gameTimer.Dispose();
    }
}