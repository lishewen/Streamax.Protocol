using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x8B05_Test
    {
        readonly JT808Serializer JT808Serializer;
        public JT808_0x8B05_Test()
        {
            ServiceCollection serviceDescriptors = new();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7E8B050010000000000032003901210429070150343641303039344500C57E".ToHexBytes());
        }
    }
}
