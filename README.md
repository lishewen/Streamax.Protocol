# Streamax.Protocol
锐明808扩展协议
## NuGet安装

| Package Name          | Version                                            | Downloads                                           |
| --------------------- | -------------------------------------------------- | --------------------------------------------------- |
| Install-Package JT808.Protocol.Extensions.Streamax | ![JT808.Protocol.Extensions.Streamax](https://img.shields.io/nuget/v/JT808.Protocol.Extensions.Streamax.svg) | ![JT808.Protocol.Extensions.Streamax](https://img.shields.io/nuget/dt/JT808.Protocol.Extensions.Streamax.svg) |

### JT808扩展协议消息对照表

| 序号  | 消息ID | 完成情况 | 测试情况 | 消息体名称 |
| :---: | :---: | :---: | :---: | :---:|
| 1 | 0x0B02 | √ | √ | 到离站信息上报 |
| 2 | 0x0B03 | √ | √ | 进出定点信息上报 |
| 3 | 0x0B04 | √ | √ | 违规信息上报 |
| 4 | 0x0B05 | √ | √ | 考勤 |
| 5 | 0x0B09 | √ | √ | 业务请求 |
| 6 | 0x0200_0x16 | √ | - | 线路编码 |
| 7 | 0x0200_0x17 | √ | - | 业务类型 |

### 使用方法

```csharp
IServiceCollection serviceDescriptors = new ServiceCollection();
serviceDescriptors.AddJT808Configure()
                  .AddStreamaxConfigure();
```
