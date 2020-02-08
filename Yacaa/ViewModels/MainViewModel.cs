using MaterialDesignThemes.Wpf;
using Stylet;

namespace Yacaa.ViewModels
{
    public class MainViewModel : Screen
    {
        public string Title { get; set; } = "Yacaa";
        public SnackbarMessageQueue SnackQueue { get; set; }
        public bool IsMenuOpen { get; set; }

        public MainViewModel()
        {
            
        }
    }
}