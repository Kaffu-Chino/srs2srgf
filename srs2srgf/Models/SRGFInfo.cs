using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srs2srgf.Models
{
    /// <summary>
    /// SRGFv1.0 导出相关信息的标准格式
    /// </summary>
    public class SRGFInfo
    {
        //"uid": "xxxxxxxxx",
        //"lang": "zh-cn",
        //"region_time_zone": 8,
        //"export_timestamp": 1684124992,
        //"export_app": "xxx",
        //"export_app_version": "xxxxx",
        //"srgf_version": "v1.0"
        [JsonPropertyName("uid")]
        public string? UId { get; set; }
        [JsonPropertyName("lang")]
        public string? Lang { get; set; }
        [JsonPropertyName("region_time_zone")]
        public int RegionTimeZone { get; set; }
        [JsonPropertyName("export_timestamp")]
        public long ExportTimestamp { get; set; }
        [JsonPropertyName("export_app")]
        public string? ExportApp { get; set; }
        [JsonPropertyName("export_app_version")]
        public string? ExportAppVersion { get; set; }
        [JsonPropertyName("srgf_version")]
        public string SrgfVersion { get; set; } = "v1.0";

        public SRGFInfo(string uId, string lang, int regionTimeZone, long exportTimestamp, string? exportApp, string? exportAppVersion, string srgfVersion)
        {
            UId = uId;
            Lang = lang;
            RegionTimeZone = regionTimeZone;
            ExportTimestamp = exportTimestamp;
            ExportApp = exportApp;
            ExportAppVersion = exportAppVersion;
            SrgfVersion = srgfVersion;
        }

        public SRGFInfo(string uId, string lang, int regionTimeZone, long exportTimestamp, string? exportApp, string? exportAppVersion)
        {
            UId = uId;
            Lang = lang;
            RegionTimeZone = regionTimeZone;
            ExportTimestamp = exportTimestamp;
            ExportApp = exportApp;
            ExportAppVersion = exportAppVersion;
        }

        public SRGFInfo()
        {
        }
    }
}
