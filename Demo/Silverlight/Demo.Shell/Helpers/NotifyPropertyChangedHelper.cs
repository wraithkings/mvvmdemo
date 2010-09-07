namespace Demo.Shell.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public static class NotifyPropertyChangedHelper
    {
        public static void NotifyPropertyChanged<T>(this INotifyPropertyChanged src, Expression<Func<T>> property, PropertyChangedEventHandler handler)
        {
            if (handler != null)
            {
                string name = GetPropertyName(property);
                handler(src, new PropertyChangedEventArgs(name));
            }
        }

        public static string GetPropertyName<T>(Expression<Func<T>> property)
        {
            return ((MemberExpression) property.Body).Member.Name;
        }
    }
}