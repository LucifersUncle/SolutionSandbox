using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sandbox.web.app.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace sandbox.web.app.Controllers
{
    public class TokenController : Controller
    {
        #region Actions
        public async Task<ActionResult> Index()
        {
            List<Token> tokenList = new List<Token>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/Token"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tokenList = JsonConvert.DeserializeObject<List<Token>>(apiResponse);
                }
                return View(tokenList);
            }
        }
        #endregion

        #region Methods
       // public async Task<IEnumerable<Token>>

        #endregion
    }
}
