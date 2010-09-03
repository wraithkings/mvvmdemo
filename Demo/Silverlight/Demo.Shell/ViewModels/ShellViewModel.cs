namespace Demo.Shell.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Windows.Input;
    using Helpers;
    using Microsoft.Expression.Interactivity.Core;

    [Export("ShellViewModel")]
    public class ShellViewModel : INotifyPropertyChanged
    {
        private string _name = "Test";

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.NotifyPropertyChanged(() => Name, PropertyChanged);
            }
        }

        public ICommand SetNameCommand { get; set; }

        public ShellViewModel()
        {
            SetNameCommand = new ActionCommand((name) => Name = (string) name);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}