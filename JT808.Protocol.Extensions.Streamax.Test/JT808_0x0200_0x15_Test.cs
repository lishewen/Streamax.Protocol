using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x0200_0x15_Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x0200_0x15_Test()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            // 0x0200 with 0x15 attachment: 异常驾驶行为报警详细描述
            var json = JT808Serializer.Analyze("7e02000064000000000000011500000000000400000007010203000000010203047e".ToHexBytes());
        }
    }
}
