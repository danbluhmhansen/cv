using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

using Cv;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorise().AddBulmaProviders().AddFontAwesomeIcons();

await builder.Build().RunAsync();
