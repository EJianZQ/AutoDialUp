using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoDialUp.Data
{
    public class TimePlan
    {
        public class OneDay
        {
            /// <summary>
            /// 是否初始化
            /// </summary>
            public bool Initialized { get; set; }
            /// <summary>
            /// 星期几
            /// </summary>
            public int DayIndex { get; set; }
            /// <summary>
            /// 开启还是关闭
            /// </summary>
            public bool Enabled { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public string StartTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndTime { get; set; }

            /// <summary>
            /// 检查现在的时间是否在设定的开始结束范围内
            /// </summary>
            /// <returns></returns>
            public bool Check()
            {
                //如果是还没初始化完json和对象就开始检查，先在这里卡住等初始化完成再继续
                for(; ; )
                {
                    if (Initialized == false)
                        Thread.Sleep(50);
                    else
                        break;
                }
                TimeSpan dspWorkingDayStart = DateTime.Parse(StartTime).TimeOfDay;
                TimeSpan dspWorkingDayEnd = DateTime.Parse(EndTime).TimeOfDay;
                TimeSpan dspNow = DateTime.Now.TimeOfDay;
                //如果是选择了在时间段内执行 => 时间段内执行，时间段外不执行
                //如果是选择了在时间段内不执行 => 时间段内不执行，时间段外执行
                if(Enabled == true)
                {
                    if (dspNow > dspWorkingDayStart && dspNow < dspWorkingDayEnd)
                    {
                        //在时间段内，要执行
                        return true;
                    }
                    else
                    {
                        //不在时间段内，不执行
                        return false;
                    }
                }
                else
                {
                    if (dspNow > dspWorkingDayStart && dspNow < dspWorkingDayEnd)
                    {
                        //在时间段内，不执行
                        return false;
                    }
                    else
                    {
                        //不在时间段内，要执行
                        return true;
                    }
                }
            }

            /// <summary>
            /// 检查开始与结束时间数据的合法性：是否结束时间早于开始时间
            /// </summary>
            /// <returns></returns>
            public bool CheckValidity()
            {
                DateTime t1 = DateTime.Parse(StartTime);
                DateTime t2 = DateTime.Parse(EndTime);
                if (DateTime.Compare(t1,t2) < 0)
                {
                    return true;
                }
                else
                    return false;
            }

            /// <summary>
            /// 检查此实例的所有数据是否都完全有实际数据
            /// </summary>
            /// <returns></returns>
            public bool CheckCompleteness()
            {
                if(StartTime == String.Empty || EndTime == String.Empty)
                    return false;
                return true;
            }

            public OneDay()
            {}

            public OneDay(bool ifInitialized)
            {
                if(ifInitialized == false)
                {
                    Initialized = true;
                    Enabled = true;
                    StartTime = @"00:00:01";
                    EndTime = @"23:59:59";

                }
            }

            /// <summary>
            /// 将TimeStamp转换为DateTime
            /// </summary>
            /// <param name="timeStamp"></param>
            /// <returns></returns>
            private DateTime ToDateTime(string timeStamp)
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                long lTime = long.Parse(timeStamp + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dtStart.Add(toNow);
            }
        }

        /// <summary>
        /// 获取现在是星期几
        /// </summary>
        /// <returns></returns>
        public static int WhichDay()
        {
            int day = Convert.ToInt32(DateTime.Now.DayOfWeek);
            if (day != 0)
                return day;
            else
                return 7;//星期天是0，为了方便直接返回7
        }
        public static class DaysCollections
        {
            public static OneDay Mon { get; set; }
            public static OneDay Tues { get; set; }
            public static OneDay Wed { get; set; }
            public static OneDay Thur { get; set; }
            public static OneDay Fri { get; set; }
            public static OneDay Sat { get; set; }
            public static OneDay Sun { get; set; }
        }
    }
}
