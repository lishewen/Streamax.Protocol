# Streamax.Protocol

## Project Overview

This is a .NET library implementing **Streamax (锐明) bus business protocol extensions** on top of the **JT/T 808** Chinese transportation standard protocol. JT/T 808 is the national standard for data communication between vehicle intelligent service terminals and dispatch centers in public transit systems.

The library provides serialization/deserialization for 21 custom message types used in Streamax bus operations, including:

| Message ID | Description | Direction |
|------------|-------------|-----------|
| 0x0B01 | 运营登记 (Operation Registration) | Terminal → Center |
| 0x0B02 | 到离站信息上报 (Arrival/Departure Report) | Terminal → Center |
| 0x0B03 | 进出定点信息上报 (Fixed Point Entry/Exit Report) | Terminal → Center |
| 0x0B04 | 违规信息上报 (Violation Report) | Terminal → Center |
| 0x0B05 | 考勤 (Attendance) | Terminal → Center |
| 0x0B06 | 校时请求 (Time Sync Request) | Terminal → Center |
| 0x0B07 | 行车计划请求 (Driving Plan Request) | Terminal → Center |
| 0x0B08 | 业务登记 (Business Registration) | Terminal → Center |
| 0x0B09 | 业务请求 (Business Request) | Terminal → Center |
| 0x0B0A | 升级结果上报 (Upgrade Result Report) | Terminal → Center |
| 0x0B0B | 设备故障上报 (Device Fault Report) | Terminal → Center |
| 0x0200_0x14 | 视频相关报警 (Video Alarm) | Terminal → Center |
| 0x0200_0x15 | 异常驾驶行为报警详细描述 (Abnormal Driving Behavior Detail) | Terminal → Center |
| 0x0200_0x16 | 线路编码 (Route Code) | Terminal → Center |
| 0x0200_0x17 | 业务类型 (Business Type) | Terminal → Center |
| 0x8B01 | 发车通知 (Departure Notification) | Center → Terminal |
| 0x8B02 | 业务变更指令 (Business Change Command) | Center → Terminal |
| 0x8B05 | 考勤应答 (Attendance Response) | Center → Terminal |
| 0x8B06 | 校时应答 (Time Sync Response) | Center → Terminal |
| 0x8B09 | 业务请求应答 (Business Request Response) | Center → Terminal |
| 0x8B0A | 升级通知 (Upgrade Notification) | Center → Terminal |

## Technology Stack

- **Language:** C#
- **Framework:** .NET 8.0 / 9.0 / 10.0 (multi-target)
- **Base Library:** [JT808](https://www.nuget.org/packages/JT808/) v2.7.8
- **Test Framework:** xUnit v3
- **Package ID:** `JT808.Protocol.Extensions.Streamax` (v0.6.2)
- **License:** MIT

## Project Structure

```
Streamax.Protocol/
├── JT808.Protocol.Extensions.Streamax/     # Main library
│   ├── Enums/                              # Protocol enum types (ViolationType, AttendanceType, etc.)
│   ├── MessageBody/                        # 22 message body implementations
│   ├── JT808_Streamax_Constants.cs         # Message ID constants
│   └── StreamaxDependencyInjectionExtensions.cs  # DI registration extension
├── JT808.Protocol.Extensions.Streamax.Test/ # Unit tests (xUnit)
├── docs/                                   # Protocol documentation (PDF)
│   └── 第5部分 城市公共汽电车车载智能服务终端与调度中心间数据通信协议.pdf
└── Streamax.Protocol.sln                   # Visual Studio solution
```

## Building and Running

### Prerequisites
- .NET 8.0+ SDK (or .NET 10.0 for tests)

### Commands

```bash
# Restore dependencies
dotnet restore

# Build
dotnet build

# Run tests
dotnet test

# Build for a specific framework
dotnet build -f net8.0
```

### CI/CD

GitHub Actions workflow (`.github/workflows/dotnet.yml`) runs on push/PR to `master`:
- Setup .NET 9.0
- Restore → Build → Test

## Usage

```csharp
using Microsoft.Extensions.DependencyInjection;
using JT808.Protocol.Extensions.Streamax;

IServiceCollection serviceDescriptors = new ServiceCollection();
serviceDescriptors.AddJT808Configure()
                  .AddStreamaxConfigure();

// Then resolve JT808Serializer from the service provider
var serviceProvider = serviceDescriptors.BuildServiceProvider();
var jT808Config = serviceProvider.GetRequiredService<IJT808Config>();
var serializer = new JT808Serializer(jT808Config);
```

## Development Conventions

### Message Body Pattern

Each message type follows this structure:

```csharp
public class JT808_0xXXXX : JT808MessagePackFormatter<JT808_0xXXXX>, JT808Bodies, IJT808Analyze
{
    public ushort MsgId => 0xXXXX;
    public string Description => "...";
    public bool SkipSerialization => false;

    public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config) { ... }
    public override JT808_0xXXXX Deserialize(ref JT808MessagePackReader reader, IJT808Config config) { ... }
    public override void Serialize(ref JT808MessagePackWriter writer, JT808_0xXXXX value, IJT808Config config) { ... }
}
```

### Testing Pattern

Tests use xUnit and are organized per message type (`JT808_0xXXXX_Test.cs`):

```csharp
public class JT808_0xXXXX_Test
{
    JT808Serializer JT808Serializer;
    public JT808_0xXXXX_Test()
    {
        ServiceCollection serviceDescriptors = new ServiceCollection();
        serviceDescriptors.AddJT808Configure().AddStreamaxConfigure();
        IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
        JT808Serializer = new JT808Serializer(jT808Config);
    }
    [Fact]
    public void TestMethod() { ... }
}
```

### Naming Conventions

- Message bodies: `JT808_0x{MessageId}.cs` (e.g., `JT808_0x0B01.cs`)
- Enums: PascalCase (e.g., `ViolationType.cs`)
- Test classes: `JT808_0x{MessageId}_Test.cs`
- Enum values use Chinese characters (e.g., `超速行车 = 0x01`)

## Notes

- The project depends on the external `JT808` base library for core serialization infrastructure
- Message bodies register themselves via `JT808Bodies` interface through assembly scanning in `AddStreamaxConfigure()`
- The `IJT808Analyze` interface provides JSON analysis/debugging capability
- Protocol reference documentation is in `docs/第5部分 ... .pdf`
