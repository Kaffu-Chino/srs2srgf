using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srs2srgf.Models
{
    /// <summary>
    /// SRGFv1.0 标准格式
    /// </summary>
    public class SRGF
    {

        [JsonPropertyName("info")]
        public SRGFInfo? Info { get; set; }

        [JsonPropertyName("list")]
        public List<SRGFGachaItem>? List { get; set; }

        public SRGF(SRGFInfo info, List<SRGFGachaItem> list)
        {
            Info = info;
            List = list;
        }

        public SRGF()
        {
        }
    }
}
