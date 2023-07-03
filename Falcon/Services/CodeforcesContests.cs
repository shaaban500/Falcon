using Falcon.Models;
using Newtonsoft.Json;

namespace Falcon.Services
{
    public class CodeforcesContests : ICodeforcesContests
    {
        public async Task<Contest?> GetUpComing()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://kontests.net/api/v1/codeforces");
            var responseContent = await response.Content.ReadAsStringAsync();
            var contests = JsonConvert.DeserializeObject<List<Contest>>(responseContent);

            if(contests != null)
            {
                foreach (var contest in contests)
                {
                    if(contest.StartTime.ToShortDateString() == DateTime.UtcNow.AddHours(3).ToShortDateString()) 
                    {
                        return contest;
                    }
                }
            }

            return null;
        }
    }
}
