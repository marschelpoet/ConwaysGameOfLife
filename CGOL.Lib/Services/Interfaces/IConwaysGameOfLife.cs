namespace CGOL.Lib.Services.Interfaces;

public interface IConwaysGameOfLife : IReadonlyConwaysGameOfLife
{
    void Initialize();

    void Advance();

    bool IsAlive();

    int GetCurrentGeneration();
}