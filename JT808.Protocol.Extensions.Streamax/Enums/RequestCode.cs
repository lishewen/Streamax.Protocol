using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.Streamax.Enums
{
    public enum RequestCode
    {
        请求排班 = 0x01,
        请求交班 = 0x02,
        请求加油 = 0x03,
        请求加气 = 0x04,
        请求充电 = 0x05,
        请求维修 = 0x06,
        请求包车 = 0x07,
        请求终止任务 = 0x08
    }
}
