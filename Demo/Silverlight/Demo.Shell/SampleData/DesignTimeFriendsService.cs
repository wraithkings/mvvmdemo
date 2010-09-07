namespace Demo.Shell.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using Helpers;

    [Export(typeof(IFriendsService))]
    [PartMetadata("IsDesignService", true)]
    public class DesignTimeFriendsService : IFriendsService
    {
        #region Implementation of IFriendsService

        public ObservableCollection<Friend> Friends { get; private set; }
        public void GetFriends()
        {
            Friends = new ObservableCollection<Friend>{
                new Friend(){Name = "Tom", Age = 50, Birthday = DateTime.Today},
                new Friend(){Name = "Tom", Age = 50, Birthday = DateTime.Today},
                };
            this.NotifyPropertyChanged(() => Friends, PropertyChanged);
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}