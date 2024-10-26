namespace SirenStudio;

public partial class MainPage : ContentPage
{
    private int count;
    private bool m_pressed = true;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterBtn.Text = $"Clicked {count} time" + (count == 1 ? "" : "s");
    }

    private void OnMusicClicked(object sender, EventArgs e)
    {
        if (m_pressed)
        {
            OtherButton.Text = $"I lied";
            m_pressed = false;
        }
        else
        {
            OtherButton.Text = $"Press for even more music";
            m_pressed = true;
        }
    }
}