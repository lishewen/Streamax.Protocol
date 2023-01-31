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
    /// 业务请求应答
    /// </summary>
    public class JT808_0x8B09 : JT808MessagePackFormatter<JT808_0x8B09>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x8B09;

        public string Description => "业务请求应答";
        /// <summary>
        /// 流水号
        /// </summary>
        public ushort Serial { get; set; }
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
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 路牌
        /// </summary>
        public string GuideBoard { get; set; }
        /// <summary>
        /// 车次编号
        /// </summary>
        public string TrainNumber { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string SelfId { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public byte TrafficType { get; set; }
        /// <summary>
        /// 调度类型
        /// </summary>
        public byte DispatchType { get; set; }
        /// <summary>
        /// 驾驶员编号
        /// </summary>
        public string DriverId { get; set; }
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// 乘务员1编号
        /// </summary>
        public string AttendantId1 { get; set; }
        /// <summary>
        /// 乘务员2编号
        /// </summary>
        public string AttendantId2 { get; set; }
        /// <summary>
        /// 起始时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 终止时间
        /// YYMMDDhhmmss
        /// BCD[6]
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 起始站点编号
        /// </summary>
        public uint StartStationId { get; set; }
        /// <summary>
        /// 起始场站车站名称
        /// </summary>
        public string StartStationName { get; set; }
        /// <summary>
        /// 终止站点编号
        /// </summary>
        public uint EndStationId { get; set; }
        /// <summary>
        /// 终止场站车站名称
        /// </summary>
        public string EndStationName { get; set; }
        /// <summary>
        /// 附加内容
        /// </summary>
        public string Additional { get; set; }
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8B09 value = new();
            value.Serial = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Serial.ReadNumber()}]流水号", value.Serial);
            value.Response = reader.ReadByte();
            writer.WriteNumber($"[{value.Response.ReadNumber()}]业务请求结果", value.Response);
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.Time:yyMMddHHmmss}]应答时间", value.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            value.GuideBoard = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.GuideBoard.Length}]路牌", value.GuideBoard);
            value.TrainNumber = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.TrainNumber.Length}]车次编号", value.TrainNumber);
            value.SelfId = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.SelfId.Length}]车辆编号", value.SelfId);
            value.TrafficType = reader.ReadByte();
            writer.WriteNumber($"[{value.TrafficType.ReadNumber()}]业务类型-{Enum.GetName(typeof(TrafficType), value.TrafficType)}", value.TrafficType);
            value.DispatchType = reader.ReadByte();
            writer.WriteNumber($"[{value.DispatchType.ReadNumber()}]调度类型-{Enum.GetName(typeof(DispatchType), value.DispatchType)}", value.DispatchType);
            value.DriverId = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.DriverId.Length}]驾驶员编号", value.DriverId);
            value.DriverName = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.DriverName.Length}]驾驶员姓名", value.DriverName);
            value.AttendantId1 = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.AttendantId1.Length}]乘务员1编号", value.AttendantId1);
            value.AttendantId2 = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.AttendantId2.Length}]乘务员2编号", value.AttendantId2);
            value.StartTime = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.StartTime:yyMMddHHmmss}]起始时间", value.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            value.EndTime = reader.ReadDateTime_yyMMddHHmmss();
            writer.WriteString($"[{value.EndTime:yyMMddHHmmss}]终止时间", value.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            value.StartStationId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.StartStationId.ReadNumber()}]起始站点编号", value.StartStationId);
            value.StartStationName = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.StartStationName.Length}]起始场站车站名称", value.StartStationName);
            value.EndStationId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.EndStationId.ReadNumber()}]终止站点编号", value.EndStationId);
            value.EndStationName = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.EndStationName.Length}]终止场站车站名称", value.EndStationName);
            value.Additional = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.Additional.Length}]附加内容", value.Additional);
        }

        public override JT808_0x8B09 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8B09 value = new();
            value.Serial = reader.ReadUInt16();
            value.Response = reader.ReadByte();
            value.Time = reader.ReadDateTime_yyMMddHHmmss();
            value.GprsId = reader.ReadUInt32();
            value.GuideBoard = reader.ReadStringEndChar0();
            value.TrainNumber = reader.ReadStringEndChar0();
            value.SelfId = reader.ReadStringEndChar0();
            value.TrafficType = reader.ReadByte();
            value.DispatchType = reader.ReadByte();
            value.DriverId = reader.ReadStringEndChar0();
            value.DriverName = reader.ReadStringEndChar0();
            value.AttendantId1 = reader.ReadStringEndChar0();
            value.AttendantId2 = reader.ReadStringEndChar0();
            value.StartTime = reader.ReadDateTime_yyMMddHHmmss();
            value.EndTime = reader.ReadDateTime_yyMMddHHmmss();
            value.StartStationId = reader.ReadUInt32();
            value.StartStationName = reader.ReadStringEndChar0();
            value.EndStationId = reader.ReadUInt32();
            value.EndStationName = reader.ReadStringEndChar0();
            value.Additional = reader.ReadStringEndChar0();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8B09 value, IJT808Config config)
        {
            writer.WriteUInt16(value.Serial);
            writer.WriteByte(value.Response);
            writer.WriteDateTime_yyMMddHHmmss(value.Time);
            writer.WriteUInt32(value.GprsId);
            writer.WriteStringEndChar0(value.GuideBoard);
            writer.WriteStringEndChar0(value.TrainNumber);
            writer.WriteStringEndChar0(value.SelfId);
            writer.WriteByte(value.TrafficType);
            writer.WriteByte(value.DispatchType);
            writer.WriteStringEndChar0(value.DriverId);
            writer.WriteStringEndChar0(value.DriverName);
            writer.WriteStringEndChar0(value.AttendantId1);
            writer.WriteStringEndChar0(value.AttendantId2);
            writer.WriteDateTime_yyMMddHHmmss(value.StartTime);
            writer.WriteDateTime_yyMMddHHmmss(value.EndTime);
            writer.WriteUInt32(value.StartStationId);
            writer.WriteStringEndChar0(value.StartStationName);
            writer.WriteUInt32(value.EndStationId);
            writer.WriteStringEndChar0(value.EndStationName);
            writer.WriteStringEndChar0(value.Additional);
        }
    }
}
