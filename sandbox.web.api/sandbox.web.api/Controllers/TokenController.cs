using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sandbox.web.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace sandbox.web.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TokenController : ControllerBase
    {
        //// GET: TokenController
        [HttpGet]
        public async Task<IEnumerable<Token>> GetTopHundred()
        {
            List<Token> tokenList = new List<Token>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tokenList = JsonConvert.DeserializeObject<List<Token>>(apiResponse);
                }
                return tokenList;
            }
        }

        //public async Task<IEnumerable<Token>> GetById(string id)
        //{
        //    Token token = new Token();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            token = JsonConvert.DeserializeObject<Token>(apiResponse);
        //        }
        //        return token;
        //    }
        //}
    }
}
