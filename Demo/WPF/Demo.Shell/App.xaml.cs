namespace Demo.Shell
{
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var bootstrapper = new Bootstrapper();
        }
    }
}