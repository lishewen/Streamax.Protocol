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
    /// 校时请求
    /// </summary>
    public class JT808_0x0B06 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0B06>, IJT808Analyze
    {
        public override ushort MsgId => 0x0B06;

        public override string Description => "校时请求";
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B06 value = new JT808_0x0B06();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public JT808_0x0B06 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B06 value = new JT808_0x0B06();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B06 value, IJT808Config config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
        }
    }
}
