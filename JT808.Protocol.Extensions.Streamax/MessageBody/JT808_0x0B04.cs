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
    /// 违规信息上报
    /// </summary>
    public class JT808_0x0B04 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0B04>, IJT808Analyze
    {
        public override ushort MsgId => 0x0B04;

        public override string Description => "违规信息上报";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 违规类型
        /// </summary>
        public byte ViolationType { get; set; }
        /// <summary>
        /// 违规值
        /// </summary>
        public ushort ViolationValue { get; set; }
        /// <summary>
        /// 违规标准
        /// </summary>
        public ushort ViolationStandard { get; set; }
        /// <summary>
        /// 纬度
        /// 以度位单位的纬度值乘以10^6，精确到百万分之一度
        /// </summary>
        public uint Latitude { get; set; }
        /// <summary>
        /// 经度
        /// 以度位单位的经度值乘以10^6，精确到百万分之一度
        /// </summary>
        public uint Longitude { get; set; }
        /// <summary>
        /// 高程
        /// </summary>
        public ushort Altitude { get; set; }
        /// <summary>
        /// 车速
        /// </summary>
        public ushort Speed { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public ushort Direction { get; set; }
        /// <summary>
        /// 时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 补发标识
        /// 1为补发，0为正常
        /// </summary>
        public byte Reissue { get; set; }
        /// <summary>
        /// 附加内容
        /// 最长1024，对违规信息的文本描述
        /// </summary>
        public string Additional { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B04 value = new JT808_0x0B04();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            value.ViolationType = reader.ReadByte();
            writer.WriteNumber($"[{value.ViolationType.ReadNumber()}]违规类型-{Enum.GetName(typeof(ViolationType), value.ViolationType)}", value.ViolationType);
            if ((value.ViolationType >= 0x01 && value.ViolationType <= 0x0A) || value.ViolationType == 0x0D)
            {
                value.ViolationValue = reader.ReadUInt16();
                writer.WriteNumber($"[{value.ViolationValue.ReadNumber()}]违规值", value.ViolationValue);
                value.ViolationStandard = reader.ReadUInt16();
                writer.WriteNumber($"[{value.ViolationStandard.ReadNumber()}]违规标准", value.ViolationStandard);
            }
            else if (value.ViolationType == 0x0C)
            {
                value.ViolationValue = reader.ReadUInt16();
                writer.WriteNumber($"[{value.ViolationValue.ReadNumber()}]违规值", value.ViolationValue);
            }
            value.Latitude = reader.ReadUInt32();
            writer.WriteNumber($"[{value.Latitude.ReadNumber()}]纬度", value.Latitude);
            value.Longitude = reader.ReadUInt32();
            writer.WriteNumber($"[{value.Longitude.ReadNumber()}]经度", value.Longitude);
            value.Altitude = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Altitude.ReadNumber()}]高程", value.Altitude);
            value.Speed = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Speed.ReadNumber()}]车速", value.Speed);
            value.Direction = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Direction.ReadNumber()}]方向", value.Direction);
            value.Time = reader.ReadDateTime6();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            value.Reissue = reader.ReadByte();
            writer.WriteNumber($"[{value.Reissue.ReadNumber()}]补发标识", value.Reissue);
            var virtualHex = reader.ReadVirtualArray(reader.ReadCurrentRemainContentLength());
            value.Additional = reader.ReadRemainStringContent();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]附加内容", value.Additional);
        }

        public JT808_0x0B04 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B04 value = new JT808_0x0B04();
            value.GprsId = reader.ReadUInt32();
            value.ViolationType = reader.ReadByte();
            if (value.ViolationType >= 0x01 && value.ViolationType <= 0x0A)
            {
                value.ViolationValue = reader.ReadUInt16();
                value.ViolationStandard = reader.ReadUInt16();
            }
            else if (value.ViolationType == 0x0C)
            {
                value.ViolationValue = reader.ReadUInt16();
            }
            value.Latitude = reader.ReadUInt32();
            value.Longitude = reader.ReadUInt32();
            value.Altitude = reader.ReadUInt16();
            value.Speed = reader.ReadUInt16();
            value.Direction = reader.ReadUInt16();
            value.Time = reader.ReadDateTime6();
            value.Reissue = reader.ReadByte();
            value.Additional = reader.ReadRemainStringContent();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B04 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteByte(value.ViolationType);
            writer.WriteUInt16(value.ViolationValue);
            writer.WriteUInt16(value.ViolationStandard);
            writer.WriteUInt32(value.Latitude);
            writer.WriteUInt32(value.Longitude);
            writer.WriteUInt16(value.Altitude);
            writer.WriteUInt16(value.Speed);
            writer.WriteUInt16(value.Direction);
            writer.WriteDateTime6(value.Time);
            writer.WriteByte(value.Reissue);
            writer.WriteString(value.Additional);
        }
    }
}
