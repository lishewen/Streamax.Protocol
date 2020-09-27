using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x0B04_Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x0B04_Test()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7e0b0400270000000007240dd3000000f00c000401664b3006a1912e0023019a005b20092706000800d2ecb3a3bfaab9d8c3c500967e".ToHexBytes());
        }
    }
}
