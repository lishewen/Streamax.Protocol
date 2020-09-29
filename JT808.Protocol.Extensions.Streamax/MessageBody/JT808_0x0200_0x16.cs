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
    /// 线路编码
    /// </summary>
    public class JT808_0x0200_0x16 : JT808_0x0200_BodyBase, IJT808MessagePackFormatter<JT808_0x0200_0x16>, IJT808Analyze
    {
        public override byte AttachInfoId { get; set; } = 0x16;
        public override byte AttachInfoLength { get; set; } = 4;
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0x16 value = new JT808_0x0200_0x16();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
        }

        public JT808_0x0200_0x16 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x16 value = new JT808_0x0200_0x16();
            value.GprsId = reader.ReadUInt32();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x16 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
        }
    }
}
