using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x8B0A_Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x8B0A_Test()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            string str = JT808Serializer.Serialize(new JT808_0x8B0A { IPAddress = "192.168.1.1", Port = 9400, UserName = "lishewen", Password = "123456" }).ToHexString();
            var json = JT808Serializer.Analyze<JT808_0x8B0A>(str.ToHexBytes());
        }
    }
}
