namespace csharp_games;

public partial class Form1 : Form
{
    public PictureBox player1;
    public PictureBox player2;
    
    public Form1()
    {
        InitializeComponent();
        SetBounds(Location.X, Location.Y, 1280, 720);
        MaximumSize = new Size(1280, 720);
        MinimumSize = new Size(1280, 720);
        

        player1 = new PictureBox();
        player1.SetBounds(Width - 100, Height / 2 - 100, 50, 200);
        player1.BackColor = Color.Blue;
        player1.Parent = this;
        
        player2 = new PictureBox();
        player2.SetBounds(50, Height / 2 - 100, 50, 200);
        player2.BackColor = Color.Red;
        player2.Parent = this;

        this.KeyDown += GetKeyDown;
    }

    private void GetKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) 
            Close();
        
        // Player 1 inputs
        switch (e.KeyCode)
        {
            case Keys.W:
                Move(ref player1, new Point(0, -1));
                break;
            
            case Keys.S:
                Move(ref player1, new Point(0, 1));
                break;
        }
        
        // Player 2 inputs
        switch (e.KeyCode)
        {
            case Keys.Up:
                Move(ref player2, new Point(0, -1));
                break;
            
            case Keys.Down:
                Move(ref player2, new Point(0, 1));
                break;
        }
    }

    private void Move(ref PictureBox toMove, Point direction)
    {
        int speed = 5;

        toMove.Location = new Point(toMove.Location.X + direction.X * speed, toMove.Location.Y + direction.Y * speed);
        
        if (toMove.Location.Y <= 0)
            toMove.Location = toMove.Location with { Y = 0 };

        if (toMove.Location.Y >= Height - toMove.Height)
            toMove.Location = toMove.Location with { Y = Height - toMove.Height };
    }
}