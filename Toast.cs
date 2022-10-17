using System;
using Notifications.Wpf;

namespace AutoDialUp
{
    class Toast
    {
        private static readonly NotificationManager _notificationManager = new NotificationManager();
        /// <summary>
        /// Toast 通知 WPF版
        /// </summary>
        public static void ShowNotifiy(string Title, string Text, NotificationType Type)
        {
            var content = new NotificationContent
            {
                Title = Title,
                Message = Text,
                Type = Type
            };
            _notificationManager.Show(content);
        }

        /// <summary>
        /// Toast 通知 WPF版 带方法
        /// </summary>
        public static void ShowNotifiy(string Title, string Text, NotificationType Type, Action Click = null, Action Close = null)
        {
            var content = new NotificationContent
            {
                Title = Title,
                Message = Text,
                Type = Type
            };
            if (Click == null)
                Click = new Action(WPFError);
            if (Close == null)
                Close = new Action(WPFError);
            _notificationManager.Show(content, "", onClick: () => Click(), onClose: () => Close());
        }

        private static void WPFError()
        {
            Console.WriteLine("未设置Toast点击或结束时的方法");
        }
    }
}
