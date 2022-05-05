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
    /// 限速值
    /// </summary>
    public class JT808_0x0200_0xE4 : JT808_0x0200_CustomBodyBase, IJT808MessagePackFormatter<JT808_0x0200_0xE4>, IJT808Analyze
    {
        public override byte AttachInfoId { get; set; } = 0xE4;
        public override byte AttachInfoLength { get; set; } = 2;
        /// <summary>
        /// 限速值
        /// </summary>
        public ushort SpeedLimit { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0xE4 value = new JT808_0x0200_0xE4();
            value.AttachInfoId = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoId.ReadNumber()}]附加信息Id", value.AttachInfoId);
            value.AttachInfoLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoLength.ReadNumber()}]附加信息长度", value.AttachInfoLength);
            value.SpeedLimit = reader.ReadUInt16();
            writer.WriteNumber($"[{value.SpeedLimit.ReadNumber()}]限速值", value.SpeedLimit);
        }

        public JT808_0x0200_0xE4 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0xE4 value = new JT808_0x0200_0xE4();
            value.AttachInfoId = reader.ReadByte();
            value.AttachInfoLength = reader.ReadByte();
            value.SpeedLimit = reader.ReadUInt16();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0xE4 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteUInt16(value.SpeedLimit);
        }
    }
}
