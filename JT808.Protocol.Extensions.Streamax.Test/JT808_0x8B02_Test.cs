using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x8B02_Test
    {
        readonly JT808Serializer JT808Serializer;
        public JT808_0x8B02_Test()
        {
            ServiceCollection serviceDescriptors = new();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7E8B020006000000000115F484000000000200E97E".ToHexBytes());
        }
    }
}
