using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Prism.Mvvm;

namespace StockAlarm.Model
{
    [XmlRoot(ElementName = "DailyStock")]
    public class DailyStock
    {
        [XmlAttribute(AttributeName = "day_Date")]
        public string Day_Date { get; set; }
        [XmlAttribute(AttributeName = "day_EndPrice")]
        public string Day_EndPrice { get; set; }
        [XmlAttribute(AttributeName = "day_Dungrak")]
        public string Day_Dungrak { get; set; }
        [XmlAttribute(AttributeName = "day_getDebi")]
        public string Day_getDebi { get; set; }
        [XmlAttribute(AttributeName = "day_Start")]
        public string Day_Start { get; set; }
        [XmlAttribute(AttributeName = "day_High")]
        public string Day_High { get; set; }
        [XmlAttribute(AttributeName = "day_Low")]
        public string Day_Low { get; set; }
        [XmlAttribute(AttributeName = "day_Volume")]
        public string Day_Volume { get; set; }
        [XmlAttribute(AttributeName = "day_getAmount")]
        public string Day_getAmount { get; set; }
    }

    [XmlRoot(ElementName = "TBL_DailyStock")]
    public class TBL_DailyStock
    {
        [XmlElement(ElementName = "DailyStock")]
        public List<DailyStock> DailyStock { get; set; }
    }

    [XmlRoot(ElementName = "AskPrice")]
    public class AskPrice
    {
        [XmlAttribute(AttributeName = "member_memdoMem")]
        public string Member_memdoMem { get; set; }
        [XmlAttribute(AttributeName = "member_memdoVol")]
        public string Member_memdoVol { get; set; }
        [XmlAttribute(AttributeName = "member_memsoMem")]
        public string Member_memsoMem { get; set; }
        [XmlAttribute(AttributeName = "member_mesuoVol")]
        public string Member_mesuoVol { get; set; }
    }

    [XmlRoot(ElementName = "TBL_AskPrice")]
    public class TBL_AskPrice
    {
        [XmlElement(ElementName = "AskPrice")]
        public List<AskPrice> AskPrice { get; set; }
    }

    [XmlRoot(ElementName = "TBL_StockInfo")]
    public class TBL_StockInfo
    {
        [XmlAttribute(AttributeName = "JongName")]
        public string JongName { get; set; }
        [XmlAttribute(AttributeName = "CurJuka")]
        public string CurJuka { get; set; }
        [XmlAttribute(AttributeName = "DungRak")]
        public string DungRak { get; set; }
        [XmlAttribute(AttributeName = "Debi")]
        public string Debi { get; set; }
        [XmlAttribute(AttributeName = "PrevJuka")]
        public string PrevJuka { get; set; }
        [XmlAttribute(AttributeName = "Volume")]
        public string Volume { get; set; }
        [XmlAttribute(AttributeName = "Money")]
        public string Money { get; set; }
        [XmlAttribute(AttributeName = "StartJuka")]
        public string StartJuka { get; set; }
        [XmlAttribute(AttributeName = "HighJuka")]
        public string HighJuka { get; set; }
        [XmlAttribute(AttributeName = "LowJuka")]
        public string LowJuka { get; set; }
        [XmlAttribute(AttributeName = "High52")]
        public string High52 { get; set; }
        [XmlAttribute(AttributeName = "Low52")]
        public string Low52 { get; set; }
        [XmlAttribute(AttributeName = "UpJuka")]
        public string UpJuka { get; set; }
        [XmlAttribute(AttributeName = "DownJuka")]
        public string DownJuka { get; set; }
        [XmlAttribute(AttributeName = "Per")]
        public string Per { get; set; }
        [XmlAttribute(AttributeName = "Amount")]
        public string Amount { get; set; }
        [XmlAttribute(AttributeName = "FaceJuka")]
        public string FaceJuka { get; set; }
    }

    [XmlRoot(ElementName = "TBL_Hoga")]
    public class TBL_Hoga
    {
        [XmlAttribute(AttributeName = "mesuJan0")]
        public string MesuJan0 { get; set; }
        [XmlAttribute(AttributeName = "mesuHoka0")]
        public string MesuHoka0 { get; set; }
        [XmlAttribute(AttributeName = "mesuJan1")]
        public string MesuJan1 { get; set; }
        [XmlAttribute(AttributeName = "mesuHoka1")]
        public string MesuHoka1 { get; set; }
        [XmlAttribute(AttributeName = "mesuJan2")]
        public string MesuJan2 { get; set; }
        [XmlAttribute(AttributeName = "mesuHoka2")]
        public string MesuHoka2 { get; set; }
        [XmlAttribute(AttributeName = "mesuJan3")]
        public string MesuJan3 { get; set; }
        [XmlAttribute(AttributeName = "mesuHoka3")]
        public string MesuHoka3 { get; set; }
        [XmlAttribute(AttributeName = "mesuJan4")]
        public string MesuJan4 { get; set; }
        [XmlAttribute(AttributeName = "mesuHoka4")]
        public string MesuHoka4 { get; set; }
        [XmlAttribute(AttributeName = "medoJan0")]
        public string MedoJan0 { get; set; }
        [XmlAttribute(AttributeName = "medoHoka0")]
        public string MedoHoka0 { get; set; }
        [XmlAttribute(AttributeName = "medoJan1")]
        public string MedoJan1 { get; set; }
        [XmlAttribute(AttributeName = "medoHoka1")]
        public string MedoHoka1 { get; set; }
        [XmlAttribute(AttributeName = "medoJan2")]
        public string MedoJan2 { get; set; }
        [XmlAttribute(AttributeName = "medoHoka2")]
        public string MedoHoka2 { get; set; }
        [XmlAttribute(AttributeName = "medoJan3")]
        public string MedoJan3 { get; set; }
        [XmlAttribute(AttributeName = "medoHoka3")]
        public string MedoHoka3 { get; set; }
        [XmlAttribute(AttributeName = "medoJan4")]
        public string MedoJan4 { get; set; }
        [XmlAttribute(AttributeName = "medoHoka4")]
        public string MedoHoka4 { get; set; }
    }

