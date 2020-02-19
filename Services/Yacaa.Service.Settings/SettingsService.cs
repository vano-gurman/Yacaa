using Yacaa.Service.Settings.Configuration;
using Yacaa.Service.Settings.Models;
using Yacaa.Service.Settings.Service;

namespace Yacaa.Service.Settings
{
    public class SettingsService : SettingsServiceBase
    {
        public DbSettings DbSettings { get; set; } = new DbSettings();
        public UserSettings UserSettings { get; set; } = new UserSettings();
        public UserLayout UserLayout { get; set; } = new UserLayout();
        public SettingsService(SettingsConfiguration settingsConfiguration) : base(settingsConfiguration)
        {
        }
    }
}