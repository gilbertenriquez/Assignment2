using Assignment1.Model;
using static Assignment1.App;

namespace Assignment1.Pages;

public partial class EditPage : ContentPage
{
	private Users user = new();
	public EditPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{

		base.OnAppearing();
		entryfname.Text = firstname;
		entrylname.Text = lastname;
	
	}

	private async void btnmodify_Clicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(entryfname.Text) || string.IsNullOrEmpty(entrylname.Text))
		{
			var a = await user.editdata(entrylname.Text, entryfname.Text);
			if (!a)
			await DisplayAlert("Modify", "Data Successfully Updated", "OK");
			await Navigation.PopAsync();
			return;
			}
        await DisplayAlert("Modify", "Data Not Successfully Updated", "OK");
    }
}