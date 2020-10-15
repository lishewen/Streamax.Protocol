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
    /// 视频相关报警
    /// </summary>
    public class JT808_0x0200_0x14 : JT808_0x0200_BodyBase, IJT808MessagePackFormatter<JT808_0x0200_0x14>, IJT808Analyze
    {
        public override byte AttachInfoId { get; set; } = 0x14;
        public override byte AttachInfoLength { get; set; } = 4;
        /// <summary>
        /// 视频报警标志位
        /// </summary>
        public uint AlarmTag { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0x14 value = new JT808_0x0200_0x14();
            value.AttachInfoId = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoId.ReadNumber()}]附加信息Id", value.AttachInfoId);
            value.AttachInfoLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoLength.ReadNumber()}]附加信息长度", value.AttachInfoLength);
            value.AlarmTag = reader.ReadUInt32();
            writer.WriteStartArray($"[{value.AlarmTag.ReadNumber()}]视频报警标志位");
            writer.WriteStringValue((value.AlarmTag & 01) > 0 ? "视频信号丢失报警" : "视频信号丢失报警解除");
            writer.WriteStringValue((value.AlarmTag & 02) > 0 ? "主存储器故障报警" : "主存储器故障报警解除");
            writer.WriteStringValue((value.AlarmTag & 04) > 0 ? "灾备存储单元故障报警" : "灾备存储单元故障报警解除");
            writer.WriteStringValue((value.AlarmTag & 08) > 0 ? "其他视频设备故障报警" : "其他视频设备故障报警解除");
            writer.WriteStringValue((value.AlarmTag & 16) > 0 ? "客车超载报警" : "客车超载报警解除");
            writer.WriteStringValue((value.AlarmTag & 32) > 0 ? "异常驾驶行为报警" : "异常驾驶行为报警解除");
            writer.WriteStringValue((value.AlarmTag & 64) > 0 ? "特殊报警录像达到存储阈值报警" : "收到应答后清零，占用存储容量发生变化后再次报警");
            writer.WriteEndArray();
        }

        public JT808_0x0200_0x14 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x14 value = new JT808_0x0200_0x14();
            value.AttachInfoId = reader.ReadByte();
            value.AttachInfoLength = reader.ReadByte();
            value.AlarmTag = reader.ReadUInt32();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x14 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteUInt32(value.AlarmTag);
        }
    }
}
