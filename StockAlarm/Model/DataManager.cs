using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlarm.Model
{
    public class DataManager
    {
        private static readonly DataManager _instance = new DataManager();

        private DataManager() { }

        public List<Stock> Stocks = new List<Stock>();

        public List<Stock> History = new List<Stock>();

        public enum ViewType
        {
            Hoka
        };

        public ViewType LastView { get; set; }

        public static DataManager GetInstance() { return _instance; }

        public void ReadStockList()
        {
            string[] lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\StockList.txt");

            Stocks.Clear();
            foreach (var item in lines)
            {
                var stock = item.Split('\t');
                Stocks.Add(new Stock() { Code = stock[1], Name = stock[0] });
            }
        }
    }
}
