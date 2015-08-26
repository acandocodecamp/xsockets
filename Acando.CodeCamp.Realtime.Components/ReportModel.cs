using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace Acando.CodeCamp.Realtime
{
    public class ReportModel : Document, IScaleableMessage
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("week")]
        public int Week { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("projects")]
        public Project[] Projects { get; set; }

        [JsonProperty("hasScaled")]
        public bool HasScaled { get; set; }

        public class Project
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("monday")]
            public int Monday { get; set; }

            [JsonProperty("tuesday")]
            public int Tuesday { get; set; }

            [JsonProperty("wednesday")]
            public int Wednesday { get; set; }

            [JsonProperty("thursday")]
            public int Thursday { get; set; }

            [JsonProperty("friday")]
            public int Friday { get; set; }

            [JsonProperty("saturday")]
            public int Saturday { get; set; }

            [JsonProperty("sunday")]
            public int Sunday { get; set; }
        }
    }
}