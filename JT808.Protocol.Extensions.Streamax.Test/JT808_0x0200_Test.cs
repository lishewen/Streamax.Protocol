using System;
using JT808.Protocol.Extensions.Streamax.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JT808.Protocol.Extensions.Streamax.Test
{
    public class JT808_0x0200_Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x0200_Test()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7E020000560000000007434D5A000000000004000301660C2E06A1A761002901AE000321102115245301040009DA7803020000E40201B8110900000000002C34001C2504000000002B040000000030010431010D1604000007E4170101180401010000C37E".ToHexBytes());
        }
    }
}
