namespace Demo.Shell
{
    using System.ComponentModel;

    public interface IFriendsService : INotifyPropertyChanged
    {
        System.Collections.ObjectModel.ObservableCollection<Friend> Friends { get; }
        void GetFriends();
    }
}