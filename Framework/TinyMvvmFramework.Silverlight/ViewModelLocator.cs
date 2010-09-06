namespace TinyMvvmFramework
{
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;

    public static class ViewModelLocator
    {
        private static CompositionContainer _container;

        public static CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new CompositionContainer();
                }
                return _container;
            }
            set { _container = value; }
        }

        public static void Bind(string viewModelName, DependencyObject dependencyObject)
        {
            if (_container == null)
            {
                return;
            }
            var vm = _container.GetExportedValue<object>(viewModelName);
            var fe = dependencyObject as FrameworkElement;
            fe.DataContext = vm;
        }
    }
}