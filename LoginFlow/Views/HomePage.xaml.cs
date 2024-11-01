namespace LoginFlow.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();



	}

    private void button_Timesheet_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("///TimeSheet");
        
    }

}