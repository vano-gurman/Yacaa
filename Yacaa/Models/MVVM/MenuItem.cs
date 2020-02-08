using System.Collections.ObjectModel;
using Yacaa.Interfaces.ViewModels;

namespace Yacaa.Models.MVVM
{
    public class MenuItem
    {
        public string Label { get; }
        public ObservableCollection<IContentViewModel> Items { get; }

        public MenuItem(string label, ObservableCollection<IContentViewModel> items)
        {
            Label = label;
            Items = items;
        }
    }
}