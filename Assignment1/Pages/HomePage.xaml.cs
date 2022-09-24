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

}