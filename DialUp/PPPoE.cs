using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialUp
{
    public class PPPoE
    {
        /// <summary>
        /// 使用PPPoE的方式连接宽带
        /// </summary>
        /// <param name="Name">宽带名称</param>
        /// <param name="Account">宽带账号</param>
        /// <param name="Password">宽带密码</param>
        /// <returns>成功返回1，失败返回0</returns>
        public static int Connect(string Name,string Account,string Password)
        {
            Process p = new Process();//新建一个进程对象
            p.StartInfo.FileName = "Rasdial.exe";//设置要启动的进程名字
            p.StartInfo.Arguments = Name + " " + Account + " " + Password;//传递参数 格式 连接名字+空格+账号+空格+密码
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//设置执行时的控制台为隐藏的
            p.Start();//开始执行
            p.WaitForExit();//等待连接后自动退出
            if (p.ExitCode == 0)//通过退出返回的代码判断连接是否成功
            {
                return 1;
            }
            else
                return 0;
        }

        /// <summary>
        /// PPPoE拨号方式断开连接
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int DisConnect(string Name)
        {
            Process p = new Process();//新建一个进程对象
            p.StartInfo.FileName = "Rasdial.exe";//设置要启动的进程名字
            p.StartInfo.Arguments = Name + " /disconnect";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//设置执行时的控制台为隐藏的
            p.Start();//开始执行
            p.WaitForExit();//等待连接后自动退出
            if (p.ExitCode == 0)//通过退出返回的代码判断连接是否成功
            {
                return 1;
            }
            else
                return 0;
        }
    }
}
