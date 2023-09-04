namespace CGOL.Lib.Services.Interfaces;

public interface IGameLoop
{
    void RunGame();

    void Stop();

    void Pause();
}