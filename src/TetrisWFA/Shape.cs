namespace TetrisWFA;

internal class Shape
{
    public static readonly int MaxWidth = 4;

    public static Shape Parse(string[] input)
    {
        var squares = new Square[4];

        for (var r = 0; r < 4; r++)
        {
            squares[r] = Square.Parse(input.Skip(r*MaxWidth).Take(MaxWidth).ToArray());
        }

        var shape = new Shape();
        shape.Squares = squares;
        return shape;
    }

    private Shape() { }

    /* ============================================== */

    public Square[] Squares;

}