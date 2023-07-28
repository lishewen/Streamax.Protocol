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
    /// 升级通知
    /// </summary>
    public class JT808_0x8B0A : JT808MessagePackFormatter<JT808_0x8B0A>, JT808Bodies, IJT808Analyze
    {
        public ushort MsgId => 0x8B0A;

        public string Description => "升级通知";
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public ushort Port { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 跳过数据体序列化
        /// </summary>
        public bool SkipSerialization => false;

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8B0A value = new();
            value.IPAddress = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.IPAddress.Length}]IP地址", value.IPAddress);
            value.Port = reader.ReadUInt16();
            writer.WriteNumber($"[{value.Port.ReadNumber()}]端口号", value.Port);
            value.UserName = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.UserName.Length}]用户名", value.UserName);
            value.Password = reader.ReadStringEndChar0();
            writer.WriteString($"[Length:{value.Password.Length}]密码", value.Password);
        }

        public override JT808_0x8B0A Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8B0A value = new();
            value.IPAddress = reader.ReadStringEndChar0();
            value.Port = reader.ReadUInt16();
            value.UserName = reader.ReadStringEndChar0();
            value.Password = reader.ReadStringEndChar0();
            return value;
        }

        public override void Serialize(ref JT808MessagePackWriter writer, JT808_0x8B0A value, IJT808Config config)
        {
            writer.WriteStringEndChar0(value.IPAddress);
            writer.WriteUInt16(value.Port);
            writer.WriteStringEndChar0(value.UserName);
            writer.WriteStringEndChar0(value.Password);
        }
    }
}
