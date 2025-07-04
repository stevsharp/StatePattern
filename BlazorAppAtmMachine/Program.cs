using ATMState;

using BlazorAppAtmMachine;
using BlazorAppAtmMachine.State;
using BlazorAppAtmMachine.Vm;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<ATMMachine>();
builder.Services.AddSingleton<ATM>(sp => new ATM(1000)); // Initial cash in the ATM
builder.Services.AddTransient<HomeViewModel>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
