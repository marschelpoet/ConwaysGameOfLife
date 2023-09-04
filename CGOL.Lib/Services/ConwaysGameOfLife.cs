using CGOL.Lib.Configuration;

using Microsoft.Extensions.Options;

using System.Text;

namespace CGOL.Lib.Services;

public class ConwaysGameOfLife : IConwaysGameOfLife
{
    private readonly int _width;
    private readonly int _height;
    private bool[,] _gameBoard;
    private int _currentGeneration;
    public int GetCurrentGeneration() => _currentGeneration;

    public ConwaysGameOfLife(IOptionsSnapshot<GameOfLifeOptions> optionsSnapshot)
    {
        _width = optionsSnapshot.Value.Width;
        _height = optionsSnapshot.Value.Height;
        _currentGeneration = 0;
        _gameBoard = new bool[_width, _height];
    }

    public void Initialize()
    {
        #region debug
        _gameBoard[5, 5] = _gameBoard[5, 6] = _gameBoard[5, 7] = true;
        _gameBoard[15, 5] = _gameBoard[16, 5] = _gameBoard[17, 5] = true;

        for (int hi = 20; hi < 25; hi++)
        {
            for (int wi = 70; wi < 97; wi++)
            {
                if (hi % 2 == 0)
                {
                    if (wi % 2 == 0)
                    {
                        _gameBoard[wi, hi] = true;
                    }
                }
                else
                {
                    if (wi % 2 == 1)
                    {
                        _gameBoard[wi, hi] = true;
                    }
                }
            }
        }
        #endregion
    }

    public void Advance()
    {
        bool[,] newBoard = new bool[_width, _height];

        for (int height = 0; height < _height; height++)
        {
            for (int width = 0; width < _width; width++)
            {
                newBoard[width, height] = GetCountOfAliveNeighbours(width, height) switch
                {
                    2 => _gameBoard[width, height],
                    3 => true,
                    _ => false
                };
            }
        }

        _gameBoard = newBoard;
        _currentGeneration++;
    }

    public bool IsAlive()
    {
        foreach (bool line in _gameBoard)
        {
            if (line) return true;
        }

        return false;
    }

    private int GetCountOfAliveNeighbours(int initialWidth, int initialHeight)
    {
        int result = 0;

        for (int widthDeviation = -1; widthDeviation < 2; widthDeviation++)
        {
            for (int heightDeviation = -1; heightDeviation < 2; heightDeviation++)
            {
                if (widthDeviation == 0 && heightDeviation == 0)
                    heightDeviation++;

                result += IsCellAliveAsInt(initialWidth + widthDeviation, initialHeight + heightDeviation);
            }
        }

        return result;
    }

    private int IsCellAliveAsInt(int width, int height)
    {
        // ReSharper disable once ComplexConditionExpression
        if (width < 0 ||
            width >= _width ||
            height < 0 ||
            height >= _height)
        {
            return 0;
        }

        return _gameBoard[width, height] ? 1 : 0;
    }

    public override string ToString()
    {
        StringBuilder resultBuilder = new();
        for (int height = 0; height < _height; height++)
        {
            for (int width = 0; width < _width; width++)
            {
                resultBuilder.Append(_gameBoard[width, height] ? "O" : " ");
            }

            resultBuilder.AppendLine();
        }

        return resultBuilder.ToString();
    }
}