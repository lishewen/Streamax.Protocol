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
    /// 进出定点信息上报
    /// </summary>
    public class JT808_0x0B03 : JT808MessagePackFormatter<JT808_0x0B03>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x0B03;

        public string Description => "进出定点信息上报";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 进出类型
        /// 1:进；2:出
        /// </summary>
        public byte IOType { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public byte TrafficType { get; set; }
        /// <summary>
        /// 场站站点编号
        /// </summary>
        public uint StationId { get; set; }
        /// <summary>
        /// 标志字段
        /// 0位：0：自动触发；1：手动触发
        /// 1位：0：首次发送；1：补发
        /// 2位：0：未定位；1：定位
        /// 3-7位：保留
        /// </summary>
        public byte Tag { get; set; }
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
        /// 定点类型
        /// </summary>
        public byte FixedPointType { get; set; }
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public bool SkipSerialization => false;

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B03 value = new();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            value.IOType = reader.ReadByte();
            writer.WriteNumber($"[{value.IOType.ReadNumber()}]进出类型", value.IOType);
            value.TrafficType = reader.ReadByte();
            writer.WriteNumber($"[{value.TrafficType.ReadNumber()}]业务类型-{Enum.GetName(typeof(TrafficType), value.TrafficType)}", value.TrafficType);
            value.StationId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.StationId.ReadNumber()}]场站站点编号", value.StationId);
            value.Tag = reader.ReadByte();
            writer.WriteNumber($"[{value.Tag.ReadNumber()}]标志字段", value.Tag);
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
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            value.FixedPointType = reader.ReadByte();
            writer.WriteNumber($"[{value.FixedPointType.ReadNumber()}]定点类型-{Enum.GetName(typeof(FixedPointType), value.FixedPointType)}", value.FixedPointType);
        }

        public override JT808_0x0B03 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B03 value = new();
            value.GprsId = reader.ReadUInt32();
            value.IOType = reader.ReadByte();
            value.TrafficType = reader.ReadByte();
            value.StationId = reader.ReadUInt32();
            value.Tag = reader.ReadByte();
            value.Latitude = reader.ReadUInt32();
            value.Longitude = reader.ReadUInt32();
            value.Altitude = reader.ReadUInt16();
            value.Speed = reader.ReadUInt16();
            value.Direction = reader.ReadUInt16();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            value.FixedPointType = reader.ReadByte();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B03 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteByte(value.IOType);
            writer.WriteByte(value.TrafficType);
            writer.WriteUInt32(value.StationId);
            writer.WriteByte(value.Tag);
            writer.WriteUInt32(value.Latitude);
            writer.WriteUInt32(value.Longitude);
            writer.WriteUInt16(value.Altitude);
            writer.WriteUInt16(value.Speed);
            writer.WriteUInt16(value.Direction);
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
            writer.WriteByte(value.FixedPointType);
        }
    }
}
