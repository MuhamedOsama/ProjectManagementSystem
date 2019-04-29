using System;
using System.IO;
using System.Text;

namespace Logger
{
    public sealed class Log : ILog
    {
        private Log()
        {

        }
        private static readonly Lazy<Log> instance = new Lazy<Log>(()=>new Log());
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception",
                DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}",
                AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.Append(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}

