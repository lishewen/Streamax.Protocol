﻿using JT808.Protocol.Extensions.Streamax.Enums;
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
    /// 到离站信息上报
    /// </summary>
    public class JT808_0x0B02 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0B02>, IJT808Analyze
    {
        public override ushort MsgId => 0x0B02;

        public override string Description => "到离站信息上报";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 到离站类型
        /// </summary>
        public byte PointType { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public byte TrafficType { get; set; }
        /// <summary>
        /// 场站站点编号
        /// </summary>
        public uint StationId { get; set; }
        /// <summary>
        /// 车站序号
        /// </summary>
        public byte StationNo { get; set; }
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
        /// 当前乘客数
        /// </summary>
        public ushort PersonCount { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0B02 value = new JT808_0x0B02();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            value.PointType = reader.ReadByte();
            writer.WriteNumber($"[{value.PointType.ReadNumber()}]到离站类型-{Enum.GetName(typeof(PointType), value.PointType)}", value.PointType);
            value.TrafficType = reader.ReadByte();
            writer.WriteNumber($"[{value.TrafficType.ReadNumber()}]业务类型-{Enum.GetName(typeof(TrafficType), value.TrafficType)}", value.TrafficType);
            value.StationId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.StationId.ReadNumber()}]场站站点编号", value.StationId);
            value.StationNo = reader.ReadByte();
            writer.WriteNumber($"[{value.StationNo.ReadNumber()}]车站序号", value.StationNo);
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
            value.Time = reader.ReadDateTime6();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            value.PersonCount = reader.ReadUInt16();
            writer.WriteNumber($"[{value.PersonCount.ReadNumber()}]当前乘客数", value.PersonCount);
        }

        public JT808_0x0B02 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0B02 value = new JT808_0x0B02();
            value.GprsId = reader.ReadUInt32();
            value.PointType = reader.ReadByte();
            value.TrafficType = reader.ReadByte();
            value.StationId = reader.ReadUInt32();
            value.StationNo = reader.ReadByte();
            value.Tag = reader.ReadByte();
            value.Latitude = reader.ReadUInt32();
            value.Longitude = reader.ReadUInt32();
            value.Altitude = reader.ReadUInt16();
            value.Speed = reader.ReadUInt16();
            value.Direction = reader.ReadUInt16();
            value.Time = reader.ReadDateTime6();
            value.PersonCount = reader.ReadUInt16();
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B02 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteByte(value.PointType);
            writer.WriteByte(value.TrafficType);
            writer.WriteUInt32(value.StationId);
            writer.WriteByte(value.StationNo);
            writer.WriteByte(value.Tag);
            writer.WriteUInt32(value.Latitude);
            writer.WriteUInt32(value.Longitude);
            writer.WriteUInt16(value.Altitude);
            writer.WriteUInt16(value.Speed);
            writer.WriteUInt16(value.Direction);
            writer.WriteDateTime6(value.Time);
            writer.WriteUInt16(value.PersonCount);
        }
    }
}
