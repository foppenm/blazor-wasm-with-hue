using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HueRegistration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ILocalHueClient client = new LocalHueClient("<Your Hue Ip address>");

            //Make sure the user has pressed the button on the bridge before calling RegisterAsync
            //It will throw an LinkButtonNotPressedException if the user did not press the button
            var appKey = await client.RegisterAsync("HomeHubAutomation", "HomeHub");
            client.Initialize(appKey);

            // Example call to see if it works
            var groups = await client.GetGroupsAsync();
        }
    }
}
