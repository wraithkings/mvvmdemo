namespace Demo.Shell.ViewModels
{
    using System.ComponentModel;
    using Helpers;

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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}