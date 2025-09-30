using Microsoft.AspNetCore.Components;
using Timer = System.Timers.Timer;

namespace GameOfLife.Web.Components.Pages;

public partial class Game : IDisposable
{
    [Parameter] public int GameHeight { get; set; }

    [Parameter] public int GameWidth { get; set; }

    [Parameter] public int GameAliveCellsPercent { get; set; }

    private Board board = null!;
    private Timer timer = null!;

    protected override void OnParametersSet()
    {
        board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            timer = new Timer(500);
            timer.Elapsed += (s,e) =>
            {
                InvokeAsync(() =>
                {
                    if (!board.IsGameAlive())
                    {
                        timer.Stop();
                        timer.Dispose();
                        return;
                    }

                    board.AdvanceGeneration();
                    StateHasChanged();
                });
            };
            timer.Start();
        }
    }

    public void Dispose()
    {
        timer.Dispose();
    }
}