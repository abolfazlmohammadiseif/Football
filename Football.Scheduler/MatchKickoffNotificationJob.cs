using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Football.Domain.Models;
using NServiceBus;
using Quartz;
using Serilog;

public class MatchKickoffNotificationJob : IJob
{
    static ILogger log = Log.ForContext<MatchKickoffNotificationJob>();
    public static IMatchRepository matchRepository { get; set; }

    public async Task Execute(IJobExecutionContext context)
    {
        var matches = await matchRepository.GetUpcomingMatchesAsync(5);
        foreach (var match in matches)
        {
            var data = new List<int>();
            data.AddRange(match.HomePlayers.Select(p => p.Id).ToList());
            data.AddRange(match.AwayPlayers.Select(p => p.Id).ToList());
            var json = "[" + string.Join(",", data) + "]";

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://interview-api.azurewebsites.net/api/")
            };

            var webRequest = new HttpRequestMessage(HttpMethod.Post, "IncorrectAlignment")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = client.Send(webRequest);
            var reader = new StreamReader(response.Content.ReadAsStream());
            var responseBody = reader.ReadToEnd();
        }
    }
}
