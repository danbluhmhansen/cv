namespace Cv.Pages;

using Microsoft.AspNetCore.Components;

public partial class Index : ComponentBase
{
    private bool languageDropDownActive;
    private string languageDropDownActiveClass => languageDropDownActive ? "is-active" : string.Empty;

    private void ToggleLanguageDropDown() => this.languageDropDownActive = !this.languageDropDownActive;
}
