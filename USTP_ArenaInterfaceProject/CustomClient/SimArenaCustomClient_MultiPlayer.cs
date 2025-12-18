using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.CustomClient
{
    public class SimArenaCustomClient_MultiPlayer
    {
        //###############################################################################################################################################
        //NOTE: The methods were intentionally made synchronous so that the return types are clean data types like "string" or "List<string>"
        //instead of returning a Task that would have to be awaited or cast. Normally, API requests should be implemented as async Task<T>...
        //###############################################################################################################################################

        //
        //Base Url as constant:
        //
        private const string BASE_URL = "https://battlearena-fjesghhhbugdasfp.westeurope-01.azurewebsites.net";

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
            var responseBody = HttpHelper.GetSync(httpClient, BASE_URL + "/MultiPlayer/alive");
            return HttpHelper.ReadString(responseBody);
        }

        public int GetNewArena()
        {
            var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/Multiplayer/reserve-new-arenaId", null);
            return HttpHelper.ReadInt(responseBody);
        }

        public string SendCharacter<T>(T item, int arenaId)
        {
            if (item == null) return "Error: input is missing!.";

            var responseBody = HttpHelper.PostSync(httpClient, BASE_URL + "/Multiplayer/send-character-to-arena/" + arenaId, item);
            return HttpHelper.ReadString(responseBody);
        }

        public List<string> GetFightingResult(int arenaId)
        {
            var responseBody = HttpHelper.GetSync(httpClient, BASE_URL + "/Multiplayer/get-fight-from-arena/" + arenaId);
            return HttpHelper.ReadList(responseBody);
        }

        public string GetRandomCharAsJsonString(int? maxPoints)
        {
            string url = BASE_URL + "/Multiplayer/get-random-skillpoint-character";
            if (maxPoints.HasValue)
            {
                url += $"?maxPoints={maxPoints.Value}";
            }

            var responseBody = HttpHelper.GetSync(httpClient, url);
            return HttpHelper.ReadString(responseBody);
        }



    }
}
