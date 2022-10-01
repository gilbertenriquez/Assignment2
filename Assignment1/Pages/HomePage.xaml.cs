using Assignment1.Model;


namespace Assignment1.Pages;

public partial class HomePage : ContentPage
{
    private Users userlist = new();
    public HomePage()
    {
        InitializeComponent();
        ListUsers.ItemsSource = userlist.GetUserList();
    }

    private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.email = (e.CurrentSelection.FirstOrDefault() as Users)?.Email;
        App.key = await userlist.GetUserKey(App.email);

    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPage());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }
}