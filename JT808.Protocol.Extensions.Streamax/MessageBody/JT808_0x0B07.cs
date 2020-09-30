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
    /// 行车计划请求
    /// </summary>
    public class JT808_0x0B07 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0B07>, IJT808Analyze
    {
        public override ushort MsgId => 0x0B07;

        public override string Description => "行车计划请求";
        /// <summary>
        /// 营运日期
        /// BCD[3]
        /// 计划的执行日期，YY-MM-DD
        /// </summary>
        public DateTime WorkDate { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string WorkerId { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B07 value = new JT808_0x0B07();
            value.WorkDate = reader.ReadDateTime3();
            writer.WriteString($"[{value.WorkDate:yyMMdd}]营运日期", value.WorkDate.ToString("yy-MM-dd"));
            var length = reader.ReadCurrentRemainContentLength();
            var virtualHex = reader.ReadVirtualArray(length);
            value.WorkerId = reader.ReadString(length);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]员工编号", value.WorkerId);
        }

        public JT808_0x0B07 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B07 value = new JT808_0x0B07();
            value.WorkDate = reader.ReadDateTime3();
            var length = reader.ReadCurrentRemainContentLength();
            value.WorkerId = reader.ReadString(length);
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B07 value, IJT808Config config)
        {
            writer.WriteDateTime3(value.WorkDate);
            writer.WriteString(value.WorkerId);
        }
    }
}
