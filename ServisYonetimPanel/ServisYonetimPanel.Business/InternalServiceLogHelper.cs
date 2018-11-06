namespace ServisYonetimPanel.Business
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    internal class InternalServiceLogHelper
    {
        internal static void LogException(Exception e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                StackFrame frm = new StackFrame(2, true);
                MethodBase mthd = frm.GetMethod();
                int line = frm.GetFileLineNumber();
                int col = frm.GetFileColumnNumber();

                string assName = mthd.Module.Assembly.FullName;
                string className = mthd.ReflectedType.Name;
                string assFileName = frm.GetFileName();
                string methodName = mthd.Name;

                string folderName = $"{AssemblyDirectory}/SeviceErrors";

                try
                {
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                }
                catch (Exception ex)
                {
                }

                var ErrorFileDateFormat = "yyyy-MM-dd-HH-mm-ss"; ;
                var ErrorFileName = $"service-error-{DateTime.Now.ToString(ErrorFileDateFormat)}.log";
                string fileName = $"{folderName}/{ErrorFileName}";
                var GeneralDateFormat = "yyyy-MM-dd, HH:mm:ss ffffff";
                var Lines = "----------------------------------";
                List<string> rows = new List<string>
                {
                    $"Time : {dt.ToString(GeneralDateFormat)}",
                    $"Assembly : {assName}",
                    $"Class : {className}",
                    $"Method Name : {methodName}",
                    $"Line : {line}",
                    $"Column : {col}",
                    $"Message : {e.Message}",
                    $"Stack Trace : {e.StackTrace}",
                    Lines
                };

                ServiceFileOperator.Instance.Write(fileName, rows);
            }
            catch (Exception ee)
            {
            }
        }

        private static string AssemblyDirectory
        {
            get
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                return dir;
            }
        }
    }
}