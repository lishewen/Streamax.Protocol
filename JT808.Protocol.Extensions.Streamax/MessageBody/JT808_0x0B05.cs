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
    /// 考勤
    /// </summary>
    public class JT808_0x0B05 : JT808MessagePackFormatter<JT808_0x0B05>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x0B05;

        public string Description => "考勤";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string WorkerId { get; set; }
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 考勤类型
        /// </summary>
        public byte AttendType { get; set; }
        /// <summary>
        /// 考勤方式
        /// </summary>
        public byte AttendanceType { get; set; }
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public bool SkipSerialization => false;

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B05 value = new();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            var length = reader.ReadCurrentRemainContentLength() - 8;
            var virtualHex = reader.ReadVirtualArray(length);
            value.WorkerId = reader.ReadString(length);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]员工编号", value.WorkerId);
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            value.AttendType = reader.ReadByte();
            writer.WriteNumber($"[{value.AttendType.ReadNumber()}]考勤类型-{Enum.GetName(typeof(AttendType), value.AttendType)}", value.AttendType);
            value.AttendanceType = reader.ReadByte();
            writer.WriteNumber($"[{value.AttendanceType.ReadNumber()}]考勤方式-{Enum.GetName(typeof(AttendanceType), value.AttendanceType)}", value.AttendanceType);
        }

        public override JT808_0x0B05 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B05 value = new();
            value.GprsId = reader.ReadUInt32();
            var length = reader.ReadCurrentRemainContentLength() - 8;
            value.WorkerId = reader.ReadString(length);
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            value.AttendType = reader.ReadByte();
            value.AttendanceType = reader.ReadByte();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B05 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteString(value.WorkerId);
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
            writer.WriteByte(value.AttendType);
            writer.WriteByte(value.AttendanceType);
        }
    }
}
