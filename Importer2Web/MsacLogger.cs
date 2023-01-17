using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    static class MsacLogger
    {
        private static FileStream file;

        public static FileInfo LogFile => new FileInfo("importer2web.log");

        public static void Initialize()
        {
            file = new FileStream(LogFile.FullName, FileMode.Append, FileAccess.Write);
            file.Position = file.Length;
        }

        public static void Flush()
        {
            file.Flush();
        }

        public static void Log(LogLevel level, string stationId, string message)
        {
            //Format
            string text = $"[{DateTime.Now.ToString("yyyy/MM/dd ddd HH:mm")}] [{level.ToString().ToUpper()}] [{stationId}] {message.Replace("\r", "").Replace("\n", "")}\n";
            byte[] data = Encoding.UTF8.GetBytes(text);

            //Write to file
            lock (file)
                file.Write(data, 0, data.Length);
        }

        public enum LogLevel
        {
            Info,
            Warn,
            Errr
        }
    }
}
