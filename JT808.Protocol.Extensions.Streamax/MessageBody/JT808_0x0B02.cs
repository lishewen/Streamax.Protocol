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
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            throw new NotImplementedException();
        }

        public JT808_0x0B02 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            throw new NotImplementedException();
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0B02 value, IJT808Config config)
        {
            throw new NotImplementedException();
        }
    }
}