    [XmlRoot(ElementName = "TBL_TimeConclude")]
    public class TBL_TimeConclude
    {
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlAttribute(AttributeName = "negoprice")]
        public string Negoprice { get; set; }
        [XmlAttribute(AttributeName = "Dungrak")]
        public string Dungrak { get; set; }
        [XmlAttribute(AttributeName = "Debi")]
        public string Debi { get; set; }
        [XmlAttribute(AttributeName = "sellprice")]
        public string Sellprice { get; set; }
        [XmlAttribute(AttributeName = "buyprice")]
        public string Buyprice { get; set; }
        [XmlAttribute(AttributeName = "amount")]
        public string Amount { get; set; }

        public string Color
        {
            get
            {
                int nego = Convert.ToInt32(Negoprice.Replace(",", ""));
                //int sell = Convert.ToInt32(Sellprice.Replace(",", ""));
                int buy = Convert.ToInt32(Buyprice.Replace(",", ""));
                if (nego <= buy)
                {
                    return "Blue";
                }
                else
                {
                    return "Red";
                }
            }
        }
    }

    [XmlRoot(ElementName = "stockInfo")]
    public class StockInfo
    {
        [XmlAttribute(AttributeName = "kosdaqJisu")]
        public string KosdaqJisu { get; set; }
        [XmlAttribute(AttributeName = "kosdaqJisuBuho")]
        public string KosdaqJisuBuho { get; set; }
        [XmlAttribute(AttributeName = "kosdaqJisuDebi")]
        public string KosdaqJisuDebi { get; set; }
        [XmlAttribute(AttributeName = "starJisu")]
        public string StarJisu { get; set; }
        [XmlAttribute(AttributeName = "starJisuBuho")]
        public string StarJisuBuho { get; set; }
        [XmlAttribute(AttributeName = "starJisuDebi")]
        public string StarJisuDebi { get; set; }
        [XmlAttribute(AttributeName = "jisu50")]
        public string Jisu50 { get; set; }
        [XmlAttribute(AttributeName = "jisu50Buho")]
        public string Jisu50Buho { get; set; }
        [XmlAttribute(AttributeName = "jisu50Debi")]
        public string Jisu50Debi { get; set; }
        [XmlAttribute(AttributeName = "myNowTime")]
        public string MyNowTime { get; set; }
        [XmlAttribute(AttributeName = "myJangGubun")]
        public string MyJangGubun { get; set; }
        [XmlAttribute(AttributeName = "myPublicPrice")]
        public string MyPublicPrice { get; set; }
        [XmlAttribute(AttributeName = "krx100Jisu")]
        public string Krx100Jisu { get; set; }
        [XmlAttribute(AttributeName = "krx100buho")]
        public string Krx100buho { get; set; }
        [XmlAttribute(AttributeName = "krx100Debi")]
        public string Krx100Debi { get; set; }
        [XmlAttribute(AttributeName = "kospiJisu")]
        public string KospiJisu { get; set; }
        [XmlAttribute(AttributeName = "kospiBuho")]
        public string KospiBuho { get; set; }
        [XmlAttribute(AttributeName = "kospiDebi")]
        public string KospiDebi { get; set; }
        [XmlAttribute(AttributeName = "kospi200Jisu")]
        public string Kospi200Jisu { get; set; }
        [XmlAttribute(AttributeName = "kospi200Buho")]
        public string Kospi200Buho { get; set; }
        [XmlAttribute(AttributeName = "kospi200Debi")]
        public string Kospi200Debi { get; set; }
    }

    [XmlRoot(ElementName = "stockprice")]
    public class Stockprice : BindableBase
    {
        [XmlElement(ElementName = "TBL_DailyStock")]
        public TBL_DailyStock TBL_DailyStock { get; set; }
        [XmlElement(ElementName = "TBL_AskPrice")]
        public TBL_AskPrice TBL_AskPrice { get; set; }
        [XmlElement(ElementName = "TBL_StockInfo")]
        public TBL_StockInfo TBL_StockInfo { get; set; }

        private TBL_Hoga _tbl_hoga;
        [XmlElement(ElementName = "TBL_Hoga")]
        public TBL_Hoga TBL_Hoga
        {
            get { return _tbl_hoga; }
            set { SetProperty(ref _tbl_hoga, value); }
        }
        [XmlArrayItem(ElementName = "TBL_TimeConclude")]
        public List<TBL_TimeConclude> TBL_TimeConclude { get; set; }
        [XmlElement(ElementName = "stockInfo")]
        public StockInfo StockInfo { get; set; }
        [XmlAttribute(AttributeName = "querytime")]
        public string Querytime { get; set; }
    }
}
