using MahApps.Metro.Controls;
using Prism.Events;
using StockAlarm.Model;
using StockAlarm.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockAlarm.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private IEventAggregator _eventAggregator;

        private enum ViewType
        {
            Hoga, 
            Search
        }

        private ViewType _lastView;

        public MainWindow()
        {
            InitializeComponent();

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;

            DataManager.GetInstance().ReadStockList();

            _eventAggregator = Event.EventInstance.EventAggregator;
            _eventAggregator.GetEvent<SearchViewOpenMessage>().Subscribe(PageMoveToSearch);
            _eventAggregator.GetEvent<StockSelectMessage>().Subscribe(PageMove);

            _mainFrame.Navigate(new HogaView());
            _lastView = ViewType.Hoga;

            this.Closed += delegate
            {
                _eventAggregator.GetEvent<SearchViewOpenMessage>().Unsubscribe(PageMoveToSearch);
                _eventAggregator.GetEvent<StockSelectMessage>().Unsubscribe(PageMove);
            };
        }

        private void PageMove(Stock obj)
        {
            switch (_lastView)
            {
                case ViewType.Hoga:
                    _mainFrame.Navigate(new HogaView());
                    break;
            }
        }

        private void PageMoveToSearch()
        {
            _mainFrame.Navigate(new SearchView());
        }
    }
}
