using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x8B01_Test
    {
        readonly JT808Serializer JT808Serializer;
        public JT808_0x8B01_Test()
        {
            ServiceCollection serviceDescriptors = new();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7E8B01004E000000000115F4830000000000003131350002010000000021042907000000000000000000000000000000000000C7EBD3DA37B5E330B7D6B7A2B3B53B7B54533A332C4F54533A312C4F543A36307D0100210429070009C97E".ToHexBytes());
        }
    }
}
