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
    /// 业务请求
    /// </summary>
    public class JT808_0x0B09 : JT808MessagePackFormatter<JT808_0x0B09>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x0B09;

        public string Description => "业务请求";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string WorkerId { get; set; }
        /// <summary>
        /// 业务请求代码
        /// </summary>
        public byte RequestCode { get; set; }
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B09 value = new();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            var length = reader.ReadCurrentRemainContentLength() - 7;
            var virtualHex = reader.ReadVirtualArray(length);
            value.WorkerId = reader.ReadString(length);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]员工编号", value.WorkerId);
            value.RequestCode = reader.ReadByte();
            writer.WriteNumber($"[{value.RequestCode.ReadNumber()}]业务请求代码-{Enum.GetName(typeof(RequestCode), value.RequestCode)}", value.RequestCode);
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override JT808_0x0B09 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B09 value = new();
            value.GprsId = reader.ReadUInt32();
            var length = reader.ReadCurrentRemainContentLength() - 7;
            value.WorkerId = reader.ReadString(length);
            value.RequestCode = reader.ReadByte();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B09 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteString(value.WorkerId);
            writer.WriteByte(value.RequestCode);
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
        }
    }
}
