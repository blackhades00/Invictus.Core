using System;

namespace Invictus.Core.Invictus.LogService
{
    internal class Logger
    {
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal enum eLoggerType
        {
            Debug,
            Info,
            Warn,
            Error,
            Fatal
        };

        internal static void Log(string message, eLoggerType logType)
        {
            switch (logType)
            {
                case eLoggerType.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    logger.Debug("[DEBUG] " + message);
                    return;
                case eLoggerType.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    logger.Warn("[WARNING] " + message);
                    return;
                case eLoggerType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Error("[ERROR] " + message);
                    return;
                case eLoggerType.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    logger.Fatal("[FATAL ERROR] " + message);
                    return;
                case eLoggerType.Info:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    logger.Info(message);
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Warn(
                        " The Logger was supposed to log here, but no appropriate LogLevel has been found. Contact a Moderator if this issue isn't fixed automatically after restarting the application.");
                    logger.Warn(" If there aren't any issues and Invictus is working fine, no restart is required.");
                    return;
            }
        }
    }
}