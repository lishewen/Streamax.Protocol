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
    /// 考勤应答
    /// </summary>
    public class JT808_0x8B05 : JT808MessagePackFormatter<JT808_0x8B05>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x8B05;

        public string Description => "考勤应答";
        /// <summary>
        /// 业务请求结果
        /// 1:同意，0:不同意
        /// </summary>
        public byte Response { get; set; }
        /// <summary>
        /// 应答时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 附加内容
        /// 可为司机姓名或IC卡号
        /// </summary>
        public string Additional { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8B05 value = new();
            value.Response = reader.ReadByte();
            writer.WriteNumber($"[{value.Response.ReadNumber()}]业务请求结果", value.Response);
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]应答时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            var virtualHex = reader.ReadVirtualArray(reader.ReadCurrentRemainContentLength());
            value.Additional = reader.ReadRemainStringContent();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]附加内容", value.Additional);
        }

        public override JT808_0x8B05 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8B05 value = new();
            value.Response = reader.ReadByte();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            value.Additional = reader.ReadRemainStringContent();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8B05 value, IJT808Config config)
        {
            writer.WriteByte(value.Response);
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
            writer.WriteString(value.Additional);
        }
    }
}
