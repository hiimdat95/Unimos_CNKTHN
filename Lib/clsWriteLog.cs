using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lib
{
    public class clsWriteLog
    {
        public clsWriteLog()
        { }

        public void LogDongBo(string strLog, string SQL)
        {
            string Path = Application.StartupPath +"\\Logging";
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            string Content = " Time: " + System.DateTime.Now.ToString() + "\n SQL: " + SQL + "\n Error: " + strLog + "\n\n";
            File.AppendAllText(Path + "\\LogDongBo.txt", Content);
        }
    }
}
