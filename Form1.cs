namespace csharp_games;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.KeyDown += GetKeyDown;
    }

    private void GetKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        
    }
}