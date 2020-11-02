using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AToolPlus
{
    public class ConfigInfo
    {
        /// <summary>
        /// 显示时间戳
        /// </summary>
        public bool RecvShowTime { get; set; } = false;
        /// <summary>
        /// 接收区回车
        /// </summary>
        public bool RecvAutoLine { get; set; } = false;
        /// <summary>
        /// Hex显示
        /// </summary>
        public bool RecvShowHex { get; set; } = false;
        /// <summary>
        /// 发送回车换行
        /// </summary>
        public bool SendAppendRN { get; set; } = true;
        /// <summary>
        /// 字符串发送
        /// </summary>
        public bool SendATString { get; set; } = true;
        /// <summary>
        /// HEX发送
        /// </summary>
        public bool SendHex { get; set; } = false;
        /// <summary>
        /// 循环发送
        /// </summary>
        public bool SendCycle { get; set; } = false;
        /// <summary>
        /// 日志文件
        /// </summary>
        public string LogFile { get; set; }
        /// <summary>
        /// AT指令文件
        /// </summary>
        public string AtCommandFile { get; set; }
    }
}
