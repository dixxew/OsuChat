using System;
using System.Windows;

namespace OsuChat.Core
{
    static class TimeExtensions
    {
        public static string GetMessageTimeGovno(DependencyObject obj)
        {
            return (string)obj.GetValue(MessageTimeProperty);
        }
        public static void SetMessageTimeGovno(DependencyObject obj, string value)
        {
            obj.SetValue(MessageTimeProperty, value);
        }
        public static readonly DependencyProperty MessageTimeProperty =
            DependencyProperty.RegisterAttached(
                "MessageTimeGovno", typeof(string), typeof(TimeExtensions));
    }
}
