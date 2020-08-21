using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using StockAlarm.Model;
using StockAlarm.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlarm.ViewModel
{
    class SearchViewModel : BindableBase
    {
        private List<Stock> stocks;
        public List<Stock> Stocks
        {
            get { return stocks; }
            set { SetProperty(ref stocks, value); }
        }

        private IEventAggregator _eventAggregator;
        private string stockName;
        public string StockName
        {
            get { return stockName; }
            set { SetProperty(ref stockName, value); }
        }

        public DelegateCommand SearchCommand { get; private set; }

        public DelegateCommand<Stock> StockSelectCommand { get; private set; }
        public SearchViewModel()
        {
            //Stocks = DataManager.GetInstance().Stocks;
            SearchCommand = new DelegateCommand(OnSearchCommand);
            StockSelectCommand = new DelegateCommand<Stock>(OnStockSelectCommand);
            Stocks = new List<Stock>();
            _eventAggregator = Event.EventInstance.EventAggregator;
        }

        private void OnStockSelectCommand(Stock obj)
        {
            var dm = DataManager.GetInstance();
            if (dm.LastView == DataManager.ViewType.Hoka)
            {
                dm.History.Add(obj);
            }
            _eventAggregator.GetEvent<StockSelectMessage>().Publish(obj);
        }

        private void OnSearchCommand()
        {
            Stocks = DataManager.GetInstance().Stocks.FindAll(m => m.Name.Contains(StockName));
        }
    }
}
