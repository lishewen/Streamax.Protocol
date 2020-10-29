# Streamax.Protocol
锐明808公交业务扩展协议
## NuGet安装

| Package Name          | Version                                            | Downloads                                           |
| --------------------- | -------------------------------------------------- | --------------------------------------------------- |
| Install-Package JT808.Protocol.Extensions.Streamax | ![JT808.Protocol.Extensions.Streamax](https://img.shields.io/nuget/v/JT808.Protocol.Extensions.Streamax.svg) | ![JT808.Protocol.Extensions.Streamax](https://img.shields.io/nuget/dt/JT808.Protocol.Extensions.Streamax.svg) |

### 锐明JT808公交业务扩展协议消息对照表

| 序号  | 消息ID | 完成情况 | 测试情况 | 消息体名称 |
| :---: | :---: | :---: | :---: | :---: |
| 1 | 0x0B01 | √ | - | 运营登记 |
| 2 | 0x0B02 | √ | √ | 到离站信息上报 |
| 3 | 0x0B03 | √ | √ | 进出定点信息上报 |
| 4 | 0x0B04 | √ | √ | 违规信息上报 |
| 5 | 0x0B05 | √ | √ | 考勤 |
| 6 | 0x0B06 | √ | - | 校时请求 |
| 7 | 0x8B06 | √ | - | 校时应答 |
| 8 | 0x0B07 | √ | - | 行车计划请求 |
| 9 | 0x0B08 | √ | - | 业务登记 |
| 10 | 0x0B09 | √ | √ | 业务请求 |
| 11 | 0x0B0B | √ | √ | 设备故障上报 |
| 12 | 0x0200_0x14 | √ | - | 视频相关报警 |
| 13 | 0x0200_0x15 | √ | - | 异常驾驶行为报警详细描述 |
| 14 | 0x0200_0x16 | √ | √ | 线路编码 |
| 15 | 0x0200_0x17 | √ | √ | 业务类型 |
| 16 | 0x8B02 | √ | - | 业务变更指令 |
| 17 | 0x8B0A | √ | √ | 升级通知 |

### 使用方法

```csharp
IServiceCollection serviceDescriptors = new ServiceCollection();
serviceDescriptors.AddJT808Configure()
                  .AddStreamaxConfigure();
```
