using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Football.Worker.Tasks
{
    public class MatchKickoffNotificationTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            //Write your custom code here
            return Task.FromResult(true);


            var task = Task.Run(() => logfile(DateTime.Now)); ;
            return task;
        }
        public void logfile(DateTime time)
        {
            //todo: Notification goes here....
            var json = "[1,2,3]";

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://interview-api.azurewebsites.net/api/IncorrectAlignment")
            };

            var webRequest = new HttpRequestMessage(HttpMethod.Post, "sms")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            //webRequest.Headers.Add("user_key", tokens[0]);
            //webRequest.Headers.Add("Session_key", tokens[1]);

            var response = client.Send(webRequest);
            var reader = new StreamReader(response.Content.ReadAsStream());
            var responseBody = reader.ReadToEnd();



            //string path = "C:\\log\\sample.txt";
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.WriteLine(time);
            //    writer.Close();
            //}
        }
    }
}
