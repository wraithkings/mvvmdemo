namespace TinyMvvmFramework
{
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;

    public static class ViewModelLocator
    {
        public static CompositionContainer Container;

        public static void Bind(string viewModelName, DependencyObject dependencyObject)
        {
            var vm = Container.GetExportedValue<object>(viewModelName);
            var fe = dependencyObject as FrameworkElement;
            fe.DataContext = vm;
        }
    }
}