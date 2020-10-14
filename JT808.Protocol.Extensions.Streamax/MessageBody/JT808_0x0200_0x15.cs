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
    /// 异常驾驶行为报警详细描述
    /// </summary>
    public class JT808_0x0200_0x15 : JT808_0x0200_BodyBase, IJT808MessagePackFormatter<JT808_0x0200_0x15>, IJT808Analyze
    {
        public override byte AttachInfoId { get; set; } = 0x15;
        public override byte AttachInfoLength { get; set; } = 2;
        /// <summary>
        /// 异常驾驶行为类型
        /// 按位设置：0表示不具备，1表示具备
        /// bit0：1，疲劳；
        /// bit1：1，打电话；
        ///bit2：1，抽烟
        /// </summary>
        public byte ExceptionType { get; set; }
        /// <summary>
        /// 疲劳程度
        /// 疲劳程度用0～100表示
        /// </summary>
        public byte Fatigue { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0x15 value = new JT808_0x0200_0x15();
            value.AttachInfoId = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoId.ReadNumber()}]附加信息Id", value.AttachInfoId);
            value.AttachInfoLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoLength.ReadNumber()}]附加信息长度", value.AttachInfoLength);
            value.ExceptionType = reader.ReadByte();
            writer.WriteStartArray($"[{value.ExceptionType.ReadNumber()}]异常驾驶行为类型");
            writer.WriteStringValue((value.ExceptionType & 01) > 0 ? "具备" : "不具备");
            writer.WriteStringValue((value.ExceptionType & 02) > 0 ? "疲劳" : "不疲劳");
            writer.WriteStringValue((value.ExceptionType & 04) > 0 ? "打电话" : "不打电话");
            writer.WriteStringValue((value.ExceptionType & 08) > 0 ? "抽烟" : "不抽烟");
            writer.WriteEndArray();
            value.Fatigue = reader.ReadByte();
            writer.WriteNumber($"[{value.Fatigue.ReadNumber()}]疲劳程度", value.Fatigue);
        }

        public JT808_0x0200_0x15 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x15 value = new JT808_0x0200_0x15();
            value.AttachInfoId = reader.ReadByte();
            value.AttachInfoLength = reader.ReadByte();
            value.ExceptionType = reader.ReadByte();
            value.Fatigue = reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x15 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteByte(value.ExceptionType);
            writer.WriteByte(value.Fatigue);
        }
    }
}
