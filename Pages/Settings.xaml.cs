using Microsoft.Maui.Controls;
using TagSort.Code;

namespace TagSort.Pages;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();

        if (DarkMode == null)
        {
            return;
        }

        switch (UserSettings.Dark)
        {
            case true:
                DarkMode.IsToggled = true;
                break;
            case false:
                DarkMode.IsToggled = false;
                break;
        }
    }

    void DarkToggled(object sender, EventArgs e)
    {
        if (DarkMode.IsToggled)
            UserSettings.Dark = true;
        else
            UserSettings.Dark = false;

        UserSettings.changeTheme();
    }

    public async void ClearTags(object sender, EventArgs e)
    {
        string title = "Remove all tags?";
        string message = "This action is irreversiable./n Are you sure you want to continue?";
        bool verification = await DisplayAlert(title, message, "Yes", "Cancel");
        if (verification)
        {
            database.ClearTags();
            database.PrevCol = 0;
            database.ApproxPixels = 0;
            database.initTags();
        }
    }
}
