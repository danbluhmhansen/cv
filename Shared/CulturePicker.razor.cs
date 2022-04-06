namespace Cv.Shared;

using System.Globalization;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public partial class CulturePicker : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; }
    [Inject] private NavigationManager Nav { get; set; }

    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-UK"),
        new CultureInfo("da-DK"),
    };

    private string[] cultureImages = new[]
    {
        "https://raw.githubusercontent.com/lipis/flag-icons/main/flags/4x3/gb.svg",
        "https://raw.githubusercontent.com/lipis/flag-icons/main/flags/4x3/dk.svg",
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);

                Nav.NavigateTo(Nav.Uri, forceLoad: true);
            }
        }
    }

    private string CurrentCultureImage() => CultureInfo.CurrentCulture.Name == "en-UK"
        ? this.cultureImages[0]
        : this.cultureImages[1];

    private void SetCultureEn() => this.Culture = this.supportedCultures[0];
    private void SetCultureDa() => this.Culture = this.supportedCultures[1];
}
