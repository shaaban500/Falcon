using Newtonsoft.Json;

namespace Falcon.Models
{
    public class Contest
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
        
        [JsonProperty("url")]
        public required string URL { get; set; }
        
        [JsonProperty("start_time")]
        public required DateTime StartTime { get; set; }
        
        [JsonProperty("end_time")]
        public required DateTime EndTime { get; set; }
        
        [JsonProperty("duration")]
        public required int Duration { get; set; }
        
        [JsonProperty("in_24_hours")]
        public required string In24Hours { get; set; }
    }
}
