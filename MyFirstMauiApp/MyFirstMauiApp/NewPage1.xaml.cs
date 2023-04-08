namespace MyFirstMauiApp;

public partial class NewPage1 : ContentPage
{
	private int count;
	public NewPage1()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		count++;
        lblCounter.Text = $"Click Count:{count}";
        SemanticScreenReader.Announce(lblCounter.Text);
    }
}
