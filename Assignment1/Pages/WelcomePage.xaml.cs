namespace Assignment1.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	private async void btnlogin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage1());
	}

    private async void btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage1());
    }

	private async void btnregister_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MainPage());
    }
}