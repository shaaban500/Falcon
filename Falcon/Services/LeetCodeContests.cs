using Falcon.Models;
using Newtonsoft.Json;

namespace Falcon.Services
{
    public class LeetCodeContests : ILeetCodeContests
    {
        public async Task<Contest?> GetUpComing()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://kontests.net/api/v1/leet_code");
            var responseContent = await response.Content.ReadAsStringAsync();
            var contests = JsonConvert.DeserializeObject<List<Contest>>(responseContent);

            var biweeklyContest = contests?.FirstOrDefault(x => x.Name.Contains("Biweekly"));

            if (biweeklyContest != null && biweeklyContest.StartTime.ToShortDateString() == DateTime.UtcNow.AddHours(3).ToShortDateString())
            {
                return biweeklyContest;
            }

            return null;
        }
    }
}
