using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Timer = System.Timers.Timer;

namespace GameOfLife.Web.Components.Pages;

public partial class SandboxGame : IDisposable
{
    [Parameter] public int GameHeight { get; set; }

    [Parameter] public int GameWidth { get; set; }

    [Parameter] public int GameAliveCellsPercent { get; set; }
    
    [Inject] public required NavigationManager NavigationManager { get; set; }
    
    [Inject] public required IJSRuntime JsRuntime { get; set; }
    
    private bool IsDragging { get; set; }
    private double MenuX { get; set; } = 200;
    private double MenuY { get; set; } = 150;
    private double OffsetX { get; set; }
    private double OffsetY { get; set; }

    private Board board = null!;
    private readonly Timer gameTimer = new(500);

    protected override void OnParametersSet()
    {
        board = new Board(GameHeight, GameWidth, GameAliveCellsPercent);
    }

    private bool isGamePaused = true;
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            gameTimer.Elapsed += (s,e) =>
            {
                InvokeAsync(() =>
                {
                    board.AdvanceGeneration();
                    StateHasChanged();
                });
            };
            gameTimer.Stop();
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
    
    private void StartDrag(MouseEventArgs args)
    {
        IsDragging = true;
        OffsetX = args.ClientX - MenuX;
        OffsetY = args.ClientY - MenuY;
    }

    private void EndDrag(MouseEventArgs args)
    {
        IsDragging = false;
    }

    private void OnMouseMove(MouseEventArgs args)
    {
        if (!IsDragging) return;
        MenuX = args.ClientX - OffsetX;
        MenuY = args.ClientY - OffsetY;
    }

    private string GetGameTileStyle()
    {
        if (GameHeight > GameWidth)
        {
            return $"height: calc(99vh / {GameHeight}); max-width: 100vw;";
        } 
        
        if (GameHeight == GameWidth)
        {
            return $"height: calc(99vh / {GameHeight}); max-width: 100vw;";
        }

        return $"width: calc(99vw / {GameWidth}); max-height: 100vh;";
    }
    
    private void TryToggleCell(int row, int column)
    {
        if (isGamePaused && row >= 0 && row < board.PlayingField.GetLength(0) && column >= 0 && column < board.PlayingField.GetLength(1))
        {
            board.ToggleCell(row, column);
            StateHasChanged();
        }
    }
}