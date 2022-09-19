namespace Assignment1.Pages;
using Assignment1.Model;

public partial class LoginPage1 : ContentPage
{

	private Users user = new ();
	public LoginPage1()
	{
		InitializeComponent();
	}

	private async void btnsignin_Clicked(object sender, EventArgs e)
	{
		var a = await user.UserLogin(entryEmail.Text, entryPassword.Text);
		if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPassword.Text))
		{
			await DisplayAlert("Alert!", "Please Check The Email or Pasword They are Empty! need to Fill it up", "Got it!");
			return;
		}				        
        if (a)
		{
			await DisplayAlert("Login!", "Access Granted!", "OK!");
			return;
		}
        await DisplayAlert("Login!", "Access Denied!", "OK!");		
    }

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
}