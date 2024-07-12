using srs2srgf.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace srs2srgf.Tools
{
    public static class SRGFExport
    {
        /// <summary>
        /// 生成SRGF导出信息
        /// </summary>
        /// <param name="uId">抽卡记录的账号UID（StarRailStation不提供）</param>
        /// <returns></returns>
        public static SRGFInfo SetSRGFInfo(string uId)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            long exportTimeStamp = ((DateTimeOffset)now).ToUnixTimeSeconds();
            string exportTime = Converter.ConvertUnixMillisecondsToLocal(exportTimeStamp*1000);
            string lang = CultureInfo.CurrentCulture.Name;
            int regionTimeZone = (int)TimeZoneInfo.Local.BaseUtcOffset.TotalHours;
            string exportApp = (string)Application.Current.Resources["appName"];
            string appVersion = "v" + Application.Current.Resources["appVersion"];
            SRGFInfo sRGFInfo = new SRGFInfo(uId, lang, regionTimeZone, exportTimeStamp, exportApp, appVersion);
            return sRGFInfo;
        }

        /// <summary>
        /// 合并SRGF片段并导出SRGF
        /// </summary>
        /// <param name="sRGFGachaItems">每条SRGF抽卡记录的列表</param>
        /// <param name="sRGFInfo">SRGF相关信息</param>
        /// <param name="outputPath">导出文件夹路径</param>
        /// <returns></returns>
        public static bool ExportSRGFToPath(SRGFInfo sRGFInfo, List<SRGFGachaItem> sRGFGachaItems, string outputPath) {
            SRGF sRGF = new SRGF(sRGFInfo, sRGFGachaItems);
            JsonSerializerOptions jsonIgnoreNullOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            string sRGFJson = JsonSerializer.Serialize(sRGF, jsonIgnoreNullOptions);
            string fileName = "SRGF_srs2srgf_" + sRGFInfo.UId + "_" + DateTime.Now.ToString("yyyyMMddHHmm", CultureInfo.InvariantCulture)+".json";
            File.WriteAllText(outputPath+"\\"+fileName, sRGFJson);
            return true;
        }
    }
}
