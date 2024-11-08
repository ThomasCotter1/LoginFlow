using System;
using System.Security.Cryptography.X509Certificates;

namespace LoginFlow.Views;

public partial class LoginPage
{
    public string user = "";
    

    public string inputtedPassword
    {
        get { return Password.Text; }
        set { inputtedPassword = value; }
    }
}

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {

            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///TimeSheet");
        }
        else
        {
            await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
        }
    }

    private void btnResetClicked(object sender, EventArgs e)
    {
        Username.Text = "";
        Password.Text = "";
    }

    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "admin" && Password.Text == "1234";
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {


        if (inputtedPassword.Length == 4)
        {
            if (IsCredentialCorrect(Username.Text, Password.Text))
            {

                SecureStorage.SetAsync("hasAuth", "true");
                Shell.Current.GoToAsync("///TimeSheet");
            }
            else
            {
                DisplayAlert("Login failed", "Username or password is invalid", "Try again");
                Username.Text = "";
                Password.Text = "";
            }
        }
    }

}