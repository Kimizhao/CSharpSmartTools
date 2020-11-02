using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLog;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;


namespace AToolPlus
{
    public class LogHelper
    {
        private static string logPath = string.Empty;
        private static readonly object lockobj = new object();
        private static Logger loggerDebug = null;
        private static Logger loggerTrace = null;
        /// <summary>
        /// 需在初始化Init后，使用该对象
        /// </summary>
        public static Logger Instance
        {
            get {
                lock (lockobj) {
                    if (!Ready)
                        Init();
                }
                return loggerDebug; 
            }
        }

        public static void Debug(string log)
        {
            Instance.Debug(log);
        }

        public static void Info(string log)
        {
            Instance.Info(log);
        }

        public static void Trace(string log)
        {
            Instance.Trace(log);
        }

        public static void Warn(string log)
        {
            Instance.Warn(log);
        }
        public static void Warn(string log, Exception ex)
        {
            StringBuilder strexp = new StringBuilder();
            strexp.Append(Environment.NewLine);
            strexp.Append("\t\t\t\t\t\t┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉");
            if (!string.IsNullOrEmpty(log))
            {
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000日志描述:" + log);
            }
            strexp.Append(Environment.NewLine);
            strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000日志触发时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            if (ex != null)
            {
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常类型:" + ex.GetType().FullName);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常来自:" + ex.Source);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t引发异常的方法:" + ex.TargetSite);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常内容:" + ex.Message);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t异常堆栈上的帧:" + ex.StackTrace);
                strexp.Append(Environment.NewLine);
            }
            strexp.Append("\t\t\t\t\t\t┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉");
            strexp.Append(Environment.NewLine);
            Instance.Warn(strexp.ToString());
        }

        public static void Fatal(string log)
        {
            Instance.Fatal(log);
        }
        public static void Fatal(string log,Exception ex)
        {
            Instance.Fatal(log, ex);
        }

        public static void Error(string log)
        {
            Instance.Error(log);
        }

        public static void Error(string log, Exception ex)
        {
            StringBuilder strexp = new StringBuilder();
            strexp.Append(Environment.NewLine);
            strexp.Append("\t\t\t\t\t\t┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉");
            if (!string.IsNullOrEmpty(log))
            {
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000日志描述:" + log);
            }
            strexp.Append(Environment.NewLine);
            strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000日志触发时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            if (ex != null)
            {
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常类型:" + ex.GetType().FullName);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常来自:" + ex.Source);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t引发异常的方法:" + ex.TargetSite);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t\u3000\u3000\u3000异常内容:" + ex.Message);
                strexp.Append(Environment.NewLine);
                strexp.Append("\t\t\t\t\t\t异常堆栈上的帧:" + ex.StackTrace);
                strexp.Append(Environment.NewLine);
            }
            strexp.Append("\t\t\t\t\t\t┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉┉");
            strexp.Append(Environment.NewLine);
            Instance.Error(strexp.ToString());
        }

        public static bool Ready { get; set; }

        private static void initLogger()
        {
            //logger = LogManager.GetCurrentClassLogger();

            // Step 1. Create configuration object
            LoggingConfiguration logConfig = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration
            //RichTextBoxTarget rtbTarget = new RichTextBoxTarget();
            //logConfig.AddTarget("richTextBox", rtbTarget);
            //rtbTarget.FormName = "frmScrapeAmazonProduct"; // your winform class name
            //rtbTarget.ControlName = "rtbLog"; // your RichTextBox control/variable name

            FileTarget fileTarget = new FileTarget();
            logConfig.AddTarget("logFile", fileTarget);

            // Step 3. Set target properties
            string commonLayout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${logger} ${message}";
            //rtbTarget.Layout = commonLayout;

            //string curDatetimeStr = DateTime.Now.ToString();
            DateTime curDateTime = DateTime.Now;
            string curDatetimeStr = String.Format("{0:yyyy-MM-dd_HHmmss}", curDateTime); //"2013-06-11_142102"
            fileTarget.FileName = "${basedir}/" + curDatetimeStr + "_log.txt"; //{'${basedir}/2013-06-11_142102_log.txt'}
            fileTarget.Layout = commonLayout;

            // Step 4. Define rules
            //LoggingRule ruleRichTextBox = new LoggingRule("*", LogLevel.Debug, rtbTarget);
            //logConfig.LoggingRules.Add(ruleRichTextBox);

            LoggingRule ruleFile = new LoggingRule("*", LogLevel.Debug, fileTarget);
            logConfig.LoggingRules.Add(ruleFile);

            // Step 5. Activate the configuration
            LogManager.Configuration = logConfig;

            // Example usage
            //Logger logger = LogManager.GetLogger("Amazon");
            Logger logger = LogManager.GetLogger("");
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
        }
        public static void SetLogLevel()
        {
            LoggingRule v = LogManager.Configuration.LoggingRules[0] as LoggingRule;
        }
        public static void Init(string logpath="",int logSaveDayLong=7,long fileSize=1024*1024*5+20) 
        {
            LogHelper.Ready = false;

            if (logpath.Length == 0)
                logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            else
                logPath = logpath;

            //Internal logger
            InternalLogger.LogToConsole = false;
            InternalLogger.LogFile = logPath + "/internalLog.txt";
            InternalLogger.LogWriter = new StringWriter();
            InternalLogger.LogLevel = LogLevel.Warn;

            // Step 1. Create configuration object
            LoggingConfiguration logConfig = new LoggingConfiguration();

            // Step 3. Set target properties
            //string commonLayout = @"${date:format=yyyy-MM-dd HH\:mm\:ss.fff} ${level:uppercase=true} | ${message} --> ${stacktrace} | ${newline} ${exception}";
            string commonLayout = @"${date:format=yyyy-MM-dd HH\:mm\:ss\.fff} ${level:uppercase=true} | ${message} ${onexception:${exception:format=tostring} ${newline} ${stacktrace} ${newline}";

            FileTarget fileTarget = new FileTarget();
            logConfig.AddTarget("logFile", fileTarget);
            fileTarget.FileName = logPath + "/${shortdate}.txt";
            fileTarget.MaxArchiveFiles = int.MaxValue;
            fileTarget.ArchiveFileName = logPath + @"/archives/${shortdate}_{#####}.txt";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Rolling;
            fileTarget.AutoFlush = true;
            fileTarget.DeleteOldFileOnStartup = false; 
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.CreateDirs = true;
            fileTarget.ArchiveAboveSize = fileSize;
            fileTarget.KeepFileOpen = false;
            fileTarget.ConcurrentWrites = true;
            fileTarget.Layout = commonLayout;

            LoggingRule ruleFile = new LoggingRule("*", LogLevel.Trace, fileTarget);
            logConfig.LoggingRules.Add(ruleFile);

            //控制台日志
            var consoleTarget = new ColoredConsoleTarget();
            consoleTarget.UseDefaultRowHighlightingRules = false;
            consoleTarget.Layout = commonLayout;
            consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Debug"), ConsoleOutputColor.DarkGray, ConsoleOutputColor.Black));
            consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Info"), ConsoleOutputColor.Gray, ConsoleOutputColor.Black));
            consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Warn"), ConsoleOutputColor.Yellow, ConsoleOutputColor.Black));
            consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Error"), ConsoleOutputColor.Red, ConsoleOutputColor.Black));
            consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule(ConditionParser.ParseExpression("level == LogLevel.Fatal"), ConsoleOutputColor.Red, ConsoleOutputColor.White));
            LoggingRule ruleColoredConsole = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            logConfig.LoggingRules.Add(ruleColoredConsole);

            // Step 5. Activate the configuration
            LogManager.Configuration = logConfig;

            loggerDebug = LogManager.GetLogger("");
            
            System.Threading.Tasks.Task.Factory.StartNew(() => {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000 * 30);
                    try
                    {
                        FileInfo[] fil = new DirectoryInfo(logPath).GetFiles("*.txt", SearchOption.AllDirectories);
                        foreach (FileInfo f in fil)
                        {
                            string[] arr = f.Name.Split('_');
                            if (arr != null && arr.Length > 0)
                            {
                                DateTime tm = DateTime.Now;
                                if (DateTime.TryParse(arr[0], out tm) && DateTime.Now.Subtract(tm).TotalDays > logSaveDayLong)
                                {
                                    f.Delete();
                                }
                            }
                        }
                    }
                    catch{
                    }
                }
            }, System.Threading.Tasks.TaskCreationOptions.LongRunning);
                        
            LogHelper.Ready = true;

        }
    }
}
