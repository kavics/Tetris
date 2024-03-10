using System.Xml.Serialization;

namespace TetrisWFA;

internal class Square
{
    public int EmptyColsLeft { get; private set; }
    public int EmptyColsRight { get; private set; }
    public int EmptyRowsTop { get; private set; }
    public int EmptyRowsBottom { get; private set; }
    public static Square Parse(string[] input)
    {
        var square = new Square();
        for (int line = 0; line < input.Length; line++)
            for (var col = 0; col < input.Length; col++)
                square._bits[col, line] = input[line][col] != '.';
        square.Initialize();
        return square;
    }

    private Square()
    {
        _bits = new bool[Shape.MaxWidth, Shape.MaxWidth];
    }

    private void Initialize()
    {
        var count = 0;
        for (var y = 0; y < Shape.MaxWidth; y++)
        {
            for (var x = 0; x < Shape.MaxWidth; x++)
                if (_bits[x, y])
                    count++;
            if (count > 0)
            {
                EmptyRowsTop = y;
                break;
            }
        }

        count = 0;
        for (int line = Shape.MaxWidth - 1; line >= 0; line--)
        {
            for (var col = 0; col < Shape.MaxWidth; col++)
                if (_bits[col, line])
                    count++;
            if (count > 0)
            {
                EmptyRowsBottom = Shape.MaxWidth - line - 1;
                break;
            }
        }

        count = 0;
        for (var col = 0; col < Shape.MaxWidth; col++)
        {
            for (var line = 0; line < Shape.MaxWidth; line++)
                if (_bits[col, line])
                    count++;
            if (count > 0)
            {
                EmptyColsLeft = col;
                break;
            }
        }

        count = 0;
        for (int col = Shape.MaxWidth - 1; col >= 0; col--)
        {
            for (var line = 0; line < Shape.MaxWidth; line++)
                if (_bits[col, line])
                    count++;
            if (count > 0)
            {
                EmptyColsRight = Shape.MaxWidth - col - 1;
                break;
            }
        }
    }

    /* ============================================== */

    private readonly bool[,] _bits; // _bits[x, y]

    public bool this[int x, int y]
    {
        get => _bits[x, y];
        set => _bits[x, y] = value;
    }
}