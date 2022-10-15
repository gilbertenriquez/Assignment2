using Assignment1.Model;
using static Assignment1.App;
namespace Assignment1.Pages;

public partial class AddWorkPage : ContentPage
{
	Works work = new();
	public AddWorkPage()
	{
		InitializeComponent();
	}

	private async void BTN_save_Clicked(object sender, EventArgs e)
	{
		await work.AddWorks(key, entryworkname.Text);
		await DisplayAlert("Alert", "Save Successfully", "OK");
	}
    
}
