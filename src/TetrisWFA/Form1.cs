// ReSharper disable LocalizableElement
namespace TetrisWFA;

public partial class Form1 : Form
{
    private int _lines;
    private int _score;

    public Form1()
    {
        InitializeComponent();
        mainTimer.Enabled = false;
        InitializeGame();
        mainTimer.Interval = 250;
        mainTimer.Enabled = true;
    }

    private static readonly int CellSize = 20;
    private static readonly int NextPanelPadding = 20;
    private readonly Color[] _mainPanelColors = new[] { SystemColors.ControlLightLight, SystemColors.ActiveCaptionText, SystemColors.HotTrack };
    private readonly Color[] _nextPanelColors = new[] { SystemColors.Control, SystemColors.ActiveCaptionText };
    private int _mainPanelCellCountX;
    private int _mainPanelCellCountY;
    private World _world;

    private void InitializeGame()
    {
        _mainPanelCellCountX = MainPanel.Width / CellSize;
        _mainPanelCellCountY = MainPanel.Height / CellSize;
        _shapes = CreateShapes(ShapeSource.Shapes);
        _nextPanels = new[] { NextPanel1, NextPanel2, NextPanel3 };
        _score = 0;
        _lines = 0;
        CreateUi();

        _world = new World(_shapes, _mainPanelCellCountX, _mainPanelCellCountY);
        _world.InitializeRandom();

        RenderNextPanels();
        RenderScores();
        this.Focus();
    }
    private void RestartGame()
    {
        _world = new World(_shapes, _mainPanelCellCountX, _mainPanelCellCountY);
        _world.InitializeRandom();
        _score = 0;
        _lines = 0;

        RenderMainPanel();
        RenderNextPanels();
        this.Focus();
    }

    private Label[,] _mainCells;
    private void CreateUi()
    {
        _mainCells = new Label[_mainPanelCellCountX, _mainPanelCellCountY];
        var tabindex = 0;
        for (var y = 0; y < _mainPanelCellCountY; y++)
        {
            for (var x = 0; x < _mainPanelCellCountX; x++)
            {
                var label = new Label();
                MainPanel.Controls.Add(label);

                label.BackColor = _mainPanelColors[0];
                label.Location = new Point(x * CellSize + 1, y * CellSize + 1);
                label.Name = $"Cell_x{x}_y{y}";
                label.Size = new Size(18, 18);
                label.TabIndex = tabindex++;
                label.Click += control_Click;

                _mainCells[x, y] = label;
            }
        }

        var nextPanels = new[] { NextPanel1, NextPanel2, NextPanel3 };
        for (var count = 0; count < 3; count++)
        {
            var panel = nextPanels[count];
            for (var y = 0; y < 4; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    var label = new Label();
                    panel.Controls.Add(label);

                    label.BackColor = _nextPanelColors[0];
                    label.Location = new Point(x * CellSize + 1, y * CellSize + 1);
                    label.Name = $"Next{count}_x{x}_y{y}";
                    label.Size = new Size(18, 18);
                    label.TabIndex = tabindex++;
                    label.Click += control_Click;
                }
            }
        }
    }

    private string GetMainPanelCellName(int y, int x) => $"Cell_x{x}_y{y}";


    private Panel[] _nextPanels;
    private void RenderNextPanels()
    {
        for (int i = 0; i < _nextPanels.Length; i++)
        {
            var panel = _nextPanels[i];
            var ns = _world.NextSquares[i];
            var square = ns.Shape.Squares[ns.Index];
            for (var y = 0; y < Shape.MaxWidth; y++)
            {
                for (var x = 0; x < Shape.MaxWidth; x++)
                {
                    var name = $"Next{i}_x{x}_y{y}";
                    var label = panel.Controls[name];
                    label.BackColor = _nextPanelColors[square[x, y] ? 1 : 0];
                }
            }
        }
    }

    /// <summary>Only debug purposes</summary>
    private void control_Click(object? sender, EventArgs e)
    {
        toolStripStatusLabel2.Text = (sender as Control)?.Name ?? "unknown";
    }

    private Shape[] _shapes;

    private Shape[] CreateShapes(string[] shapesSource)
    {
        var shapes = new List<Shape>();
        for (int i = 0; i < shapesSource.Length; i += Shape.MaxWidth * 4)
        {
            var lines = shapesSource.Skip(i).Take(Shape.MaxWidth * 4).ToArray();
            shapes.Add(Shape.Parse(lines));
        }
        return shapes.ToArray();
    }

    private int _cycles;
    private void mainTimer_Tick(object sender, EventArgs e)
    {
        mainTimer.Enabled = false;
        toolStripStatusLabel1.Text = $"{++_cycles}";
        HideCurrentSquare();
        var state = _world.NextCycle();
        if (state != CycleResult.GameOver)
        {
            RenderWorld();
            if (state == CycleResult.LineDropped)
            {
                _score += 20;
                _lines++;
            }
            else
            {
                _score += 1;
            }
            _score += state == CycleResult.LineDropped ? 10 : 1;
            RenderScores();
            mainTimer.Enabled = true;
        }
        else
        {
            mainTimer.Enabled = false;
            gameOverScoreLabel.Text = $"{_score}";
            gameOverPanel.Visible = true;
        }
    }

    private void RenderWorld()
    {
        RenderMainPanel();
        RenderCurrentSquare();
        if (_world.CurrentSquareChanged)
            RenderNextPanels();
    }
    private void RenderMainPanel()
    {
        for (var y = 0; y < _mainPanelCellCountY; y++)
            for (var x = 0; x < _mainPanelCellCountX; x++)
                _mainCells[x, y].BackColor = _mainPanelColors[_world[x, y] ? 1 : 0];
    }
    private void RenderScores()
    {
        LinesLabel.Text = $"{_lines}";
        scoreLabel.Text = $"{_score}";
    }
    private void RenderCurrentSquare()
    {
        var square = _world.CurrentSquare;
        if (square == null)
            return;

        var p = _world.CurrentSquarePosition;
        for (var y = 0; y < Shape.MaxWidth; y++)
            for (var x = 0; x < Shape.MaxWidth; x++)
                if (x + p.X < _mainPanelCellCountX && x + p.X >= 0 && y + p.Y < _mainPanelCellCountY && y + p.Y >= 0)
                    if (square[x, y])
                        _mainCells[x + p.X, y + p.Y].BackColor = _mainPanelColors[2];
    }
    private void HideCurrentSquare()
    {
        var square = _world.CurrentSquare;
        if (square == null)
            return;

        var p = _world.CurrentSquarePosition;
        for (var y = 0; y < Shape.MaxWidth; y++)
            for (var x = 0; x < Shape.MaxWidth; x++)
                if (x + p.X < _mainPanelCellCountX && x + p.X >= 0 && y + p.Y < _mainPanelCellCountY && y + p.Y >= 0)
                    if (square[x, y])
                        _mainCells[x + p.X, y + p.Y].BackColor = _mainPanelColors[0];
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (_world.CurrentSquare == null)
            return;

        HideCurrentSquare();
        switch (e.KeyCode)
        {
            default:
                return;
            case Keys.Left: _world.MoveLeft(); break;
            case Keys.Right: _world.MoveRight(); break;
            case Keys.Up: _world.Rotate(); break;
            case Keys.Down: _world.Drop(); break;
        }
        e.Handled = true;
        RenderCurrentSquare();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void newGameButton_Click(object sender, EventArgs e)
    {
        gameOverPanel.Visible = false;
        RestartGame();
        mainTimer.Enabled = true;
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}