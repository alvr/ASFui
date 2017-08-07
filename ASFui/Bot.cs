using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace ASFui
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Bot
    {
        internal sealed class Root
        {
            [JsonProperty("Bots")]
            public Dictionary<string, Bots> Bot { get; set; }
        }

        internal sealed class Bots
        {
            [JsonProperty("CardsFarmer")]
            public CardsFarmer CardsFarmer { get; set; }

            [JsonProperty("KeepRunning")]
            public bool KeepRunning { get; set; }
        }

        internal sealed class CardsFarmer
        {
            [JsonProperty("GamesToFarm")]
            public HashSet<Game> GamesToFarm { get; set; }

            [JsonProperty("CurrentGamesFarming")]
            public HashSet<Game> CurrentGamesFarming { get; set; }

            [JsonProperty("Paused")]
            public bool Paused { get; set; }
        }

        internal sealed class Game
        {
            [JsonProperty("AppID")]
            public uint AppID { get; set; }

            [JsonProperty("GameName")]
            public string GameName { get; set; }

            [JsonProperty("HoursPlayed")]
            public float HoursPlayed { get; set; }

            [JsonProperty("CardsRemaining")]
            public ushort CardsRemaining { get; set; }
        }
    }
}