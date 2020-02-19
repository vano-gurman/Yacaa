using Yacaa.Services.Settings.Configuration;
using Yacaa.Services.Settings.Models;
using Yacaa.Services.Settings.Service;

namespace Yacaa.Services.Settings
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