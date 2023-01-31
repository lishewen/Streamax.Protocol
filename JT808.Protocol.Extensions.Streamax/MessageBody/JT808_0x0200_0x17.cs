using JT808.Protocol.Extensions.Streamax.Enums;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessageBody;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.Extensions.Streamax.MessageBody
{
    /// <summary>
    /// 业务类型
    /// </summary>
    public class JT808_0x0200_0x17 : JT808MessagePackFormatter<JT808_0x0200_0x17>, JT808_0x0200_CustomBodyBase, IJT808Analyze
    {
        public byte AttachInfoId { get; set; } = 0x17;
        public byte AttachInfoLength { get; set; } = 1;
        /// <summary>
        /// 业务类型
        /// </summary>
        public byte TrafficType { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0x17 value = new();
            value.AttachInfoId = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoId.ReadNumber()}]附加信息Id", value.AttachInfoId);
            value.AttachInfoLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoLength.ReadNumber()}]附加信息长度", value.AttachInfoLength);
            value.TrafficType = reader.ReadByte();
            writer.WriteNumber($"[{value.TrafficType.ReadNumber()}]业务类型-{Enum.GetName(typeof(TrafficType), value.TrafficType)}", value.TrafficType);
        }

        public override JT808_0x0200_0x17 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x17 value = new();
            value.AttachInfoId = reader.ReadByte();
            value.AttachInfoLength = reader.ReadByte();
            value.TrafficType = reader.ReadByte();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x17 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteByte(value.TrafficType);
        }
    }
}
