using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srs2srgf.Tools
{
    public static class Converter
    {
        /// <summary>
        /// 将毫秒级（13位）unix时间戳转化为本地时间（秒级请在末尾添3个0）
        /// </summary>
        /// <param name="unixTimeStampMilliseconds">毫秒级（13位）unix时间戳</param>
        /// <returns></returns>
        public static string ConvertUnixMillisecondsToLocal(long unixTimeStampMilliseconds)
        {
            DateTimeOffset utcDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStampMilliseconds);  
            DateTime utcDateTime = utcDateTimeOffset.UtcDateTime;
            //TimeSpan timeZoneOffset = TimeSpan.FromHours(8);
            TimeSpan timeZoneOffset = TimeZoneInfo.Local.BaseUtcOffset;
            DateTime dateTimeInTargetTimeZone = utcDateTime.Add(timeZoneOffset);
            string formattedDate = dateTimeInTargetTimeZone.ToString("yyyy-MM-dd HH:mm:ss");
            return formattedDate;
        }
    }
}
