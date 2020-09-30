using JT808.Protocol.Extensions.Streamax.Enums;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.Extensions.Streamax.MessageBody
{
    /// <summary>
    /// 设备故障上报
    /// </summary>
    public class JT808_0x0B0B : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0B0B>, IJT808Analyze
    {
        public override ushort MsgId => 0x0B0B;

        public override string Description => "设备故障上报";
        /// <summary>
        /// 设备类型
        /// </summary>
        public byte DeviceType { get; set; }
        /// <summary>
        /// 设备地址
        /// </summary>
        public byte DeviceAddress { get; set; }
        /// <summary>
        /// 设备版本
        /// </summary>
        public string DeviceVersion { get; set; }
        /// <summary>
        /// 故障编码
        /// </summary>
        public byte DeviceErrorCode { get; set; }
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B0B value = new JT808_0x0B0B();
            value.DeviceType = reader.ReadByte();
            writer.WriteNumber($"[{value.DeviceType.ReadNumber()}]设备类型-{Enum.GetName(typeof(DeviceType), value.DeviceType)}", value.DeviceType);
            value.DeviceAddress = reader.ReadByte();
            writer.WriteNumber($"[{value.DeviceAddress.ReadNumber()}]设备地址-{Enum.GetName(typeof(DeviceAddress), value.DeviceAddress)}", value.DeviceAddress);
            var length = reader.ReadCurrentRemainContentLength() - 7;
            var virtualHex = reader.ReadVirtualArray(length);
            value.DeviceVersion = reader.ReadString(length);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]设备版本", value.DeviceVersion);
            value.DeviceErrorCode = reader.ReadByte();
            writer.WriteNumber($"[{value.DeviceErrorCode.ReadNumber()}]故障代码-{Enum.GetName(typeof(DeviceErrorCode), value.DeviceErrorCode)}", value.DeviceErrorCode);
            value.Time = reader.ReadDateTime6();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public JT808_0x0B0B Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B0B value = new JT808_0x0B0B();
            value.DeviceType = reader.ReadByte();
            value.DeviceAddress = reader.ReadByte();
            var length = reader.ReadCurrentRemainContentLength() - 7;
            value.DeviceVersion = reader.ReadString(length);
            value.DeviceErrorCode = reader.ReadByte();
            value.Time = reader.ReadDateTime6();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B0B value, IJT808Config config)
        {
            writer.WriteByte(value.DeviceType);
            writer.WriteByte(value.DeviceAddress);
            writer.WriteString(value.DeviceVersion);
            writer.WriteByte(value.DeviceErrorCode);
            writer.WriteDateTime6(value.Time);
        }
    }
}
