using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srs2srgf.Models
{
    /// <summary>
    /// StarRail Station每条抽卡记录的数据
    /// </summary>
    public class SRSGachaItem
    {
        //"uid": "1709557800001443491",
        //                "itemId": 20010,
        //                "timestamp": 1709559571000,
        //                "gachaType": 1,
        //                "gachaId": 1001,
        //                "rarity": 3,
        //                "manual": false,
        //                "pity4": 2,
        //                "pity5": 72,
        //                "pullNo": 147,
        //                "result": 0,
        //                "anchorItemId": "0",
        //                "sort": 999999853
        [JsonPropertyName("uid")]
        public string? UId { get; set; }
        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }
        [JsonPropertyName("timestamp")]
        public long TimesStamp { get; set; }
        [JsonPropertyName("gachaType")]
        public int GachaType {  get; set; }
        [JsonPropertyName("gachaId")]
        public int GachaId { get; set; }
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("manual")]
        public bool Manual { get; set; }
        [JsonPropertyName("pity4")]
        public int Pity4 { get; set; }
        [JsonPropertyName("pity5")]
        public int Pity5 { get; set; }
        [JsonPropertyName("pullNo")]
        public int PullNo { get; set; }
        [JsonPropertyName("result")]
        public int Result { get; set; }
        [JsonPropertyName("anchorItemId")]
        public string? AnchorItemId {  get; set; }
        [JsonPropertyName("sort")]
        public int Sort { get; set; }

        public SRSGachaItem(string uId, int itemId, int timesStamp, int gachaType, int gachaId, int rarity, bool manual, int pity4, int pity5, int pullNo, int result, string anchorItemId, int sort)
        {
            UId = uId;
            ItemId = itemId;
            TimesStamp = timesStamp;
            GachaType = gachaType;
            GachaId = gachaId;
            Rarity = rarity;
            Manual = manual;
            Pity4 = pity4;
            Pity5 = pity5;
            PullNo = pullNo;
            Result = result;
            AnchorItemId = anchorItemId;
            Sort = sort;
        }

        public SRSGachaItem()
        {
        }
    }
}
