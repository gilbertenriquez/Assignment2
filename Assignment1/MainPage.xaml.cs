using Assignment1.Model;
using Plugin.Connectivity;
using Assignment1.Pages;

namespace Assignment1;

public partial class MainPage : ContentPage
{

    Users user = new Users();
    public MainPage()
    {
        InitializeComponent();
    }

    //checking for the entry fields is Fill up or not
    private async void btnregister_Clicked(object sender, EventArgs e)
    {                      
        var  result = await user.AddUser(txtfname.Text, txtlname.Text, txtmail.Text, txtpword.Text);
        if(result == true)
        {
                await DisplayAlert("Register", "Data Succesfully Saved", " OK!");
        }
        else
        {
            //IC_check();
            await DisplayAlert("Register", "Data Not Registered or your Email is already Exist or No Internet Connection", " OK!");
        }
     }
    //checking for there internet connection or not
    //private async void IC_check()
    //{
    //    if (CrossConnectivity.Current.IsConnected)
    //    {
    //        await DisplayAlert("Register", "Data Succesfully Sa ved", " OK!");
    //    }
    //    else
    //    {
    //        await DisplayAlert("Register", "Data Not Succesfully Saved or No Internet Connection", "OK!");
    //    }
    //}
    //Click button for exit or cancel
    private async void btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}


