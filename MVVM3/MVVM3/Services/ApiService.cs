using MVVM3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVM3.Services
{
    public class ApiService
    {
        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://luisperseo-001-site1.itempurl.com");
                var url = "/api/ordes";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Order>();
                }
                var result = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<Order>>(result);
                return orders;
            }
            catch 
            {

                return new List<Order> ();
            }
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                var content = JsonConvert.SerializeObject(order);
                var body = new StringContent(content,Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://luisperseo-001-site1.itempurl.com");
                var url = "/api/ordes";
                var response = await client.PostAsync(url,body);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();
                var newOrder = JsonConvert.DeserializeObject<Order>(result);
                return newOrder;
            }
            catch
            {

                return null;
            }
        }

    }
}
