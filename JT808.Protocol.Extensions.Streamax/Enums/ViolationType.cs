using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.Streamax.Enums
{
    public enum ViolationType
    {
        超速行车 = 0x01,
        低速行车 = 0x02,
        滞站 = 0x03,
        甩站 = 0x04,
        车内温度过高 = 0x05,
        车内温度过低 = 0x06,
        急刹车 = 0x07,
        急加速 = 0x08,
        疲劳驾驶 = 0x09,
        超载 = 0x0A,
        越界行驶 = 0x0B,
        报告当前行驶状况 = 0x0C,
        超速 = 0x0D
    }
}
