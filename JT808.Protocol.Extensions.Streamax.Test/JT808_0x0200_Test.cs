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
            ServiceCollection serviceDescriptors = new();
            serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze("7E0200008400000000081505A4000000020004000301661F1306A1424E002E01C2008A2205260822290104000AB72103020000E40201B8110600000000002C2504000000002B040000000030010431010D16040000012C1701011804010C0000642F0A36C44501020100000000002D002E01661F1306A1424E220526082228000138313500494F4E220526082228000200197E".ToHexBytes());
        }
    }
}
