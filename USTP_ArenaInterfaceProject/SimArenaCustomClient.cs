using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace USTP_ArenaInterfaceProject
{
    public class SimArenaCustomClient
    {
        //###############################################################################################################################################
        //NOTE: The methods were intentionally made synchronous so that the return types are clean data types like "string" or "List<string>"
        //instead of returning a Task that would have to be awaited or cast. Normally, API requests should be implemented as async Task<T>...
        //###############################################################################################################################################

        //
        //Prepare HttpClient
        //
        private readonly HttpClient httpClient = new HttpClient();

        //
        //Base Url as constant:
        //
        private const string BASE_URL = "https://simarena-ahasg3auane8dhe0.germanywestcentral-01.azurewebsites.net";

        ////Local BASE_URL for Testing:
        //private const string BASE_URL = "https://localhost:7071";

        //
        //GET: Check if the API is available.
        //
        public string GetAlive()
        {
            var response = httpClient.GetAsync(BASE_URL + "/fight/alive").GetAwaiter().GetResult();

            if (response == null) return "Response ist null, go and debug.";
            if (!response.IsSuccessStatusCode) throw new Exception(response.StatusCode.ToString());

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return content;
        }

        //
        //POST Version_1: Character fights a Straw-Puppet with Stat-Check only (no Accuracy, just raw dmg-def):
        //
        public string PostFirstFight<T>(T item)
        {
            try
            {
                //Damit keine vorgefertigte Klasse nötig ist, die verrät wie der Student das machen müsste,
                //wird hier einfach ein generischer Typ-Parameter "T" verlangt und dann wird einfach ein JSON an die API gesendet.
                string json = JsonSerializer.Serialize(item);

                var sendingContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(BASE_URL + "/fight/FirstFight", sendingContent).GetAwaiter().GetResult();

                if (response == null) return "Response is null, go and debug.";
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    throw new HttpRequestException($"API response = {response.StatusCode}: {errorBody}");
                }

                string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return responseContent;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //
        //GET: 2 random Fighter fight each other. So, it is possible to check how to output the returned List<string>:
        //
        public List<string> GetRandomFight_v3()
        {
            List<string>? response = httpClient.GetFromJsonAsync<List<string>>((BASE_URL + "/fight/let-random-chars-v3-fight")).GetAwaiter().GetResult();

            return response ?? new List<string> { "ERROR" };
        }


        //
        //POST Version_2: Character fight another Straw-Puppet with new fighting rules, but as tested before, the response is a List<string>:
        //
        public List<string> PostSecondFight<T>(T item)
        {
            try
            {
                string json = JsonSerializer.Serialize(item);

                var sendingContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(BASE_URL + "/fight/SecondFight", sendingContent).GetAwaiter().GetResult();

                if (response == null) return new List<string> { "Error, --response-- is null, go and debug." };
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    throw new HttpRequestException($"API response = {response.StatusCode}: {errorBody}");
                }

                string returnJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                List<string>? _list = JsonSerializer.Deserialize<List<string>>(returnJson);

                return _list ?? new List<string> { "Error, --List-- is null, go and debug." };
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }

        //
        // POST Version_3: Character (now with a List of fighting options) fight a random generated Character:
        //
        public List<string> PostThirdFight<T>(T item)
        {
            try
            {
                string json = JsonSerializer.Serialize(item);

                var sendingContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(BASE_URL + "/fight/fight-a-random-char-v3", sendingContent).GetAwaiter().GetResult();

                if (response == null) return new List<string> { "Error, --response-- is null, go and debug." };
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    throw new HttpRequestException($"API response = {response.StatusCode}: {errorBody}");
                }

                string returnJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                List<string>? _list = JsonSerializer.Deserialize<List<string>>(returnJson);

                return _list ?? new List<string> { "Error, --List-- is null, go and debug." };
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }

        //
        //POST: It is possible to send 2 Characters which will fight each other, so a rogue-like / rogue-lite / rpg or something else can be created.
        //
        public List<string> PostOneVSOne<T>(T item)
        {
            try
            {
                string json = JsonSerializer.Serialize(item);

                var sendingContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(BASE_URL + "/fight/ThirdFight-1vs1", sendingContent).GetAwaiter().GetResult();

                if (response == null) return new List<string> { "Error, --response-- is null, go and debug." };
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    throw new HttpRequestException($"API response = {response.StatusCode}: {errorBody}");
                }

                string returnJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                List<string>? _list = JsonSerializer.Deserialize<List<string>>(returnJson);

                return _list ?? new List<string> { "Error, --List-- is null, go and debug." };
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }


        //
        //POST: If the SkillPoint-System is not for your liking, here a raw-Character-builder for Version_3
        //      The Fighting stays the same (Roll Accuracy for HitChance, Roll Dmg from Min-Max, Roll Def from Min-Max)
        //      When also the Rock-Paper-Sissor System is not for your liking, just fill the List<string> with one "balanced" input.
        //
        public List<string> PostOneVSOne_OwnSkillPoints<T>(T item)
        {
            try
            {
                string json = JsonSerializer.Serialize(item);

                var sendingContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(BASE_URL + "/fight/RawCharFight", sendingContent).GetAwaiter().GetResult();

                if (response == null) return new List<string> { "Error, --response-- is null, go and debug." };
                if (!response.IsSuccessStatusCode)
                {
                    string errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    throw new HttpRequestException($"API response = {response.StatusCode}: {errorBody}");
                }

                string returnJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                List<string>? _list = JsonSerializer.Deserialize<List<string>>(returnJson);

                return _list ?? new List<string> { "Error, --List-- is null, go and debug." };
            }
            catch (Exception e)
            {
                return new List<string> { e.Message };
            }
        }


    }
}
