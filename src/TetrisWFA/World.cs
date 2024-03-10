namespace TetrisWFA;

internal class World
{
    public static readonly int NextPanelCount = 3;

    private readonly Shape[] _shapes;
    private readonly int _xMax;
    private readonly int _yMax;
    private readonly bool[,] _bits;
    private readonly Random _rng = new Random();

    public Square? CurrentSquare { get; private set; } = null;
    public (int X, int Y) CurrentSquarePosition { get; private set; }
    public bool CurrentSquareChanged { get; private set; }

    public Square[] NextSquares { get; } = new Square[NextPanelCount];

    public World(Shape[] shapes, int xMax, int yMax)
    {
        _shapes = shapes;
        _xMax = xMax;
        _yMax = yMax;
        _bits = new bool[_xMax, _yMax];
    }

    public void InitializeRandom()
    {
        for (int i = 0; i < NextPanelCount; i++)
            NextSquares[i] = GetRandomSquare();
    }


    public bool NextCycle()
    {
        if (CurrentSquare == null)
        {
            // Game start or current was dropped.
            CurrentSquare = NextSquares[0];
            CurrentSquarePosition = (8, 0 - CurrentSquare.EmptyRowsTop);
            ScrollSquares();
            CurrentSquareChanged = true; // need to render next panel
            return !WillCollide(CurrentSquarePosition);
        }

        CurrentSquareChanged = false;
        var nextPosition = (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1);
        if (!WillCollide(nextPosition))
        {
            CurrentSquarePosition = nextPosition;
            return true;
        }

        // Drop current square;
        CopyCurrentSquareToDroppedBits();
        CurrentSquare = null;
        return true;
    }

    private void CopyCurrentSquareToDroppedBits()
    {
        var sq = CurrentSquare;
        if (sq == null)
            return;

        for (var y = 0; y < Shape.MaxWidth; y++)
            for (var x = 0; x < Shape.MaxWidth; x++)
                if (sq[x, y])
                    _bits[CurrentSquarePosition.X + x, CurrentSquarePosition.Y + y] = true;
    }


    private void ScrollSquares()
    {
        for (int i = 0; i < NextPanelCount - 1; i++)
            NextSquares[i] = NextSquares[i + 1];
        NextSquares[NextPanelCount - 1] = GetRandomSquare();
    }

    private Square GetRandomSquare()
    {
        var shape = _shapes[_rng.Next(_shapes.Length)];
        return shape.Squares[_rng.Next(4)];
    }

    public bool WillCollide((int X, int Y) position)
    {
        var sq = CurrentSquare;
        if (sq == null)
            return false;

        for (var y = 0; y < Shape.MaxWidth; y++)
        {
            for (var x = 0; x < Shape.MaxWidth; x++)
            {
                if (sq[x, y])
                {
                    var px = x + position.X;
                    var py = y + position.Y;
                    if (px < 0 || px >= _xMax || py < 0 || py >= _yMax)
                        return true;
                    if (_bits[px, py])
                        return true;
                }
            }
        }
        return false;
    }

    public void MoveLeft()
    {
        if (CurrentSquare == null)
            return;
        if (WillCollide((CurrentSquarePosition.X - 1, CurrentSquarePosition.Y)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X - 1, CurrentSquarePosition.Y);
    }
    public void MoveRight()
    {
        if (CurrentSquare == null)
            return;
        if (WillCollide((CurrentSquarePosition.X + 1, CurrentSquarePosition.Y)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X + 1, CurrentSquarePosition.Y);
    }
    public void Drop()
    {
        if (CurrentSquare == null)
            return;
        if (WillCollide((CurrentSquarePosition.X, CurrentSquarePosition.Y + 1)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1);
    }
    public void Rotate()
    {
        if (CurrentSquare == null)
            return;

        throw new NotImplementedException();
    }

    public bool this[int x, int y]
    {
        get => _bits[x, y];
        set => _bits[x, y] = value;
    }
}