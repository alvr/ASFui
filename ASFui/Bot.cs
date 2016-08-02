using System.Collections.Generic;
using Newtonsoft.Json;

namespace ASFui
{
    public class Bot
    {
        public class Root
        {
            [JsonProperty("Bots")]
            public Dictionary<string, Bots> Bot { get; set; }
        }

        public class Bots
        {
            [JsonProperty("CardsFarmer")]
            public CardsFarmer CardsFarmer { get; set; }

            [JsonProperty("KeepRunning")]
            public bool KeepRunning { get; set; }
        }

        public class CardsFarmer
        {
            [JsonProperty("GamesToFarm")]
            public Dictionary<uint, float> GamesToFarm { get; set; }

            [JsonProperty("CurrentGamesFarming")]
            public HashSet<uint> CurrentGamesFarming { get; set; }

            [JsonProperty("ManualMode")]
            public bool ManualMode { get; set; }
        }

    }
}
