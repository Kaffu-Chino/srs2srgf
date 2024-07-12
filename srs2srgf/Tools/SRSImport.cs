using srs2srgf.Models;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace srs2srgf.Tools
{
    public static class SRSImport
    {
        /// <summary>
        /// 从StarRailStation备份文件中提取原始格式的抽卡记录
        /// </summary>
        /// <param name="inputFilePath">StarRailStation备份文件路径</param>
        /// <returns></returns>
        public static List<SRSGachaItem> ImportSRSGachaItems(string inputFilePath)
        {
            List<SRSGachaItem> sRSGachaItems  = new List<SRSGachaItem>();
            try
            {
                JsonDocument sRSJsonDocument = JsonDocument.Parse(File.ReadAllText(inputFilePath, Encoding.UTF8));
                JsonElement gachaJsonElement = sRSJsonDocument.RootElement.GetProperty("data").GetProperty("stores").GetProperty("1_warp-v2");
                List<SRSGachaItem>? sRSGachaItems1 = JsonSerializer.Deserialize<List<SRSGachaItem>>(gachaJsonElement.GetProperty("items_1").GetRawText());
                List<SRSGachaItem>? sRSGachaItems2 = JsonSerializer.Deserialize<List<SRSGachaItem>>(gachaJsonElement.GetProperty("items_2").GetRawText());
                List<SRSGachaItem>? sRSGachaItems11 = JsonSerializer.Deserialize<List<SRSGachaItem>>(gachaJsonElement.GetProperty("items_11").GetRawText());
                List<SRSGachaItem>? sRSGachaItems12 = JsonSerializer.Deserialize<List<SRSGachaItem>>(gachaJsonElement.GetProperty("items_12").GetRawText());
                if(sRSGachaItems1 != null)
                {
                    sRSGachaItems.AddRange(sRSGachaItems1);
                }
                if(sRSGachaItems2 != null)
                {
                    sRSGachaItems.AddRange(sRSGachaItems2);
                }
                if(sRSGachaItems11 != null)
                {
                    sRSGachaItems.AddRange(sRSGachaItems11);
                }
                if(sRSGachaItems12 != null)
                {
                    sRSGachaItems.AddRange(sRSGachaItems12);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "失败",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            return sRSGachaItems;
        }

        /// <summary>
        /// 将StarRailStation的抽卡记录转化为SRGF抽卡记录的格式
        /// </summary>
        /// <param name="sRSGachaItems">StarRailStation的抽卡记录</param>
        /// <returns></returns>
        public static List<SRGFGachaItem> SRSGachaItemsToSRGFGachaItems(List<SRSGachaItem> sRSGachaItems)
        {
            List<SRGFGachaItem> sRGFGachaItems = new List<SRGFGachaItem>();
            for (int i = 0; i < sRSGachaItems.Count; i++) {
                string gachaId = sRSGachaItems[i].GachaId.ToString();
                string gachaType = sRSGachaItems[i].GachaType.ToString();
                string itemId = sRSGachaItems[i].ItemId.ToString();
                string time = Converter.ConvertUnixMillisecondsToLocal(sRSGachaItems[i].TimesStamp);
                string? name = null;
                string? itemType = null;
                string rankType = sRSGachaItems[i].Rarity.ToString();
                string? id = sRSGachaItems[i].UId;
                if (id != null)
                {
                    sRGFGachaItems.Add(new SRGFGachaItem(gachaId, gachaType, itemId, time, name, itemType, rankType, id));
                }
                else
                {
                    throw new ArgumentNullException(nameof(SRSGachaItem.UId));
                }
            }
            return sRGFGachaItems;
        }
    }
}
