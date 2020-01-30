namespace Yacaa.Shared.Navigation
{
    public class NavigationItem
    {
        public string Caption { get; set; }
        public string NavigationPath { get; set; }

        public NavigationItem(string caption, string navigationPath)
        {
            Caption = caption;
            NavigationPath = navigationPath;
        }
    }
}