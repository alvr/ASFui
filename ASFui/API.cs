using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASFui
{
    public class Api
    {
        private readonly Bot.Root _data;
        public Api(string result)
        {
            _data = JsonConvert.DeserializeObject<Bot.Root>(result);
        }

        private IEnumerable<string> GetBots()
        {
            return _data.Bot.Keys;
        }

        private static string GetAppName(uint id)
        {
            var url = "http://store.steampowered.com/api/appdetails?appids=" + id;
            var content = new WebClient().DownloadString(url);
            var json = JObject.Parse(content);
            return json[id.ToString()]["data"]["name"].ToString();
        }

        public string AllApi()
        {
            var result = new StringBuilder();

            foreach (var bot in GetBots())
            {
                result.Append(@"◈ Bot: " + bot + Environment.NewLine);
                result.Append(@"    ⟐ Active: " + _data.Bot[bot].KeepRunning + Environment.NewLine);

                var games = _data.Bot[bot].CardsFarmer.GamesToFarm;
                if (games.Keys.Count > 0)
                {
                    result.Append(@"    ⟐ Games to Farm:" + Environment.NewLine);

                    foreach (var game in games)
                    {
                        var timePlayed = TimeSpan.FromHours(game.Value);
                        result.Append(@"        ◇ " + GetAppName(game.Key) + @"; Time Farmed: " 
                            + string.Format("{0:00}:{1:00}", timePlayed.Hours, timePlayed.Minutes) + Environment.NewLine);
                    }
                }
                else
                {
                    result.Append(@"    ⟐ Games to Farm: None" + Environment.NewLine);
                }


                var farming = _data.Bot[bot].CardsFarmer.CurrentGamesFarming;
                if (farming.Count > 0)
                {
                    result.Append(@"    ⟐ Current Farming:" + Environment.NewLine);

                    foreach (var game in farming)
                    {
                        result.Append(@"        ◇ " + GetAppName(game) + Environment.NewLine);
                    }
                }
                else
                {
                    result.Append(@"    ⟐ Current Farming: Nothing" + Environment.NewLine);
                }

                result.Append(@"    ⟐ Manual: " + _data.Bot[bot].CardsFarmer.ManualMode + Environment.NewLine);

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
