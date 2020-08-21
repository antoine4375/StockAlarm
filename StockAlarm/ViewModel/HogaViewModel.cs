using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using StockAlarm.Model;
using StockAlarm.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace StockAlarm.ViewModel
{
    class HogaViewModel : BindableBase, IDisposable
    {
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand ComboBoxItemChangedCommand { get; private set; }

        private StockService _service;

        private Stockprice _stockprice;
        public Stockprice Stockprice
        {
            get { return _stockprice; }
            set { SetProperty(ref _stockprice, value); }
        }

        private IEventAggregator _eventAggregator;

        private List<Stock> _history;
        public List<Stock> History
        {
            get { return _history; }
            set { SetProperty(ref _history, value); }
        }

        private bool _upup;
        public bool UpUp
        {
            get { return _upup; }
            set { SetProperty(ref _upup, value); }
        }

        private bool _downdown;
        public bool DownDown
        {
            get { return _downdown; }
            set { SetProperty(ref _downdown, value); }
        }

        private bool _up;
        public bool Up
        {
            get { return _up; }
            set { SetProperty(ref _up, value); }
        }

        private bool _down;
        public bool Down
        {
            get { return _down; }
            set { SetProperty(ref _down, value); }
        }

        private string _rate;
        public string Rate
        {
            get { return _rate; }
            set { SetProperty(ref _rate, value); }
        }

        private string _stockColor;
        public string StockColor
        {
            get { return _stockColor; }
            set { SetProperty(ref _stockColor, value); }
        }

        private int _totalMedo;
        public int TotalMedo
        {
            get { return _totalMedo; }
            set { SetProperty(ref _totalMedo, value); }
        }
        private int _totalMesu;
        public int TotalMesu
        {
            get { return _totalMesu; }
            set { SetProperty(ref _totalMesu, value); }
        }

        private Stock selectedStock;
        public Stock SelectedStock
        {
            get { return selectedStock; }
            set { SetProperty(ref selectedStock, value); }
        }

        private DispatcherTimer timer;
        public HogaViewModel()
        {
            SearchCommand = new DelegateCommand(OnSearchCommand);
            ComboBoxItemChangedCommand = new DelegateCommand(OnComboBoxItemChangedCommand);
            _service = StockService.GetInstance();
            Stockprice = new Stockprice();

            _eventAggregator = Event.EventInstance.EventAggregator;

            var dm = DataManager.GetInstance();
            dm.LastView = DataManager.ViewType.Hoka;

            if (dm.History.Count != 0)
            {
                History = dm.History;
                SelectedStock = DataManager.GetInstance().History.First();
            }
           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(ReadRealTimeStock);

            timer.Start();
        }

        private void OnComboBoxItemChangedCommand()
        {
            throw new NotImplementedException();
        }

        private async void ReadRealTimeStock(object sender, EventArgs e)
        {
            timer.Stop();

            if (disposedValue)
            {
                return;
            }

            if (DataManager.GetInstance().History.Count == 0)
            {
                return;
            }

            var task = _service.GetHoga(SelectedStock.Code);

            var rawData = await task;
            var input = rawData.Replace("\n", "");

            XmlSerializer serializer = new XmlSerializer(typeof(Stockprice));
            StringReader rdr = new StringReader(input);
            Stockprice = (Stockprice)serializer.Deserialize(rdr);

            ArrowSelector();
            double current = Convert.ToDouble(Stockprice.TBL_StockInfo.Debi.Replace(",", ""));
            double prev = Convert.ToDouble(Stockprice.TBL_StockInfo.PrevJuka.Replace(",",""));
            Rate = Math.Round(current / prev * 100, 2).ToString() + "%";

            TotalMedo = Convert.ToInt32(Stockprice.TBL_Hoga.MedoJan0.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MedoJan1.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MedoJan2.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MedoJan3.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MedoJan4.Replace(",", ""));
            TotalMesu = Convert.ToInt32(Stockprice.TBL_Hoga.MesuJan0.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MesuJan1.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MesuJan2.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MesuJan3.Replace(",", "")) + Convert.ToInt32(Stockprice.TBL_Hoga.MesuJan4.Replace(",", ""));

            timer.Start();
        }

        private void ArrowSelector()
        {
            Up = false;
            UpUp = false;
            Down = false;
            DownDown = false;

            switch (Stockprice.TBL_StockInfo.DungRak)
            {
                case "1": UpUp = true; StockColor = "Red";  break;
                case "2": Up = true; StockColor = "Red"; break;
                case "3": StockColor = "Black"; break;
                case "4": DownDown = true; StockColor = "Blue"; break;
                case "5": Down = true; StockColor = "Blue"; break;
            }
        }

        private void OnSearchCommand()
        {
            _eventAggregator.GetEvent<SearchViewOpenMessage>().Publish();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                    timer.Stop();
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~HogaViewModel() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
