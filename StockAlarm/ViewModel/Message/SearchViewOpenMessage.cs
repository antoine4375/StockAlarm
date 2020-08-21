using Prism.Events;
using StockAlarm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlarm.ViewModel.Message
{
    class SearchViewOpenMessage : PubSubEvent { }
    class StockSelectMessage: PubSubEvent<Stock> { }
}
