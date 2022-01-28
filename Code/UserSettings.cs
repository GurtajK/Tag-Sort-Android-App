using Microsoft.Maui.Essentials;

namespace TagSort.Code;

public static class UserSettings
{
    const bool dark = false;

    public static bool Dark
    {
        get => Preferences.Get(nameof(Dark), dark);
        set => Preferences.Set(nameof(Dark), value);
    }

    public static void changeTheme()
    {
        var dark = "#262626";
        var darkGray = "#9e9e9e";
        var light = "#f7f7f7";
        var lightGray = "#7d7d7d";

        switch (Dark)
        {
            case true:
                App.Current.Resources["Primary"] = dark;
                App.Current.Resources["Secondary"] = light;
                App.Current.Resources["Accent"] = darkGray;
                break;
            case false:
                App.Current.Resources["Primary"] = light;
                App.Current.Resources["Secondary"] = dark;
                App.Current.Resources["Accent"] = lightGray;
                break;
        }
    }
}
