using Timer = System.Timers.Timer;

namespace csharp_games;

public partial class Form1 : Form
{
    public Timer timer;
    
    private PictureBox player1;
    private PictureBox player2;
    private PictureBox ball;
    private Point ballVelocity = new Point(1, 1);

    private int speed = 5;
    
    public Form1()
    {
        InitializeComponent();
        SetBounds(Location.X, Location.Y, 1280, 720);
        MaximumSize = new Size(1280, 720);
        MinimumSize = new Size(1280, 720);
        FormBorderStyle = FormBorderStyle.None;

        timer = new Timer();
        timer.Interval = 16;
        timer.Elapsed += GameLoop;
        timer.Enabled = true;
        
        player1 = new PictureBox();
        player1.SetBounds(50, Height / 2 - 100, 50, 200);
        player1.BackColor = Color.Blue;
        player1.Parent = this;
        
        player2 = new PictureBox();
        player2.SetBounds(Width - 100, Height / 2 - 100, 50, 200);
        player2.BackColor = Color.Red;
        player2.Parent = this;
        
        ball = new PictureBox();
        ball.SetBounds(Width / 2 - 25, Height / 2 - 25, 50, 50);
        ball.BackColor = Color.DarkSlateGray;
        ball.Parent = this;

        KeyDown += GetKeyDown;
    }

    private void GameLoop(object sender, System.Timers.ElapsedEventArgs e)
    {
        MoveBall(ref ball);
    }

    private void GetKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) 
            Close();
        
        // Player 1 inputs
        switch (e.KeyCode)
        {
            case Keys.W:
                MovePlayer(ref player1, new Point(0, -1));
                break;
            
            case Keys.S:
                MovePlayer(ref player1, new Point(0, 1));
                break;
        }
        
        // Player 2 inputs
        switch (e.KeyCode)
        {
            case Keys.Up:
                MovePlayer(ref player2, new Point(0, -1));
                break;
            
            case Keys.Down:
                MovePlayer(ref player2, new Point(0, 1));
                break;
        }
    }

    private void MoveBall(ref PictureBox ball)
    {
        ball.Location = new Point(ball.Location.X + ballVelocity.X * speed, ball.Location.Y + ballVelocity.Y * speed);
        
        if (ball.Top <= 0 || ball.Bottom >= Height)
            ballVelocity.Y *= -1;

        if ((ball.Left == player1.Right && (ball.Top >= player1.Top && ball.Bottom <= player1.Bottom)) || (ball.Right == player2.Left && (ball.Top >= player2.Top && ball.Bottom <= player2.Bottom)))
            ballVelocity.X *= -1;
    }

    private void MovePlayer(ref PictureBox toMove, Point direction)
    {
        toMove.Location = toMove.Location with { Y = toMove.Location.Y + direction.Y * speed };
        
        if (toMove.Location.Y <= 0)
            toMove.Location = toMove.Location with { Y = 0 };

        if (toMove.Location.Y >= Height - toMove.Height)
            toMove.Location = toMove.Location with { Y = Height - toMove.Height };
    }
}