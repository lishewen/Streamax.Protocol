using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.Streamax.Enums
{
    /// <summary>
    /// 升级结果代码
    /// </summary>
    public enum UpdateResultCode
    {
        成功 = 0x01,
        连接服务器失败 = 0x02,
        验证失败 = 0x03,
        下载文件失败 = 0x04,
        文件校验错误 = 0x05,
        无需升级 = 0x06
    }
}
