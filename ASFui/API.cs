using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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

        public string AllApi()
        {
            var result = new StringBuilder();

            foreach (var bot in GetBots())
            {
                result.Append(@"◈ Bot: " + bot + Environment.NewLine);
                result.Append(@"    ⟐ Active: " + _data.Bot[bot].KeepRunning + Environment.NewLine);

                var games = _data.Bot[bot].CardsFarmer.GamesToFarm;
                if (games.Count > 0)
                {
                    result.Append(@"    ⟐ Games to Farm:" + Environment.NewLine);

                    foreach (var game in games)
                    {
                        var timePlayed = TimeSpan.FromHours(game.HoursPlayed);
                        result.Append(@"        ◇ " + game.GameName + @"; Hours Played: " 
                            + $"{timePlayed.Hours:00}:{timePlayed.Minutes:00}"
                            + @"; Cards Remaining: " + game.CardsRemaining + Environment.NewLine);
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
                        result.Append(@"        ◇ " + game.GameName + Environment.NewLine);
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
