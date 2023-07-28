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
    /// 校时应答
    /// </summary>
    public class JT808_0x8B06 : JT808MessagePackFormatter<JT808_0x8B06>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x8B06;

        public string Description => "校时应答";
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public bool SkipSerialization => false;

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8B06 value = new();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override JT808_0x8B06 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8B06 value = new();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8B06 value, IJT808Config config)
        {
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
        }
    }
}
