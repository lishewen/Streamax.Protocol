using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.Streamax.Enums
{
    /// <summary>
    /// 业务类型
    /// </summary>
    public enum TrafficType
    {
        上行 = 0x01,
        下行 = 0x02,
        环行 = 0x03,
        停主站 = 0x04,
        停副站 = 0x05,
        出场 = 0x80,
        进场 = 0x81,
        加油 = 0x82,
        加气 = 0x83,
        充电 = 0x84,
        小修 = 0x85,
        大修 = 0x86,
        一保 = 0x87,
        二保 = 0x88,
        三保 = 0x89,
        放空 = 0x8A,
        停场 = 0x8B
    }
}
