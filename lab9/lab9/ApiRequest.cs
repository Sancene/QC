using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ApiLab
{
    public class ApiRequest
    {
        const string BASE_URL = "http://91.210.252.240:9010/api/";
        private static HttpClient client = new HttpClient();

        public HttpResponseMessage GetAllProducts()
        {
            var response = client.GetAsync(BASE_URL + "products").Result;
            return response;
        }

        public int DeleteProduct(int id)
        {
            var response = client.GetAsync(BASE_URL + "deleteproduct?id=" + id).Result;
            return response.StatusCode.GetHashCode();
        }

        public ApiCreateResponse CreateProduct(ref JsonProduct product)
        {
            var json = JsonSerializer.Serialize(product);
            var data = new StringContent(json, Encoding.UTF8);

            Console.WriteLine("PRODUCT CREATION " + data.ReadAsStringAsync().Result);

            var response = client.PostAsync(BASE_URL + "addproduct", data).Result;

            ApiCreateResponse createResponse = JsonSerializer.Deserialize<ApiCreateResponse>(response.Content.ReadAsStringAsync().Result);
            createResponse.statusCode = response.StatusCode.GetHashCode();
            return createResponse;
        }

        public int EditProduct(ref JsonProduct product)
        {
            var json = JsonSerializer.Serialize(product);
            var data = new StringContent(json, Encoding.UTF8);

            Console.WriteLine(data.ReadAsStringAsync().Result);

            var response = client.PostAsync(BASE_URL + "editproduct", data).Result;

            return response.StatusCode.GetHashCode();
        }
    }

    public class ApiCreateResponse
    {
        public int id { get; set; }
        public int statusCode { get; set; }
    }
}