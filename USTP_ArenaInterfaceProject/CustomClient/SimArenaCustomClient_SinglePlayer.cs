using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MyProject.CustomClient
{
    public class SimArenaCustomClient_SinglePlayer
    {
        //###############################################################################################################################################
        //NOTE: The methods were intentionally made synchronous so that the return types are clean data types like "string" or "List<string>"
        //instead of returning a Task that would have to be awaited or cast. Normally, API requests should be implemented as async Task<T>...
        //###############################################################################################################################################

        //
        //Base Url as constant:
        //
        private const string BASE_URL = "https://simarena-ahasg3auane8dhe0.germanywestcentral-01.azurewebsites.net";

        ////Local BASE_URL for Testing:
        //private const string BASE_URL = "https://localhost:7071"; //change if your local version is another URL

        //
        //Prepare HttpClient
        //
        private readonly HttpClient httpClient = new HttpClient();

        //
        //GET: Check if the API is available.
        //
        public string GetAlive()
        {
            var responseBody = HttpHelper.GetSync(httpClient, BASE_URL + "/SinglePlayer/alive");
            return HttpHelper.ReadString(responseBody);
        }

        //
        //POST Version_1: Character fights a Straw-Puppet with Stat-Check only (no Accuracy, just raw dmg-def):
        //
        public string PostFirstArena<T>(T item)
        {
            try
            {
                if (item == null) return "Error: input is missing!.";
                //To avoid the need for a predefined class that reveals how the student should do this,
                //a generic type parameter “T” is simply required here, and then a JSON is simply sent to the API.
                var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/SinglePlayer/FirstArena", item);
                return HttpHelper.ReadString(responseBody);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //
        //POST Version_2: Character challenge against another Straw-Puppet with new rules, the response is a List<string>:
        //
        public List<string> PostSecondArena<T>(T item)
        {
            try
            {
                if (item == null) return new List<string> { "Error: input is missing!" };
                var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/SinglePlayer/SecondArena", item);
                return HttpHelper.ReadList(responseBody);
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }

        //
        //POST Version_2 1vs1: It is possible to send 2 Characters which will fight each other, so a rogue-like / rogue-lite / rpg or something else can be created.
        //
        public List<string> PostSecondArena_OneVSOne<T>(T item)
        {
            try
            {
                if (item == null) return new List<string> { "Error: input is missing!" };
                var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/SinglePlayer/SecondArena-1vs1", item);
                return HttpHelper.ReadList(responseBody);
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }

        //
        // POST Version_3: Character (now with a List of tactic options) let 2 characters step into the arena:
        //
        public List<string> PostThirdArena<T>(T item)
        {
            try
            {
                if (item == null) return new List<string> { "Error: input is missing!" };
                var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/SinglePlayer/ThirdArena", item);
                return HttpHelper.ReadList(responseBody);
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }

        //
        //POST: It is possible to send 2 Characters which will fight each other, so a rogue-like / rogue-lite / rpg or something else can be created.
        //
        public List<string> ThirdArena_OneVSOne<T>(T item)
        {
            try
            {
                if (item == null) return new List<string> { "Error: input is missing!" };
                var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/SinglePlayer/ThirdArena-1vs1", item);
                return HttpHelper.ReadList(responseBody);
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }
    }
}
