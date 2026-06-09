using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.Streamax
{
    public static class JT808_Streamax_Constants
    {
        #region 设备上报消息 (Terminal -> Center, 0x0Bxx)

        /// <summary>
        /// 运营登记
        /// </summary>
        public const uint JT808_0x0B01 = 0x0B01;
        /// <summary>
        /// 到离站信息上报
        /// </summary>
        public const uint JT808_0x0B02 = 0x0B02;
        /// <summary>
        /// 进出定点信息上报
        /// </summary>
        public const uint JT808_0x0B03 = 0x0B03;
        /// <summary>
        /// 违规信息上报
        /// </summary>
        public const uint JT808_0x0B04 = 0x0B04;
        /// <summary>
        /// 考勤
        /// </summary>
        public const uint JT808_0x0B05 = 0x0B05;
        /// <summary>
        /// 校时请求
        /// </summary>
        public const uint JT808_0x0B06 = 0x0B06;
        /// <summary>
        /// 行车计划请求
        /// </summary>
        public const uint JT808_0x0B07 = 0x0B07;
        /// <summary>
        /// 业务登记
        /// </summary>
        public const uint JT808_0x0B08 = 0x0B08;
        /// <summary>
        /// 业务请求
        /// </summary>
        public const uint JT808_0x0B09 = 0x0B09;
        /// <summary>
        /// 升级结果上报
        /// </summary>
        public const uint JT808_0x0B0A = 0x0B0A;
        /// <summary>
        /// 设备故障上报
        /// </summary>
        public const uint JT808_0x0B0B = 0x0B0B;

        #endregion

        #region 平台下发消息 (Center -> Terminal, 0x8Bxx)

        /// <summary>
        /// 发车通知
        /// </summary>
        public const uint JT808_0x8B01 = 0x8B01;
        /// <summary>
        /// 业务变更指令
        /// </summary>
        public const uint JT808_0x8B02 = 0x8B02;
        /// <summary>
        /// 考勤应答
        /// </summary>
        public const uint JT808_0x8B05 = 0x8B05;
        /// <summary>
        /// 校时应答
        /// </summary>
        public const uint JT808_0x8B06 = 0x8B06;
        /// <summary>
        /// 业务请求应答
        /// </summary>
        public const uint JT808_0x8B09 = 0x8B09;
        /// <summary>
        /// 升级通知
        /// </summary>
        public const uint JT808_0x8B0A = 0x8B0A;

        #endregion

        #region 0x0200 位置信息汇报附加信息

        /// <summary>
        /// 视频相关报警
        /// </summary>
        public const byte JT808_0x0200_0x14 = 0x14;
        /// <summary>
        /// 异常驾驶行为报警详细描述
        /// </summary>
        public const byte JT808_0x0200_0x15 = 0x15;
        /// <summary>
        /// 线路编码
        /// </summary>
        public const byte JT808_0x0200_0x16 = 0x16;
        /// <summary>
        /// 业务类型
        /// </summary>
        public const byte JT808_0x0200_0x17 = 0x17;
        /// <summary>
        /// 限速值
        /// </summary>
        public const byte JT808_0x0200_0xE4 = 0xE4;

        #endregion
    }
}
