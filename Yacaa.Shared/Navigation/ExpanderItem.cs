using System.Collections.ObjectModel;

namespace Yacaa.Shared.Navigation
{
    public class ExpanderItem
    {
        public string Caption { get; set; }
        public ObservableCollection<NavigationItem> NavigationItems { get; set; }

        public ExpanderItem(string caption, ObservableCollection<NavigationItem> navigationItems)
        {
            Caption = caption;
            NavigationItems = navigationItems;
        }
    }
}