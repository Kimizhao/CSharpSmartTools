using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AToolPlus
{
    public class CommandItem
    {
        /// <summary>
        /// 字符为Hex
        /// </summary>
        public bool Hex { get; set; } = false;
        /// <summary>
        /// 顺序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 命令名称
        /// </summary>
        public String CommandName { get; set; }
        /// <summary>
        /// 命令类型
        /// </summary>
        public String Type { get; set; } = "SET";
        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 延时毫秒
        /// </summary>
        public int DelayMicroSeconds { get; set; } = 1000;
        /// <summary>
        /// 出错时处理方式
        /// </summary>
        public String OnError { get; set; } = "RETURN";

    }
}
