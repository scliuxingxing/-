using log4net;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
[assembly: log4net.Config.XmlConfigurator()]
//文件里添加下面代码，让程序启动时是找到Log4net.config配置文件
namespace ScaipMDAS
{
    public static class LogHelper
    {
        static readonly ILog _logger = LogManager.GetLogger("LogTrace");

        /// <summary>
        /// 写入一条“信息”日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            _logger.Info(message);                               //打印事件
        }

        /// <summary>
        /// 写入一条“调试”日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            _logger.Debug(message);                             //调试
        }

        /// <summary>
        /// 写入一条“警告”日志
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            _logger.Warn(message);                              //警告
        }

        /// <summary>
        /// 写入一条“错误”日志 
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            _logger.Error(message);                             //错误
        }
    }
}
