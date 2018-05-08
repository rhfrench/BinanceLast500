using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Last500Trades
{
    public class APIService
    {

        public async Task<List<TradeModel>> GetLast500(string symbol)
        {
            //string json = JsonConvert.SerializeObject(log);
            HttpClient client = new HttpClient();
            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.GetAsync("https://api.binance.com/api/v1/trades?symbol=" + symbol);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<TradeModel> model = JsonConvert.DeserializeObject<List<TradeModel>>(json);

                return model;
            }

            return new List<TradeModel>(); ;
        }
    }
}
