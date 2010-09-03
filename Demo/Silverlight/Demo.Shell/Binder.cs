namespace Demo.Shell
{
    using System;
    using System.Windows;

    public static class Binder
    {
        public static DependencyProperty ModelProperty =
            DependencyProperty.RegisterAttached(
                "Model",
                typeof(object), 
                typeof(Binder),
                new PropertyMetadata(new PropertyChangedCallback(OnModelChanged)));

        public static object GetModel(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(ModelProperty);
        }

        public static void SetModel(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(ModelProperty, value);
        }

        private static void OnModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var f = d as FrameworkElement;
            if (f == null)
            {
                return;
            }

            RoutedEventHandler handler = null;
            handler = delegate(object sender, RoutedEventArgs args)
                          {
                              ViewModelLocator.Bind((string) e.NewValue, d);
                              f.Loaded -= handler;
                          };
            f.Loaded += handler;
        }
    }
}