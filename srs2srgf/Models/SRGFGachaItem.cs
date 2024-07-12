using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srs2srgf.Models
{
    /// <summary>
    /// SRGFv1.0 每条抽卡记录的标准格式
    /// </summary>
    public class SRGFGachaItem
    {
        //"gacha_id": "2003",
        //"gacha_type": "x",
        //"item_id": "10000065",
        //"count": "1",
        //"time": "2023-05-07 10:47:00",
        //"name": "xxx",
        //"item_type": "xxxx",
        //"rank_type": "4",
        //"id": "1683425160001357994"
        [JsonPropertyName("gacha_id")]
        public string? GachaId {  get; set; }
        [JsonPropertyName("gacha_type")]
        public string? GachaType { get; set; }
        [JsonPropertyName("item_id")]
        public string? ItemId {  get; set; }
        [JsonPropertyName("count")]
        public string Count { get; set; } = "1";
        [JsonPropertyName("time")]
        public string? Time { get; set; }
        [JsonPropertyName("name")]
        public string? Name {  get; set; }
        [JsonPropertyName("item_type")]
        public string? ItemType { get; set; }
        [JsonPropertyName("rank_type")]
        public string? RankType { get; set; }
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        public SRGFGachaItem(string gachaId, string gachaType, string itemId, string count, string time, string? name, string? itemType, string? rankType, string id)
        {
            GachaId = gachaId;
            GachaType = gachaType;
            ItemId = itemId;
            Count = count;
            Time = time;
            Name = name;
            ItemType = itemType;
            RankType = rankType;
            Id = id;
        }

        public SRGFGachaItem(string gachaId, string gachaType, string itemId, string time, string? name, string? itemType, string? rankType, string id)
        {
            GachaId = gachaId;
            GachaType = gachaType;
            ItemId = itemId;
            Time = time;
            Name = name;
            ItemType = itemType;
            RankType = rankType;
            Id = id;
        }

        public SRGFGachaItem()
        {
        }
    }
}
