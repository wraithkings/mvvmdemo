namespace Demo.Shell.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Windows.Input;
    using Helpers;
    using Microsoft.Expression.Interactivity.Core;
    using TinyMvvmFramework;

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
        public ICommand GetFriendsCommand { get; set; }

        public ShellViewModel()
        {
            SetNameCommand = new ActionCommand((name) => Name = (string) name);
            GetFriendsCommand = new ActionCommand(() => FriendsService.GetFriends());
        }

        private IEnumerable<Friend> _friends;
        public System.Collections.Generic.IEnumerable<Friend> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                this.NotifyPropertyChanged(() => Friends, PropertyChanged);
            }
        }

        private IFriendsService _friendsService;

        [Import]
        public IFriendsService FriendsService
        {
            get { return _friendsService; }
            set
            {
                if (_friendsService != null)
                {
                    _friendsService.PropertyChanged -= FriendsServiceOnPropertyChanged;
                }
                _friendsService = value;
                _friendsService.PropertyChanged += FriendsServiceOnPropertyChanged;
                if (Designer.IsInDesignMode)
                {
                    _friendsService.GetFriends();
                }
            }
        }

        private void FriendsServiceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == NotifyPropertyChangedHelper.GetPropertyName(() => FriendsService.Friends))
            {
                this.Friends = FriendsService.Friends;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}