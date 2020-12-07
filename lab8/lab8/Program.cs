using MbDotNet;
using MbDotNet.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab8
{
    public class Coin
    {
        public string Key { get; set; }
        public decimal Rate { get; set; }

        public Coin()
        {

        }
    }

    class Program
    {
        static async Task GetRequest(string key)
        {
            var request = "http://localhost:8070/rate/" + key;
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"\r\nRequest: {request} \r\nSatus code: {response.StatusCode} \r\nContent: {text}");
            }
            else
            {
                Console.WriteLine($"\r\nRequest: {request} \r\nSatus code: {response.StatusCode}");
            }
            Console.WriteLine();
        }
        // private readonly HttpClient _httpClient = new HttpClient();
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new MountebankClient();
            var imposter = client.CreateHttpImposter(8070);
            var usdcoin = new Coin { Key = "usd", Rate = 22.22m };

            imposter.AddStub().ReturnsJson(HttpStatusCode.OK, usdcoin).OnPathAndMethodEqual($"/rate/{usdcoin.Key}", Method.Get);

            var rubcoin = new Coin { Key = "rub", Rate = 5.22m };
            imposter.AddStub().ReturnsJson(HttpStatusCode.OK, rubcoin).OnPathAndMethodEqual($"/rate/{rubcoin.Key}", Method.Get);

            var eurcoin = new Coin { Key = "eur", Rate = 25.22m };
            imposter.AddStub().ReturnsJson(HttpStatusCode.OK, eurcoin).OnPathAndMethodEqual($"/rate/{eurcoin.Key}", Method.Get);

            imposter.AddStub().ReturnsStatus(HttpStatusCode.BadRequest);

            client.Submit(imposter);

            await GetRequest("usd");
            await GetRequest("rub");
            await GetRequest("eur");
            await GetRequest("yuan");

            client.DeleteAllImposters();
        }
    }
}
