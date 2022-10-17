using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialUp
{
    internal class OpenFolder
    {
        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="folderPath">目录路径（比如：C:\Users\Administrator\）</param>
        public static void Open(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = folderPath;
            process.StartInfo = psi;

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                process?.Close();

            }

        }

        /// <summary>
        /// 打开目录且选中文件
        /// </summary>
        /// <param name="filePathAndName">文件的路径和名称（比如：C:\Users\Administrator\test.txt）</param>
        public static void OpenFolderAndSelectedFile(string filePathAndName)
        {
            if (string.IsNullOrEmpty(filePathAndName)) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePathAndName;
            process.StartInfo = psi;

            //process.StartInfo.UseShellExecute = true;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                process?.Close();

            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="filePathAndName">文件的路径和名称（比如：C:\Users\Administrator\test.txt）</param>
        /// <param name="isWaitFileClose">是否等待文件关闭（true：表示等待）</param>
        public static void OpenFile(string filePathAndName, bool isWaitFileClose = true)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(filePathAndName);
            process.StartInfo = psi;

            process.StartInfo.UseShellExecute = true;

            try
            {
                process.Start();

                //等待打开的程序关闭
                if (isWaitFileClose)
                {
                    process.WaitForExit();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                process?.Close();

            }
        }
    }
}
