using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace onlineLegalWF
{
    public class LogHelper
    {
        private static Object writeLock = new Object();
        public static void Write(string msg)
        {
            lock (writeLock)
            {
                string fileName = ConfigurationManager.AppSettings["INFO_LOG"].ToString() + "Log_" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                if (!System.IO.File.Exists(fileName))
                {
                   var log = System.IO.File.Create(fileName);
                    log.Close();
                    log.Dispose(); 
                }
                using (FileStream file = new FileStream(fileName, FileMode.Append))
                {
                    StreamWriter log = new StreamWriter(file);
                    log.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), msg));
                    log.Close();
                }
            }
        }
        public static void WriteLogSendMail(string msg)
        {
            lock (writeLock)
            {
                string fileName = ConfigurationManager.AppSettings["INFO_LOG"].ToString() + "Mail_Log_" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                if (!System.IO.File.Exists(fileName))
                {
                    var log = System.IO.File.Create(fileName);
                    log.Close();
                    log.Dispose();
                }
                using (FileStream file = new FileStream(fileName, FileMode.Append))
                {
                    StreamWriter log = new StreamWriter(file);
                    log.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), msg));
                    log.Close();
                }
            }
        }

        public static void Write(string fileName, string msg, bool addDate = true)
        {
            if (System.IO.File.Exists(fileName) == false)
            {
                var file =   System.IO.File.Create(fileName);
                StreamWriter log = new StreamWriter(file);
                if (addDate)
                    log.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), msg));
                else
                    log.WriteLine(string.Format("{0}", msg));
                log.Close();
            }
            else
            {
                lock (writeLock)
                {
                    using (FileStream file = new FileStream(fileName, FileMode.Append))
                    {
                        StreamWriter log = new StreamWriter(file);
                        if (addDate)
                            log.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), msg));
                        else
                            log.WriteLine(string.Format("{0}", msg));
                        log.Close();
                    }
                }
            }
        }

        public static void Write(Exception e)
        {
            WriteEx(e);
        }

        public static void WriteEx(Exception e)
        {
            try
            {
                var stringBuilder = new StringBuilder();

                while (e != null)
                {
                    stringBuilder.AppendLine(e.Message);
                    stringBuilder.AppendLine(e.StackTrace);

                    e = e.InnerException;
                }

                Write(stringBuilder.ToString());
            }
            catch (Exception ex)
            {
                Write(ex.Message);
            }
        }
    }
}