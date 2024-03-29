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
    /// 业务变更指令
    /// </summary>
    public class JT808_0x8B02 : JT808MessagePackFormatter<JT808_0x8B02>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x8B02;

        public string Description => "业务变更指令";
        /// <summary>
        /// 线路编号
        /// </summary>
        public uint GprsId { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public byte TrafficType { get; set; }
        /// <summary>
        /// 附加内容
        /// 最长1024，对违规信息的文本描述
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public bool SkipSerialization => false;

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8B02 value = new();
            value.GprsId = reader.ReadUInt32();
            writer.WriteNumber($"[{value.GprsId.ReadNumber()}]线路编号", value.GprsId);
            value.TrafficType = reader.ReadByte();
            writer.WriteNumber($"[{value.TrafficType.ReadNumber()}]业务类型-{Enum.GetName(typeof(TrafficType), value.TrafficType)}", value.TrafficType);
            var virtualHex = reader.ReadVirtualArray(reader.ReadCurrentRemainContentLength());
            value.Additional = reader.ReadStringEndChar0();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]附加内容", value.Additional);
        }

        public override JT808_0x8B02 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8B02 value = new();
            value.GprsId = reader.ReadUInt32();
            value.TrafficType = reader.ReadByte();
            value.Additional = reader.ReadStringEndChar0();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8B02 value, IJT808Config config)
        {
            writer.WriteUInt32(value.GprsId);
            writer.WriteByte(value.TrafficType);
            writer.WriteStringEndChar0(value.Additional);
        }
    }
}
