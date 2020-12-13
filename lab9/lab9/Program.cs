using Newtonsoft.Json;
using System;
using System.Text;

namespace ApiLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            JsonProduct json = new JsonProduct();
            string temp = JsonConvert.SerializeObject(json);

            Console.WriteLine(temp);

            ApiRequest api = new ApiRequest();
            ApiCreateResponse createResponse = api.CreateProduct(ref json);
            if (createResponse.statusCode == 200)
                Console.WriteLine("Creation complete");

            Console.WriteLine(createResponse.id);
        }
    }
}