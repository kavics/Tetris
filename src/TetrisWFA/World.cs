namespace TetrisWFA;

internal enum CycleResult { Moving, LineDropped, GameOver }

internal class World
{
    public static readonly int NextPanelCount = 3;

    private readonly Shape[] _shapes;
    private readonly int _xMax;
    private readonly int _yMax;
    private readonly bool[,] _bits;
    private readonly Random _rng = new Random();

    public Square? CurrentSquare
    {
        get
        {
            if (CurrentShape == null)
                return null;
            return CurrentShape.Squares[CurrentShapeIndex];
        }
    }

    public Shape? CurrentShape { get; private set; }
    public int CurrentShapeIndex { get; private set; }

    public (int X, int Y) CurrentSquarePosition { get; private set; }
    public bool CurrentSquareChanged { get; private set; }

    public (Shape Shape, int Index)[] NextSquares { get; } = new (Shape, int)[NextPanelCount];

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


    public CycleResult NextCycle()
    {
        if (RemoveLineIfFull())
            return CycleResult.LineDropped;

        if (CurrentShape == null)
        {
            // Game start or current was dropped.
            CurrentShape = NextSquares[0].Shape;
            CurrentShapeIndex = NextSquares[0].Index;

            CurrentSquarePosition = (8, 0 - CurrentSquare.EmptyRowsTop);
            ScrollSquares();
            CurrentSquareChanged = true; // need to render next panel
            return WillCollide(CurrentSquare, CurrentSquarePosition) ? CycleResult.GameOver : CycleResult.Moving;
        }

        CurrentSquareChanged = false;
        var nextPosition = (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1);
        if (!WillCollide(CurrentSquare, nextPosition))
        {
            CurrentSquarePosition = nextPosition;
            return CycleResult.Moving;
        }

        // Drop current square;
        CopyCurrentSquareToDroppedBits();
        CurrentShape= null;
        return CycleResult.Moving;
    }

    private bool RemoveLineIfFull()
    {
        for (int y = _yMax - 1; y >= 0; y--)
        {
            var isFull = true;
            for (var x = 0; x < _xMax; x++)
                isFull &= _bits[x, y];

            if (isFull)
            {
                RemoveLine(y);
                return true;
            }
        }

        return false;
    }

    private void RemoveLine(int line)
    {
        for (int y = line; y >= 1; y--)
            for (var x = 0; x < _xMax; x++)
                _bits[x, y] = _bits[x, y - 1];
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

    private (Shape, int) GetRandomSquare()
    {
        var shape = _shapes[_rng.Next(_shapes.Length)];
        var index = _rng.Next(4);
        return (shape, index);
    }

    public bool WillCollide(Square? sq, (int X, int Y) position)
    {
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
        if (CurrentShape == null)
            return;
        if (WillCollide(CurrentSquare, (CurrentSquarePosition.X - 1, CurrentSquarePosition.Y)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X - 1, CurrentSquarePosition.Y);
    }
    public void MoveRight()
    {
        if (CurrentShape == null)
            return;
        if (WillCollide(CurrentSquare, (CurrentSquarePosition.X + 1, CurrentSquarePosition.Y)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X + 1, CurrentSquarePosition.Y);
    }
    public void Drop()
    {
        if (CurrentShape == null)
            return;
        if (WillCollide(CurrentSquare, (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1)))
            return;
        CurrentSquarePosition = (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1);
    }
    public void Rotate()
    {
        if (CurrentShape == null)
            return;

        var rotatedIndex = (CurrentShapeIndex + 1) % 4;
        var rotated = CurrentShape.Squares[rotatedIndex];
        if (WillCollide(rotated, (CurrentSquarePosition.X, CurrentSquarePosition.Y + 1)))
            return;

        CurrentShapeIndex = rotatedIndex;
    }

    public bool this[int x, int y]
    {
        get => _bits[x, y];
        set => _bits[x, y] = value;
    }
}