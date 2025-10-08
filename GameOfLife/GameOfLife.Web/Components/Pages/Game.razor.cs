using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Timer = System.Timers.Timer;

namespace GameOfLife.Web.Components.Pages;

public partial class Game : IDisposable
{
    [Parameter] public int GameHeight { get; set; }

    [Parameter] public int GameWidth { get; set; }

    [Parameter] public int GameAliveCellsPercent { get; set; }
    
    [Inject] public required NavigationManager NavigationManager { get; set; }
    
    [Inject] public required IJSRuntime JsRuntime { get; set; }

    private Board board = null!;
    private Timer gameTimer = null!;

    protected override void OnParametersSet()
    {
        board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);
    }

    private bool isGamePaused = false;
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
                        GameOver();
                        return;
                    }

                    board.AdvanceGeneration();
                    StateHasChanged();
                });
            };
            gameTimer.Start();
        }
    }
    private void PauseGame()
    {
        if (gameTimer != null && !isGamePaused)
        {
            gameTimer.Stop();
            isGamePaused = true;
            StateHasChanged();
        }
    }
    private void ResumeGame()
    {
        if (gameTimer != null && isGamePaused)
        {
            gameTimer.Start();
            isGamePaused = false;
            StateHasChanged();
        }
    }
    
    private void GameOver()
    {
        Thread.Sleep(2000);
        gameTimer.Stop();
        Dispose();
        StateHasChanged();
        Console.WriteLine("Game Over!");
        NavigationManager.NavigateTo($"/");
    }

    private void ExitGame()
    {
        gameTimer.Stop();
        StateHasChanged();
        NavigationManager.NavigateTo($"/");
    }

    private void RestartGame()
    {
        NavigationManager.Refresh(true);
    }
    
    public void Dispose()
    {
        gameTimer.Dispose();
    }
}