namespace ProcessingJSONinDotNET
{
    using System;
    using Newtonsoft.Json;

    public class Item
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("a10:updated")]
        public DateTime UpdatedDate { get; set; }
    }
}