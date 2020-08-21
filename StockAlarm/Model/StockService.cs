using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAlarm.Model
{
    public class StockService
    {
        private static readonly StockService _instance = new StockService();

        private static readonly string _getHoga = "http://asp1.krx.co.kr/servlet/krx.asp.XMLSiseEng?code={0}";

        private StockService() { }

        public static StockService GetInstance()
        {
            return _instance;
        }

        public async Task<string> GetHoga(string stockCode)
        {
            string url = string.Format(_getHoga, stockCode);
            return await RestResponse(url);
        }

        private async Task<string> RestResponse(string url)
        {
            string responseText = string.Empty;

            HttpClient client = new HttpClient();
            //client.Timeout = TimeSpan.FromSeconds(2);
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.GetAsync(url);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    responseText = await response.Content.ReadAsStringAsync();
                    return responseText;
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
            return string.Empty;
        }
    }
}
