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
}
