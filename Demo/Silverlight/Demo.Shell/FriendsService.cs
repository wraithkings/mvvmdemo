namespace Demo.Shell
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using Helpers;

    [Export(typeof(IFriendsService))]
    [PartMetadata("IsDesignService", false)]
    public class FriendsService : IFriendsService
    {
        #region Implementation of IFriendsService

        public ObservableCollection<Friend> Friends { get; private set; }
        public void GetFriends()
        {
            Friends = new ObservableCollection<Friend>{
                new Friend(){Name = "张三", Age = 50, Birthday = DateTime.Today},
                new Friend(){Name = "李四", Age = 50, Birthday = DateTime.Today},
                };
            this.NotifyPropertyChanged(() => Friends, PropertyChanged);
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}