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
    /// 运营登记
    /// </summary>
    public class JT808_0x0B01 : JT808MessagePackFormatter<JT808_0x0B01>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x0B01;

        public string Description => "运营登记";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string WorkerId { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B01 value = new();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            var length = reader.ReadCurrentRemainContentLength();
            var virtualHex = reader.ReadVirtualArray(length);
            value.WorkerId = reader.ReadString(length);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]员工编号", value.WorkerId);
        }

        public override JT808_0x0B01 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B01 value = new();
            value.GprsId = reader.ReadUInt32();
            var length = reader.ReadCurrentRemainContentLength();
            value.WorkerId = reader.ReadString(length);
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B01 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteString(value.WorkerId);
        }
    }
}
