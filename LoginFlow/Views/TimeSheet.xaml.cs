
namespace LoginFlow.Views;

public partial class TimeSheet : ContentPage
{
	public TimeSheet()
	{
		InitializeComponent();

        var JobCodeList = new List<string>();
        JobCodeList.Add("PRE");
        JobCodeList.Add("NCL");
        JobCodeList.Add("ONC");
        JobCodeList.Add("SB");
        JobCodeList.Add("LAB");
        JobCodeList.Add("OER");
        JobCodeList.Add("IND");
        JobCodeList.Add("TRN");
        JobCodeList.Add("MNT");
        JobCodeList.Add("DHI");
        JobCodeList.Add("001");
        JobCodeList.Add("002");
        JobCodeList.Add("003");
        JobCodeList.Add("004");
        JobCodeList.Add("ESC");
        JobCodeList.Add("WS");
        JobCodeList.Add("MR");
        JobCodeList.Add("MRB");
        JobCodeList.Add("HHG");
        JobCodeList.Add("HHC");
        JobCodeList.Add("HHL");
        JobCodeList.Add("OPQ");
        JobCodeList.Add("OPM");
        JobCodeList.Add("OPO");
        JobCodeList.Add("TT");

        JobCodePicker.ItemsSource = JobCodeList;

    }





    /* Unmerged change from project 'LoginFlow (net7.0-ios)'
    Before:
        private void button_TimesheetSubmit_Clicked(object sender, EventArgs e)
        {
    After:
        private void button_TimesheetSubmit_ClickedAsync(object sender, EventArgs e)
        {
    */
    private void button_TimesheetSubmit_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Alert", "You have been alerted", "OK");


        // string result = await DisplayPromptAsync("Question 1", "What's 21 + 2?", initialValue: "23", maxLength: 4, keyboard: Keyboard.Numeric);



        // send data to where needed 
        //  DisplayAlert("Job Code", (string)JobCodePicker.SelectedItem, "Confirm"); // Displays selected job code 



        // alert displays is time sheet submission was sucessfull


        // else alert here incase of sucessful data input however timesheet submission resulted in error


    }

    private async void testButton_Clicked(object sender, System.EventArgs e)
    {
        string result = await DisplayPromptAsync("Confirm Pin", "What is your pin", maxLength: 4, keyboard: Keyboard.Numeric);

        if (result == "1234")
        {
            DisplayAlert("Pin", "Correct", "Yes");
        }
        else
        {
            DisplayAlert("Pin", "Incorrect", "Yes");
            return;
        }
    }

    private void button_ClockIn_Clicked(object sender, EventArgs e)
    {
        var CurrentTime = DateTime.Now.ToShortTimeString();

        if (string.IsNullOrEmpty(entry_JobCode.Text))
        {
            DisplayAlert("Job Code", "Please enter a Job Code.", "OK");
            return;
        }



        if (JobCodePicker.SelectedIndex == -1)
        {
            DisplayAlert("Work Code", "Please enter a Work Code.", "OK");
            return;
        }


        DisplayAlert("Clocked In", "Have you done your saftey...", "Confirm");



        TestLabel.Text = TestLabel.Text + "Clock in: " + CurrentTime + "      ";
        TestLabel.Text = TestLabel.Text + "Job Code: " + entry_JobCode.Text + "      ";
        TestLabel.Text = TestLabel.Text + "Work Code: " + JobCodePicker.SelectedItem + "      ";


    }

    private void button_ClockOut_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Clocked Out", "Clock Out registered", "Confirm");
    }
}

   
