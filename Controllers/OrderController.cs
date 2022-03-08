using MenuItemListingWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using OrderItemWebApi.Models;
using System.Net.Http.Headers;

namespace OrderItemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        List<Cart> cart;
        [HttpPost]
        public async Task<List<Cart>> CreateCart(int menuitemid)
        {
            var client = new HttpClient();
            string url = $"https://localhost:44343/api/MenuItem/id?id={menuitemid}";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var Res = client.GetAsync(url).Result;
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = await client.GetAsync(url);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                var PrdInfo = JsonConvert.DeserializeObject<MenuItem>(ProductResponse);
                cart = new List<Cart>()
            {
                new Cart()
                {
                    Id=1,
                    userId=1,
                    menuItemId=PrdInfo.Id,
                    menuItemName=PrdInfo.Name
                }
            };
                return cart;
            }
            else
            {
                return null;
            }


        }


    }
}
