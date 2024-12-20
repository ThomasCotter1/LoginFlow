
using System.Data;
using System;
using System.Timers;

namespace LoginFlow.Views;

public partial class TimeSheet : ContentPage
{
    public TimeSheet()
    {
        InitializeComponent();

        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) => DoSomething();
        timer.Start();




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

        lbl_company.Text = "Company";
        lbl_username.Text = "@Username";


    }

    void DoSomething()
    {
        var currentDate = DateTime.Now.ToString("hh:mm tt - dddd, d MMMM yyyy");
        lbl_Date.Text = currentDate;

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

    public async void testButton_Clicked(object sender, System.EventArgs e)
    {
        string result = await DisplayPromptAsync("Confirm Pin", "What is your pin", maxLength: 4, keyboard: Keyboard.Numeric);

        if (result == "1234")
        {
            DisplayAlert("Pin", "Correct", "Yes");



            // basic functionality working, need to adjust location of table data as currently not how it shoule be setup
            // change rows to the actual data taken each time clock in button has been pressed



            DataTable table = new DataTable("Timesheet");

            table.Columns.Add("clockin", typeof(string));
            table.Columns.Add("clockout", typeof(string));
            table.Columns.Add("time", typeof(string));
            table.Columns.Add("jobsitecode", typeof(string));
            table.Columns.Add("workcode", typeof(string));

            DataRow rows = table.NewRow();
            rows["clockin"] = "Test";
            rows["clockout"] = "Test";
            rows["time"] = "Test";
            rows["jobsitecode"] = "Test";
            rows["workcode"] = "Test";

            table.Rows.Add(rows);

            foreach (DataRow row in table.Rows)
            {
                string clockintime = row["clockin"].ToString();
                string clockouttime = row["clockout"].ToString();
                string timediff = row["time"].ToString();
                string jobsitecode = row["jobsitecode"].ToString();
                string workcode = row["workcode"].ToString();

                TestLabel.Text += "PRINTING FROM DATA TABLE" + " " + clockintime + " " + clockouttime + " " + timediff + " " + jobsitecode + " " + workcode;
            }

        }
        else
        {
            DisplayAlert("Pin", "Incorrect", "Yes");
            return;
        }
    }

    public void button_ClockIn_Clicked(object sender, EventArgs e)
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






        TestLabel.Text = TestLabel.Text + "Clock in: " + CurrentTime + "      ";
        TestLabel.Text = TestLabel.Text + "Job Code: " + entry_JobCode.Text + "      ";
        TestLabel.Text = TestLabel.Text + "Work Code: " + JobCodePicker.SelectedItem + "      ";


    }

    private void button_ClockOut_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Clocked Out", "Clock Out registered", "Confirm");
    }

    private void btnSetttings_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Hello", "Hey", "Yes");
       // Shell.Current.GoToAsync("///SetingsPage");
    }
}


