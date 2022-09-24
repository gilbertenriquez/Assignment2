namespace Assignment1.Pages;
using Assignment1.Model;

public partial class LoginPage1 : ContentPage
{

    private Users user = new();
    public LoginPage1()
    {
        InitializeComponent();
    }

    private async void btnsignin_Clicked(object sender, EventArgs e)
    {
        var a = await user.UserLogin(entryEmail.Text, entryPassword.Text);

        if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPassword.Text))
        {
            await DisplayAlert("Alert!", "Please Fill up your Email or Pasword!", "Got it!");
            entryEmail.Text = "";
            entryPassword.Text = "";
            return;
        }
        progressLoading.IsVisible = true;

        if (a)
        {
            await DisplayAlert("Alert!", "Access Granted!", "OK!");
            Application.Current!.MainPage = new AppShell();
            progressLoading.IsVisible = false;
            return;
        }
        await DisplayAlert("Alert!", "Access Denied!", "OK!");
        progressLoading.IsVisible = false;
    }

    private async void btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}