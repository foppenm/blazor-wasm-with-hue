using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System.Threading.Tasks;

namespace HomeHub
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<ILocalHueClient>(options =>
            {
                ILocalHueClient client = new LocalHueClient("<Your Hue Ip address>");
                client.Initialize("<Your Hue Api key from the registration app>");
                return client;
            });
            await builder.Build().RunAsync();
        }
    }
}
