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
            var json = JT808Serializer.Analyze("7e0200007c000000000804008300000000000400030166d50c06a17b44002500dc003b200930100721010400018ad403020000e40201b82504000000002b040000000030010531010f1604000000aa170101180400060000642f071be45901040100000000001600250166d50c06a17b44200930100721000138303400004500200930100721000200087e".ToHexBytes());
        }
    }
}
